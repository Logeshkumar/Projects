/////////////////////////////////////////////////////////////////////
//  Executive.cpp -   Main project file							   //
//  ver 1.1                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:  Code Metric analyzer				               //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

 /*Build Process:
  ==============
	  -Required files Tokenizer.h,SemiExpression.h,
	  Parser.h,ActionsAndRules.h,ConfigureParser.h

  Input type:
  ==========
    
  -Give the path of required file to be 
	  analyzed in the command line argument*/

#include <iostream>
#include <string>
#include "Tokenizer.h"
#include "SemiExpression.h"
#include "Parser.h"
#include "ActionsAndRules.h"
#include "ConfigureParser.h"
#include <stack>
using namespace std;


std::stack<std::pair<std::string,std::string>> initialize()
{
	std::stack<std::pair<std::string,std::string>> temp1;
	return temp1;
}
std::stack<std::pair<std::string,std::string>> FunctionDefinition::funcstack;
std::stack<std::pair<std::string,std::string>> FunctionDefinition::getfuncstack()
{
	return funcstack;
}


#ifdef EXECUTIVE_H

int main(int argc, char* argv[])
{
	  
  std::cout << "\n  Testing the file\n "
            << std::string(22,'=') << std::endl;

  // collecting tokens from files, named on the command line

  if(argc < 2)
  {
    std::cout 
      << "\n  please enter name of file to process on command line\n\n";
    return 1;
  }

  for(int i=1; i<argc; ++i)
  {
    std::cout << "\n  Processing file " << argv[i];
    std::cout << "\n  " << std::string(16 + strlen(argv[i]),'-');

    ConfigParseToConsole configure;
    Parser* pParser = configure.Build();
    try
    {
      if(pParser)
      {
        if(!configure.Attach(argv[i]))
        {
          std::cout << "\n  could not open file " << argv[i] << std::endl;
          continue;
        }
      }
      else
      {
        std::cout << "\n\n  Parser not built\n\n";
        return 1;
      }
      // now that parser is built, use it

      while(pParser->next())
        pParser->parse();
	  FunctionDefinition funci;
	  funci.display();
	  std::cout<<"\n\nThe depth of scope of the file is -------------> "<<FunctionDefinition::getbracecount() ;
	  std::cout << "\n\n";
	     }
    catch(std::exception& ex)
    {
      std::cout << "\n\n    " << ex.what() << "\n\n";
    }
	 }
}

#endif