System.Reflection.AmbiguousMatchException: Ambiguous match found.
   at System.Windows.Forms.Control.MarshaledInvoke(Control caller, Delegate method, Object[] args, Boolean synchronous)
   at System.Windows.Forms.Control.Invoke(Delegate method, Object[] args)
   at ns22.Class269.Class272.Resolve(IAssemblyReference assemblyReference, String localPath)
   at ns37.Class486.Class487.Resolve(IAssemblyReference assemblyReference, String localPath)
   at ns2.Class604.Load(IAssemblyReference assemblyReference, String localPath)
   at Reflector.CodeModel.Memory.AssemblyReference.Resolve()
   at ns40.Class620.smethod_3(ITypeReference typeReference)
   at ns11.Class679.Resolve()
   at ns18.Class651.Resolve()
   at ns20.Class712.method_64(IInstruction instruction)
   at ns20.Class712.method_14(IStatement& statement)
   at ns20.Class712.method_15(Int32 end)
   at ns20.Class712.method_87(Int32 offset, Int32 end)
   at ns20.Class712.method_89(IExceptionHandler current)
   at ns20.Class712.method_87(Int32 offset, Int32 end)
   at ns20.Class712.method_6(IMethodDeclaration mD, IMethodBody mB, Boolean handleExpressionStack)
   at ns20.Class712.method_5(IMethodDeclaration mD, IMethodBody mB)
   at ns37.Class187.vmethod_7(IMethodDeclaration value)
   at ns29.Class92.vmethod_142(IMethodDeclarationCollection methods)
   at ns37.Class187.vmethod_5(ITypeDeclaration value)
   at ns37.Class188.TranslateTypeDeclaration(ITypeDeclaration value, Boolean memberDeclarationList, Boolean methodDeclarationBody)
   at ns37.Class486.method_4(ITypeDeclaration typeDeclaration, String sourceFile, ILanguageWriterConfiguration languageWriterConfiguration)
namespace InternetTim
{
}

