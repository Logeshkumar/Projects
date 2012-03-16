#include <iostream>
#include <string>
#include "Tokenizer.h"
#include "SemiExpression.h"
#include "Parser.h"
#include "ActionsAndRules.h"
#include "ConfigureParser.h"
#include "Navigation.h"
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


int main(int argc, char* argv[])
{
	Navigation nav;
	std::string pa = argv[1];
	std::string recursionr = argv[2];
	std::string pat = argv[3];
	std::string pat2 =argv[4];
	nav.getFiles(pa,recursionr,pat);
	nav.getFiles(pa,recursionr,pat2);

	/*Win32Tools::Directory.SetCurrentDirectoryW(argv[1]);
	SetCurrentDirectoryW(argv[1]);
	if(argv[2]=="-r")
	{
		std::vector<stdStr> files = d.GetFiles();
  std::cout << "\n  files in this directory are:";
  for(size_t i=0; i<files.size(); ++i)
    stdOut << TEXT("\n    ") << files[i];
  std::cout << std::endl;

  files = d.GetFiles(TEXT("*.h*"));
  cout << "\n  *.h* files in this directory are:";
  for(size_t i=0; i<files.size(); ++i)
    stdOut << TEXT("\n    ") << files[i];
  std::cout << std::endl;

	}
	else 
	{

	}
	*/
   
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
	  
	  std::cout << "\n\n";
	     }
    catch(std::exception& ex)
    {
      std::cout << "\n\n    " << ex.what() << "\n\n";
    }
	 }
}