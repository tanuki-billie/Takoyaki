namespace Takoyaki.Core;

// Struct for state of a chip-8
public struct Chip8State
{
    public byte[] memory = new byte[Chip8.MEMORY_SIZE];
    public byte[] v = new byte[16];
    public byte timer = 0;
    public byte delay = 0;
    public ushort I = 0;
    public ushort pc = Chip8.PROGRAM_COUNTER_START_POINT;
    public ushort[] stack = new ushort[0x100];
    public byte sp = 0;
    public ushort input = 0;
    public Chip8State() { }
}