#ifndef ACTIONSANDRULES_H
#define ACTIONSANDRULES_H
/////////////////////////////////////////////////////////////////////
//  ActionsAndRules.h - declares new parsing rules and  actions    //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:  Code Metric analyzer				               //
//  Author:        logeshkumar								       //
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

*/

#include <queue>
#include <stack>
#include <iostream>
#include <string>
#include "Parser.h"
#include "ITokCollection.h"
using namespace std;


///////////////////////////////////////////////////////////////
// rule to detect preprocessor statements

class PreprocStatement : public IRule
{
public:
	bool doTest(ITokCollection* pTc)
	{
		if(pTc->find("#") < pTc->length())
		{
			doActions(pTc);
			return true;
		}
		return false;
	}
};

///////////////////////////////////////////////////////////////
// rule to detect function definitions

class FunctionDefinition : public IRule
{  
	class control{
	public :
		std::string classname;
		std::string type;
		int beginline;
		};
	private:
	int clazstart;
	int functionstart;
	int controlstart;
	static int bracecount;
	int largestcontrol;
	int cyclomaticC;
	int cc;
	int forcalone;
	bool forcontrol;
	bool arraydeviation;
	stack<control> mstack;
	static std::stack<std::pair<std::string,std::string>> funcstack;
	
	
	

public:
	// Initializing the constructor
	 FunctionDefinition (): clazstart(0),functionstart(0),controlstart(0),cyclomaticC(0), cc(1), largestcontrol(0),forcontrol(false), arraydeviation(false),forcalone(0){}
	
  //key word before open parentheses
  std::pair<std::string,std::string> typee;
  static std::stack<std::pair<std::string,std::string>> getfuncstack();
   
  // stores the keywords while and if inorder to check the complexity
  bool cyclo(const std::string& tok)
	{
		const static std::string keys[]
		= {"while", "if"};
		for(int i=0; i<2; ++i)
			if(tok == keys[i])
				return true;
		return false;
	}
  // returns the highest depth in the file
 static int getbracecount()
  {
	  return bracecount;
	    }
  
 // when the number bracecount encounterd is greater than the previous the highest value is set as bracecount value;
  void bracescount(ITokCollection* pTc)
  {
	   int brace=pTc->braces();
			 if(brace>bracecount)
			  {
				  bracecount++;
			  }
			 return;
  }

  // when an "}" braces is encountered it enters if the stack is not empty.
  void poping(ITokCollection* pTc)
  {
	  			if(mstack.size()!=0)
		{
			control c = mstack.top(); // add try catch fer this top and pop // throwing error wen there is no elements in the stack or.. wen there is a extra braces put.
			mstack.pop();
			if(c.type=="control")// checks if the closing braces is of a control
			   {
				int controll = pTc->tokerlines();
				if(controll-c.beginline>20)
				{
					cout<<"\n\n Warning (()) control statement *"<< c.classname<<"* size is --------> "<<controll-c.beginline;
				}
				else
				cout<<"\n\ncontrol statement *"<<c.classname<<"* size is --------> "<<controll-c.beginline;
				bracescount(pTc);
			   }
		  else if(c.type == "function")// checks if the closing braces is of a class
		      {
			  cyclomaticC= cc;
			  int functionline = pTc->tokerlines();
			  cout<<"\n\nfunction  *"<<c.classname<<"* size is -------->  "<< functionline-c.beginline;
			  cout<<"\n\nCyclomatic complexity of the function *"<<c.classname<<"* is-------->  "<<cyclomaticC;
			   cc=1;
			   forcalone = 0;
			 bracescount(pTc);
		      }
		  else                                          // else the closing braces is of a class
		     {
		       int claz = pTc->tokerlines();               
			   cout<<"\n\n class   *"<<c.classname<<"*  size is -------->  "<<claz-c.beginline;
			   bracescount(pTc);
			   cout<<"\n\n\n\n\n class <<==================  "<<c.classname<<"  ==================>>\n\n\n\n\n\n";
			  
			     } 
		 }
			else // when the user enters improper sturcture i.e wen number open and close paranthesis doesn match.. this is displayed
			{
				cout<<"Proper braces";
  }
  }

  // it displays the function names in a file

  void display()
  {
	  while(funcstack.size()!=0)
	  {
		  string fir = funcstack.top().first;
	  string sec = funcstack.top().second;
	  funcstack.pop();
	cout<<"\n\nThe functions in the file are *"<<fir<<"* ==>  "<<sec;
	  }
 
  }
  // it stores the special keywords like for , whihe ,catch.. etc.. This function is later used to check if the open braces is of a control or class or function
	bool isSpecial(const std::string& tok)
	{
		const static std::string keys[]
		= { "for", "while", "switch", "if", "catch","try","else if","do","else"};
		for(int i=0; i<9; ++i)
			if(tok == keys[i])
				return true;
		return false;
	}

	// if for or while or if are found in a semi Expression the the cyclomatic complexity is incraesed
	void cyclomatic(ITokCollection* pTc)
	{
ITokCollection& tc = *pTc;
		for(int i=0;i<tc.length();i++)                                  //cyclomatic complexity for control statementw without "{" with"(";
		{
			if(tc[i]=="for")
			{
				cc++;
				forcalone = cc;
			}
			else if(tc[i]=="if"|| tc[i]=="while")
			{
				cc++;
				if(i!=0&&tc[i-1]=="else")
				{
					cc--;
				}
			}
		}

	}
	// increases the cyclomatic complexity when break or continue is encounterd.
	void cyclomatic1(ITokCollection* pTc)
	{
		ITokCollection& tc = *pTc;
		int cb = tc.find(";");
			if(cb<tc.length() && cb!=0)
			{
				if(tc[cb-1]== "break"|| tc[cb-1]=="continue")
				{
					cc++;
				}
			}
		int poss = tc.find("(");
		if(poss<tc.length()&&tc[poss-1]=="for")
		{
			forcontrol = true;
		}
	}

	int openbraces(ITokCollection* pTc)
	{
		ITokCollection& tc = *pTc;
			 if(tc[tc.length() - 1] == "{"&&tc.find("=")==tc.length())  //cyclomatic complexity with "{" and "("
        {
          int pos = tc.find("(");
          if(pos < tc.length())
          {
            if(isSpecial(tc[pos-1]))
			{	control c;
				c.classname = tc[pos - 1];
				c.type = "control";
				c.beginline = pTc->tokerlines();
				mstack.push(c);
           bracescount(pTc);
			return true;
			}
			else
			{				
			    control c;
				c.classname = tc[pos - 1];
				c.type = "function";
				typee.first= "function";
				typee.second=tc[pos-1];
				c.beginline = pTc->tokerlines();
				mstack.push(c);
				funcstack.push(typee);
          	bracescount(pTc);
			return true;
			}
          }
          else
   {
			  if(tc.find("class")<tc.length())
			  {
				   int clasposition=tc.find("class");
				   control c;
				c.classname = tc[clasposition+1];
				c.type = "class";
				c.beginline = pTc->tokerlines();
				mstack.push(c);
			 bracescount(pTc);
			 cout<<"\n\n\n class <<==================  "<<c.classname<<"  ==================>>\n\n\n";
			 return true;
			  }
    }
		      }
			 return true;

	}

	// iniates the function to determine the function size, cyclomatic complexity. depth of scope and breadth of control span.

		bool doTest(ITokCollection* pTc){	
		ITokCollection& tc = *pTc;
		cyclomatic(pTc);
		cyclomatic1(pTc);
		if(tc.find("=")<tc.length()&&tc.find("{")<tc.length()){
					arraydeviation = true;
					return true;}
		else if(tc.find("}")<tc.length()){if(arraydeviation){
				arraydeviation = false;
				return true;}
			poping(pTc);}
		if(tc[tc.length() - 1] == "{") { // for else if its going under this llopp
			if(forcontrol)if(forcalone == cc ){
			 control c;
				c.classname = "for";
				c.type = "control";
				c.beginline = pTc->tokerlines();
				mstack.push(c);
            bracescount(pTc);
			forcontrol = false;
			return true;}
			if(tc.find("else")||tc.find("do")||tc.find("try")<tc.length()){	if(tc.find("else")<tc.length()){				
			    control c;
				c.classname = "else";
				c.type = "control";
				c.beginline = pTc->tokerlines();
				mstack.push(c);
            bracescount(pTc);
			return true; }		       
				else if(tc.find("do")<tc.length()){				
			    control c;
				c.classname = "do";
				c.type = "control";
				c.beginline = pTc->tokerlines();
				mstack.push(c);
           bracescount(pTc);
		 	return true;  }
				else if(tc.find("try")<tc.length()){
			    control c;
				c.classname = "try";
				c.type = "control";
				c.beginline = pTc->tokerlines();
				mstack.push(c);
           bracescount(pTc);
			return true;   }}}
		openbraces(pTc);
	   int classend = tc.find(";");
		if(tc.find(";")==tc.length() && classend!=0) {if(tc[classend-1]== "}")
				return true;  }
		      return false;   }};
///////////////////////////////////////////////////////////////
// action to print preprocessor statement to console

class PrintPreproc : public IAction
{
public:
	void doAction(ITokCollection* pTc)
	{
		std::cout << "\n\n  Preproc Stmt: " << pTc->show().c_str();
	}
};


///////////////////////////////////////////////////////////////
// action to send semi-expression that starts a function def
//        to console

class PrintFunction : public IAction
{
public:
	void doAction(ITokCollection* pTc)
	{
		std::cout << "\n\n  FuncDef Stmt: " << pTc->show().c_str();
	}
};

///////////////////////////////////////////////////////////////
// action to send signature of a function def to console

class PrettyPrintFunction : public IAction
{
public:
	void doAction(ITokCollection* pTc)
	{
		pTc->remove("public");
		pTc->remove(":");
		pTc->trimFront();
		int len = pTc->find(")");
		std::cout << "\n\n  Pretty Stmt:    ";
		for(int i=0; i<len+1; ++i)
			std::cout << (*pTc)[i] << " ";
	}
};



#endif
