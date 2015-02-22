
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 2013
VisualStudioVersion = 12.0.30501.0
MinimumVisualStudioVersion = 10.0.40219.1
Project("{E24C65DC-7377-472B-9ABA-BC803B73C61A}") = "techpromediainc.com(6)", "http://localhost:12237", "{6774DA81-3CDC-4A99-AC25-A1EA3BDC1371}"
	ProjectSection(WebsiteProperties) = preProject
		UseIISExpress = "true"
		TargetFrameworkMoniker = ".NETFramework,Version%3Dv4.5"
		Debug.AspNetCompiler.VirtualPath = "/localhost_12237"
		Debug.AspNetCompiler.PhysicalPath = "..\..\..\..\Desktop\techpromediainc.com\"
		Debug.AspNetCompiler.TargetPath = "PrecompiledWeb\localhost_12237\"
		Debug.AspNetCompiler.Updateable = "true"
		Debug.AspNetCompiler.ForceOverwrite = "true"
		Debug.AspNetCompiler.FixedNames = "false"
		Debug.AspNetCompiler.Debug = "True"
		Release.AspNetCompiler.VirtualPath = "/localhost_12237"
		Release.AspNetCompiler.PhysicalPath = "..\..\..\..\Desktop\techpromediainc.com\"
		Release.AspNetCompiler.TargetPath = "PrecompiledWeb\localhost_12237\"
		Release.AspNetCompiler.Updateable = "true"
		Release.AspNetCompiler.ForceOverwrite = "true"
		Release.AspNetCompiler.FixedNames = "false"
		Release.AspNetCompiler.Debug = "False"
		SlnRelativePath = "..\..\..\..\Desktop\techpromediainc.com\"
	EndProjectSection
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{6774DA81-3CDC-4A99-AC25-A1EA3BDC1371}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{6774DA81-3CDC-4A99-AC25-A1EA3BDC1371}.Debug|Any CPU.Build.0 = Debug|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
