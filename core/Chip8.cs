using Takoyaki.Core.Display;

namespace Takoyaki.Core;

// The core of Chip-8 emulation.
public class Chip8
{
    #region Constants
    // CHIP-8 memory size is 4,096 (0x1000) bytes
    public const int MEMORY_SIZE = 0x1000;
    // Display sizes, lores and hires
    public const int DISPLAY_SIZE_LORES = 0x100;
    public const int DISPLAY_SIZE_HIRES = 0x400;
    // Program counter starting point. This should be at 0x200.
    public const ushort PROGRAM_COUNTER_START_POINT = 0x200;

    #region Input Flags
    const ushort KEY_INPUT_0 = 0b1;
    const ushort KEY_INPUT_1 = 0b10;
    const ushort KEY_INPUT_2 = 0b100;
    const ushort KEY_INPUT_3 = 0b1000;
    const ushort KEY_INPUT_4 = 0b10000;
    const ushort KEY_INPUT_5 = 0b100000;
    const ushort KEY_INPUT_6 = 0b1000000;
    const ushort KEY_INPUT_7 = 0b10000000;
    const ushort KEY_INPUT_8 = 0b100000000;
    const ushort KEY_INPUT_9 = 0b1000000000;
    const ushort KEY_INPUT_A = 0b10000000000;
    const ushort KEY_INPUT_B = 0b100000000000;
    const ushort KEY_INPUT_C = 0b1000000000000;
    const ushort KEY_INPUT_D = 0b10000000000000;
    const ushort KEY_INPUT_E = 0b100000000000000;
    const ushort KEY_INPUT_F = 0b1000000000000000;
    #endregion
    #endregion

    // Reads from the current memory address, then increments our program counter by 2.
    public Opcode Fetch()
    {
        ushort result = (ushort)(status.memory[status.pc++] << 8);
        result |= status.memory[status.pc++];
        return new Opcode(result);
    }

    public void Execute()
    {
        // Fetch opcode
        var opcode = Fetch();

        // Switch based on opcode A value
        switch (opcode.A)
        {
            case 0x0:
                // Control functions, break out into further instructions
                ControlInstructions(ref opcode);
                break;
            case 0x1:
                // 0x1NNN: Jump to NNN
                status.pc = opcode.NNN;
                break;
            case 0x6:
                // 0x6XNN: VX = NN
                status.v[opcode.X] = opcode.NN;
                break;
            case 0x7:
                // 0x7XNN: VX += NN
                status.v[opcode.X] += opcode.NN;
                break;
            case 0xA:
                // 0xANNN: I = NNN;
                status.I = opcode.NNN;
                break;
            case 0xD:
                // 0xDXYN: Draw sprite
                break;
            default:
                // not implemented
                break;
        }
    }

    // Control instructions (0xabcd)
    private void ControlInstructions(ref Opcode opcode)
    {
        switch (opcode.NNN)
        {
            case 0x0E0:
                // Clear screen
                display.ClearDisplay();
                break;
            default:
                // Unsupported opcode
                break;
        }
    }

    public Chip8State status;
    public Chip8Display display;
}