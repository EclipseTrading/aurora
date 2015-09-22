param([String] $commonAssemblyInfo, [String]$build, [String] $env)

"Updating Version Build Number To: " + $build

$assemblyInfo = Get-Content $commonAssemblyInfo
$version = '$1.' + $build
$replace = 'Version("' + $version + '")'
$assemblyInfo -Replace  'Version\(\"([0-9]+\.[0-9]+\.[0-9]+)(\.[0-9]+)?\"\)', $replace | Out-File $commonAssemblyInfo

$assemblyInfo = Get-Content $commonAssemblyInfo
$informationalVersion = '$1.' + $build + '-' + $env
$replace = 'AssemblyInformationalVersion("' + $informationalVersion  + '")'
$assemblyInfo -Replace 'AssemblyInformationalVersion\(\"([0-9]+\.[0-9]+\.[0-9]+)(\.[0-9]+\-DEV)?\"\)', $replace | Out-File $commonAssemblyInfo
