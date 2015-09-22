param([String] $commonAssemblyInfo, [String]$build, [String] $env)

"Updating Version Build Number To: " + $build

$envName = $env
IF($env.StartsWith('Feature/')) {
   $m = $env | Select-String -Pattern 'Feature/([A-Z]+\-[0-9]+)' | Select-Object -first 1
   $envName = $m.Matches[0].Groups[1].Value
}

# If Prod Use the Assembly Version, otherwise take the version with the environment / JIRA at the end, i.e. pre-release version string
$verString = If($env -eq 'PROD') { 'AssemblyVersion' } ELSE { 'AssemblyInformationalVersion' } 

# Update the AssemblyVersion and AssemblyFile Version
$assemblyInfo = Get-Content $commonAssemblyInfo
$version = '$1.' + $build
$replace = 'Version("' + $version + '")'
$assemblyInfo -Replace  'Version\(\"([0-9]+\.[0-9]+\.[0-9]+)(\.[0-9]+)?\"\)', $replace | Out-File $commonAssemblyInfo

# Update the AssemblyInformationalVersion
$assemblyInfo = Get-Content $commonAssemblyInfo
$informationalVersion = '$1.' + $build + '-' + $envName
$replace = 'AssemblyInformationalVersion("' + $informationalVersion  + '")'
$assemblyInfo -Replace 'AssemblyInformationalVersion\(\"([0-9]+\.[0-9]+\.[0-9]+)(\.[0-9]+\-DEV)?\"\)', $replace | Out-File $commonAssemblyInfo

# Get the version string to tag the nuget package with
$pattern = '\[assembly\:\s*'+$verString+'\(\"(.*)\"\)'
$match = Get-Content $commonAssemblyInfo | Select-String -Pattern $pattern | Select-Object -first 1
$version = $match.Matches[0].Groups[1].Value

# Update all the nuget files to reference the version in this build
Get-ChildItem . -Filter *.nuspec | `
Foreach-Object {
  $content = Get-Content $_.Name 
  $replace = '<dependency id="$1" version="' + $version + '"/>'
  $dep = '<dependency\s*id=\"(Aurora\.[a-zA-Z0-9_]*)\"\s*version=\"[0-9\.]*\"\s*/>'  
  $content -Replace $dep, $replace | Out-File $_.Name
}