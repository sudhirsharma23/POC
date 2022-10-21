using System.Diagnostics.CodeAnalysis;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Potential Code Quality Issues", "RECS0026:Possible unassigned object created by 'new'", Justification = "Constructs add themselves to the scope in which they are created")]
[assembly: SuppressMessage("Style", "IDE0130:Namespace does not match folder structure", Justification = "<Pending>", Scope = "namespace", Target = "~N:Poc")]
[assembly: SuppressMessage("Style", "IDE0040:Add accessibility modifiers", Justification = "<Pending>", Scope = "type", Target = "~T:Poc.Program")]
