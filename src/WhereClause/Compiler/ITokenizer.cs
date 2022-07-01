//
//  Copyright 2022  
//
//
using System;
using System.Collections.Generic;

namespace WhereClause.Compiler
{
    public interface ITokenizer
	{
		IEnumerable<Token> Read(string input);
	}
	
}

