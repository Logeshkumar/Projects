#ifndef ACTIONSANDRULES_H
#define ACTIONSANDRULES_H
/////////////////////////////////////////////////////////////////////
//  ActionsAndRules.h - declares new parsing rules and actions     //
//  ver 1.2                                                        //
//  Language:      Visual C++ 2008, SP1                            //
//  Platform:      Dell Precision T7400, Vista Ultimate SP1        //
//  Application:   Prototype for CSE687 Pr1, Sp09                  //
//  Author:        Jim Fawcett, CST 4-187, Syracuse University     //
//                 (315) 443-3948, jfawcett@twcny.rr.com           //
/////////////////////////////////////////////////////////////////////
/*
  Module Operations: 
  ==================
  This module defines several action classes.  Its classes provide 
  specialized services needed for specific applications.  The modules
  Parser, SemiExpression, and Tokenizer, are intended to be reusable
  without change.  This module provides a place to put extensions of
  these facilities and is not expected to be reusable.
  

  Public Interface:
  =================
  Toker t(someFile);              // create tokenizer instance
  SemiExp se(&t);                 // create a SemiExp attached to tokenizer
  Parser parser(se);              // now we have a parser
  Rule1 r1;                       // create instance of a derived Rule class
  Action1 a1;                     // create a derived action
  r1.addAction(&a1);              // register action with the rule
  parser.addRule(&r1);            // register rule with parser
  while(se.getSemiExp())          // get semi-expression
    parser.parse();               //   and parse it

  Build Process:
  ==============
  Required files
    - Parser.h, Parser.cpp, ActionsAndRules.h, ActionsAndRules.cpp,
      SemiExpression.h, SemiExpression.cpp, tokenizer.h, tokenizer.cpp
  Build commands (either one)
    - devenv Project1HelpS06.sln
    - cl /EHsc /DTEST_PARSER parser.cpp ActionsAndRules.cpp \
         semiexpression.cpp tokenizer.cpp /link setargv.obj

  Maintenance History:
  ====================
  ver 1.2 : 27 March 2011
  - deleted the existing rules and created a new rule 
    to determine the direct dependencies in a package
  - deleted existing actions and created a new action which will
    store the dependencies in the container class
  ver 1.1 : 17 Jan 09
  - changed to accept a pointer to interfaced ITokCollection instead
    of a SemiExpression
  ver 1.0 : 12 Jan 06
  - first release

*/
//
#include <queue>
#include <string>
#include <vector>
#include <map>
#include<algorithm>
#include "Parser.h"
#include "ITokCollection.h"
#include "Container.h"

using namespace std;

///////////////////////////////////////////////////////////////
// rule to detect dependent files

class Detection : public IRule
{
public:
  bool doTest(ITokCollection* pTc)
  {
	  ITokCollection& tc = *pTc;
	  int pos = pTc->find("User");
	  if(pTc->find("Dependencies")< pTc->length()&& pTc->find("</")<pTc->length())
	      {
		  doActions(pTc);
		  return true;
	      }
	  return false;
	  
  }
};





///////////////////////////////////////////////////////////////
// action to print preprocessor statement to console

class DependencyStore : public IAction
{
	
public:
  void doAction(ITokCollection* pTc)
  {
	  Container c;
	  ITokCollection& tc = *pTc;
	  int pos = pTc->find("User");
	  string temp = tc[pos-3];
	  static std::vector<std::string> vectemp;
	  string kee = c.GetHfile();
	  string key = c.GetKey();
	  if(vectemp.size()==0 && temp!="none"&& temp!=kee && temp!=key)
	      {
		  vectemp.push_back(temp);
	      }
      vector<std::string>::iterator it;
	  it = find (vectemp.begin(), vectemp.end(), temp);
	  if(temp!="none"&& it==vectemp.end()&& temp!=kee&& temp!=key)
	      {     
	      vectemp.push_back(temp);
	      }
	  c.SetVector(vectemp);
  }
   
};

#endif
