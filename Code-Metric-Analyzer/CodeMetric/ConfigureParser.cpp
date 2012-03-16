/////////////////////////////////////////////////////////////////////
//  ConfigureParser.cpp - builds and configures parsers            //
//  ver 1.1                                                        //
//                                                                 //
//  Lanaguage:     Visual C++ 2005                                 //
//  Platform:      Dell Dimension 9150, Windows XP SP2             //
//  Application:   Prototype for CSE687 Pr1, Sp06                  //
//  Author:        Jim Fawcett, CST 2-187, Syracuse University     //
//                 (315) 443-3948, jfawcett@twcny.rr.com           //
/////////////////////////////////////////////////////////////////////

#include "Parser.h"
#include "SemiExpression.h"
#include "Tokenizer.h"
#include "ActionsAndRules.h"
#include "ConfigureParser.h"

//----< constructor initializes pointers to all parts >--------------

ConfigParseToConsole::ConfigParseToConsole() 
  : pToker(0), pSemi(0), pParser(0), pPreprocStatement(0), pPrintPreproc(0), 
    pFunctionDefinition(0), pPrintFunction(0), pPrettyPrintFunction(0) {}

//----< destructor releases all parts >------------------------------

ConfigParseToConsole::~ConfigParseToConsole()
{
  // when Builder goes out of scope, everything must be deallocated
//delete number;
  delete pPrettyPrintFunction;
  delete pPrintFunction;
  delete pFunctionDefinition;
  delete pPrintPreproc;
  delete pPreprocStatement;
  delete pParser;
  delete pSemi;
  delete pToker;
}
//----< attach toker to a file stream or stringstream >------------

bool ConfigParseToConsole::Attach(const std::string& name, bool isFile)
{
  if(pToker == 0)
    return false;
  return pToker->attach(name, isFile);
}
//
//----< Here's where alll the parts get assembled >----------------

Parser* ConfigParseToConsole::Build()
{
  try
  {
    // configure to detect and act on preprocessor statements

    pToker = new Toker;
    pSemi = new SemiExp(pToker);
    pParser = new Parser(pSemi);
    pPreprocStatement = new PreprocStatement;
    pPrintPreproc = new PrintPreproc;
    pPreprocStatement->addAction(pPrintPreproc);
    pParser->addRule(pPreprocStatement);

    pFunctionDefinition = new FunctionDefinition;
    pPrintFunction = new PrintFunction;
    pFunctionDefinition->addAction(pPrintFunction);
    pPrettyPrintFunction = new PrettyPrintFunction;
    pFunctionDefinition->addAction(pPrettyPrintFunction);
    pParser->addRule(pFunctionDefinition);
	//pParser->addRule(number);
    return pParser;
  }
  catch(std::exception& ex)
  {
    std::cout << "\n\n  " << ex.what() << "\n\n";
    return 0;
  }
}

#ifdef TEST_CONFIGUREPARSER

#include <queue>
#include <string>

int main(int argc, char* argv[])
{
  std::cout << "\n  Testing ConfigureParser module\n "
            << std::string(32,'=') << std::endl;

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
      std::cout << "\n\n";
    }
    catch(std::exception& ex)
    {
      std::cout << "\n\n    " << ex.what() << "\n\n";
    }

////
//    std::cout << "\n  Processing file for Queued Outputs " << argv[i];
//    std::cout << "\n  " << std::string(35 + strlen(argv[i]),'-');
//
//    ConfigParseToQueue Qconfigure;
//    pParser = Qconfigure.Build();
//    try
//    {
//      if(pParser)
//      {
//        if(!Qconfigure.Attach(argv[i]))
//        {
//          std::cout << "\n  could not open file " << argv[i] << std::endl;
//          continue;
//        }
//      }
//      else
//      {
//        std::cout << "\n\n  Parser not built\n\n";
//        return 1;
//      }
//      // now that parser is built, use it
//
//      while(pParser->next())
//        pParser->parse();
//      std::cout << "\n\n";
//    }
//    catch(std::exception& ex)
//    {
//      std::cout << "\n\n    " << ex.what() << "\n\n";
//    }
//    std::queue<std::string>* pQueue = Qconfigure.GetQueue();
//    size_t len = pQueue->size();
//    for(size_t i=0; i<len; ++i)
//    {
//      std::cout << "\n  " << pQueue->front();
//      pQueue->pop();
//    }
//    std::cout << "\n\n";
  }
}

#endif
