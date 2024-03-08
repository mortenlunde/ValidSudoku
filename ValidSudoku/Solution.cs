namespace ValidSudoku;

public static class Solution
{
    public static bool IsValidSudoku(char[][] board)
    {
        for (int v = 0; v < 9; v++)
        {
            if (!IsRowValid(board, v) || !IsColumnValid(board, v) || !IsBoxValid(board, v))
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsRowValid(IReadOnlyList<char[]> board, int row)
    {
        bool[] numberExists = new bool[9];
        for (int r = 0; r < 9; r++)
        {
            if (board[row][r] == '.') continue;
            int num = board[row][r] - '1';
            if (numberExists[num]) return false;
            numberExists[num] = true;
        }
        return true;
    }

    private static bool IsColumnValid(IReadOnlyList<char[]> board, int column)
    {
        bool[] numberExists = new bool[9];
        for (int c = 0; c < 9; c++)
        {
            if (board[c][column] == '.') continue;
            int num = board[c][column] - '1';
            if (numberExists[num]) return false;
            numberExists[num] = true;
        }
        return true;
    }

    private static bool IsBoxValid(IReadOnlyList<char[]> board, int box)
    {
        bool[] numberExists = new bool[9];
        int rowStart = (box / 3) * 3;
        int colStart = (box % 3) * 3;
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                int rowIndex = rowStart + r;
                int colIndex = colStart + c;
                if (board[rowIndex][colIndex] == '.') continue;
                int num = board[rowIndex][colIndex] - '1';
                if (numberExists[num]) return false;
                numberExists[num] = true;
            }
        }
        return true;
    }
}
