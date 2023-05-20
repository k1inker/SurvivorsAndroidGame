using System.Collections.Generic;
public static class TransitionHelperType
{
    public static HashSet<int> transitionTop = new HashSet<int>
    {
        0b1111,
        0b0110,
        0b0011,
        0b0010,
        0b1010,
        0b1100,
        0b1110,
        0b1011,
        0b0111
    };

    public static HashSet<int> transitionSideLeft = new HashSet<int>
    {
        0b0100,
        0b01010000,
    };

    public static HashSet<int> transitionSideRight = new HashSet<int>
    {
        0b0001,
        0b00000101,
    };

    public static HashSet<int> transitionBottom = new HashSet<int>
    {
        0b1000
    };

    public static HashSet<int> transtionInnerCornerUpLeft = new HashSet<int>
    {
        0b01111100,
        0b00111000,
        0b01111000,
        0b00111100,
        0b01011000,
        0b01110100,
        0b01001000,
        0b01011100,
        0b00110100,
    };
    public static HashSet<int> transtionInnerCornerUpRight = new HashSet<int>
    {
        0b00011110,
        0b00001111,
        0b00001110,
        0b00001011,
        0b00001010,
        0b00011111,
        0b00011101,
        0b00010101,
        0b00010111,
        0b00011110 //?
    };
    public static HashSet<int> transtionInnerCornerDownLeft = new HashSet<int>
    {
        0b11110001,
        0b11100000,
        0b11110000,
        0b11100001,
        0b10100000,
        0b01010001,
        0b11010001,
        0b01100001,
        0b11010000,
        0b01110001,
        0b00010001,
        0b10110001,
        0b10100001,
        0b10010000,
        0b00110001,
        0b10110000,
        0b00100001,
        0b10010001,
        0b10100000,
    };

    public static HashSet<int> transitionInnerCornerDownRight = new HashSet<int>
    {
        0b11000111,
        0b11000011,
        0b10000011,
        0b10000111,
        0b10000010,
        0b01000101,
        0b11000101,
        0b01000011,
        0b10000101,
        0b01000111,
        0b01000100,
        0b11000110,
        0b11000010,
        0b10000100,
        0b01000110,
        0b10000110,
        0b11000100,
        0b01000010

    };

    public static HashSet<int> transitionDiagonalCornerDownLeft = new HashSet<int>
    {
        0b01000000,
        0b10100000
    };

    public static HashSet<int> transitionDiagonalCornerDownRight = new HashSet<int>
    {
        0b00000001
    };

    public static HashSet<int> transitionDiagonalCornerUpLeft = new HashSet<int>
    {
        0b00010000,
        //0b01010000,
        //0b01011100,
    };

    public static HashSet<int> transitionDiagonalCornerUpRight = new HashSet<int>
    {
        0b00000100,
        //0b00000101,
        0b00000100,
        0b00001101,
    };

    public static HashSet<int> transitionFull = new HashSet<int>
    {
        0b1101,
        0b0101,
        0b1101,
        0b1001
    };

    public static HashSet<int> transitionFullEightDirections = new HashSet<int>
    {
        0b11100100,
        0b10010011,
        0b01110100,
        0b00010111,
        0b00010110,
        0b00110100,
        0b00010101,
        0b01010100,
        0b00010010,
        0b00100100,
        0b00010011,
        0b01100100,
        0b10010111,
        0b11110100,
        0b10010110,
        0b10110100,
        0b11100101,
        0b11010011,
        0b11110101,
        0b11010111,
        0b11110101,
        0b01110101,
        0b01010111,
        0b01100101,
        0b01010011,
        0b01010010,
        0b00100101,
        0b00110101,
        0b01010110,
        0b11010101,
        0b11010100,
        0b10010101,
        0b10111111,
        0b00111111,
        0b11101111,
        0b11001110,
        0b10011111,
        0b11111001,
        0b11111100,
        0b11111000,
        0b11111101,
        0b11011100,
        0b10001111,
        0b00111110,
        0b11111011,
        0b11111111,
        0b01111110,
        0b01011111,
        0b10001101,
        0b11001111,
        0b01110011,
        0b01111111,
        0b11011001,
    };

    public static HashSet<int> transitionBottomEightDirections = new HashSet<int>
    {
        0b01000001
    };

}