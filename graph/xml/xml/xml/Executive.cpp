/////////////////////////////////////////////////////////////////////
//  Executive.cpp - Helps to build XML Metadata Manager            //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   XML Metadata Manager			                   //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

/*Module Operation:
===================
The executive module is the main module for xml meta data generation 
- It sends packages to parser for creating an xml for packages
- It sends .h files alone to parser for creating xml
- It sends .cpp files alone to parser for creating xml
- It sends dependencies which are not present in the file location 
  for xml generation
Public Interface:
================
get the command line argument and start processing
the command line argument is a relative path like ".."

BuildProcess:
=============
Required files:
Wintools.h,Wintools.cpp,Parser.h,Parser.cpp,Container.h,Container.cpp
XmlTran.h,XmlTran.cpp

Input:
The main expects the command line argument with relative path like ".."

Maintainence History:
=====================
ver 1.0 24 March 2011
- first release
*/

    
    #include"WinTools.h"
	#include <iostream>
	#include "Parser.h"
    #include "Container.h"
    #include "xmlTran.h"
   
	using namespace Win32Tools;
	#ifdef TEST_EXECUTIVEINFO_H
	
	int main(int argc, char* argv[])
	{
		container cont;
		stdStr directori = Convert::ToStdStr(argv[1]);
		Directory::SetCurrentDirectoryW(directori);
		std::cout<<Convert::ToString(Directory::GetCurrentDirectoryW());
		std::string s = Convert::ToString(Directory::GetCurrentDirectoryW());
		cont.SetDir(s);
		Directory::FileCollection(Convert::ToStdStr(argv[argc-1]));
		static std::vector<stdStr> headervec = Directory::gethvector(); // gets the header files
		static std::vector<stdStr> cppvec = Directory::getcppvector(); //gets the .cpp files
    if(headervec.size()>=cppvec.size()) // if header vector size is greator
      {
		 for(size_t i=0;i<headervec.size();i++)
	    {
		  for(size_t j=0;j<cppvec.size();j++)
		    {
		  if(headervec[i]==cppvec[j]) // sending a package to the parser to determine the dependencies
		      {			  
			  stdStr tempstd = headervec[i];
			  std::string temp = Convert::ToString(tempstd);
			  cont.SetKey(temp);
			  temp.append(".h");
			  Parser::Parsing(temp);
			  std::string temp1 = Convert::ToString(tempstd);
			  temp1.append(".cpp");
			  Parser::Parsing(temp1);
			  temp= "";
			  temp1="";		
			  
			  headervec[i].erase();
			  cppvec[j].erase();

		      }		  
	       }
	    }
		 xmlElem x;
		 x.funcPackage();
	 }
	else
	{
		for(size_t i=0;i<cppvec.size();i++)
	     {
		  for(size_t j=0;j<headervec.size();j++)
		    {
		  if(cppvec[i]==headervec[j]) // sending a package to the parser to determine the dependencies
		      {
			 stdStr tempstd = cppvec[i];
			  std::string temp = Convert::ToString(tempstd);
			  cont.SetKey(temp);
			  temp.append(".h");
			  Parser::Parsing(temp);
			  std::string temp1 = Convert::ToString(tempstd);
			  temp1.append(".cpp");
			  Parser::Parsing(temp1);
			  temp= "";
			  temp1="";	
			  headervec[j].erase();
			  cppvec[i].erase();

			  }
		   }
	     }
		 xmlElem x;
		 x.funcPackage();
	}
	if(headervec.size() > 0) // sending to parser .h files with no .cpp files
	{
		for(size_t i=0; i< headervec.size(); i++)
		{
			string q="";
			stdStr h = Convert::ToStdStr(q);
			static map <string, vector<string> > myMapVec;
		    int flag = 0;
			if(headervec[i]!=h)
			{
			stdStr tempstd = headervec[i];
			  std::string temp = Convert::ToString(tempstd);
			  std::string temp1 = temp;
			  cont.SetKey(temp);
			  temp.append(".h");
			  Parser::Parsing(temp);
			  myMapVec = 	cont.GetMap();
			  for( map<string, vector<std::string> >::iterator iter = myMapVec.begin(); iter !=myMapVec.end(); ++iter ) 
			  {
				  string k =(*iter).first;
				if(temp1==k){
					flag = 1;}
			  }
			  if(flag==0)
			  {
				  myMapVec[temp1].push_back("none");
			  }
			  cont.SetMap(myMapVec);
			  temp = "";
			  headervec[i].erase();
			}
		}
		 xmlElem x;
		 x.funch();
	}
	if(cppvec.size() > 0) // sending parser .cpp files with no .h files
	{
		for(size_t i=0; i< cppvec.size(); i++)
		{
			string q="";
			stdStr h = Convert::ToStdStr(q);
			static map <string, vector<string> > myMapVec;
			static int flag = 0;
			if(cppvec[i]!=h)
			{
			stdStr tempstd = cppvec[i];
			  std::string temp = Convert::ToString(tempstd);
			  static std::string temp1 = temp;
			  cont.SetKey(temp);
			  temp.append(".cpp");
			  Parser::Parsing(temp);
			  myMapVec = 	cont.GetMap();
			  for( map<string, vector<std::string> >::iterator iter = myMapVec.begin(); iter !=myMapVec.end(); ++iter ) 
			  {
				if(temp1==(*iter).first){
					flag = 1;}
			  }
			  if(flag==0)
			  {
				  myMapVec[temp1].push_back("none");
			  }
			  cont.SetMap(myMapVec);
			  temp = "";
			  cppvec[i].erase();
			}
		}
		 xmlElem x;
		 x.funcpp();
	}
	if(true) // calling xmltran function createEmpDep which function is explained there. 
	{
	xmlElem x;
	x.CreateEmpDep();
	}
	}
# endif