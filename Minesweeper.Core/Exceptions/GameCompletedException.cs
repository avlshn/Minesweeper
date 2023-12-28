using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Exceptions;
/// <summary>
/// Exception when trying to make a turn in already completed game
/// </summary>
public class GameCompletedException : Exception
{
    /// <summary>
    /// default constructor
    /// </summary>
    /// <param name="message">exception message</param>
    public GameCompletedException(string message) : base(message)
    {}
}
