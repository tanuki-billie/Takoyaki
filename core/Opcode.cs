namespace Takoyaki.Core;

public struct Opcode
{
    public ushort opcode = 0;
    public readonly int A => opcode >> 12;
    public readonly byte N => (byte)(opcode & 0xF);
    public readonly byte NN => (byte)opcode;
    public readonly ushort NNN => (ushort)(opcode & 0xFFF);
    public readonly int X => (opcode & 0xF00) >> 8;
    public readonly int Y => (opcode & 0xF0) >> 4;

    public Opcode() { }
    public Opcode(ushort opcode) => this.opcode = opcode;
}