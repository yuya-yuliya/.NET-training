
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Clock
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.file FlipClock.netmodule
    .hash = (2A DA C3 4E 53 B8 13 55 A6 27 4A D6 CC 83 79 38   // *..NS..U.'J...y8
             5B D9 05 3E )                                     // [..>
.file DigitalClock.netmodule
    .hash = (BE 9D 2B CF 54 31 7D 62 54 D2 59 E5 E1 FB 65 42   // ..+.T1}bT.Y...eB
             DD 65 6F 37 )                                     // .eo7
.class extern public Clock.FlipClock
{
  .file FlipClock.netmodule
  .class 0x02000002
}
.class extern public Clock.DigitalClock
{
  .file DigitalClock.netmodule
  .class 0x02000002
}
.module Clock.dll
// MVID: {55F83405-55BA-4E5B-A6F8-7173E3855542}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x01B50000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit Clock.QuartzClock
       extends [mscorlib]System.Object
{
  .method public hidebysig instance string 
          QuartzClockInfo() cil managed
  {
    // Размер кода:       11 (0xb)
    .maxstack  1
    .locals init (string V_0)
    IL_0000:  nop
    IL_0001:  ldstr      "Quartz clock info"
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method QuartzClock::QuartzClockInfo

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method QuartzClock::.ctor

} // end of class Clock.QuartzClock


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 Clock.res
