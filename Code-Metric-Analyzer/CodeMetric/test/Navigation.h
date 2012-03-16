#ifndef EXECUTIVE_H
#define EXECUTIVE_H
///////////////////////////////////////////////////////////////////////
//  Executive.h - Executive class for organization of Code analyser  //
//  ver 1.0       application                                        //
//  Platform:      Lenovo Y460, Windows 7					         //
//  Application:   CSE687 Project #1, Spring 2011                    //
//  Author:        A.Ajai SankaraNarayanan					         //
//                 asnara01@syr.edu						             //
///////////////////////////////////////////////////////////////////////

/*
Module Operation:
=================
This module is used to organize the navigation of the parser across
directories in the path mentioned by the user and to display the information 
in a more organized fashion.
This module forms view component of the Code Metric Analyzer.

Public Interface:
-----------------
 path1=Path::getFullPath(path1);
 na.getFiles(Convert::ToString(path1),Convert::ToString(argv[argc-1]),Convert::ToString(argv[2]));	
 classContainer::setFileName((*(i)).c_str());
 stagingProcessing(*(i));na.getFiles(Convert::ToString(path1),Convert::ToString(argv[argc-2]),Convert::ToString(argv[2]));
 classContainer::resetObjectTable();
 classContainer::resetVariableCount();		

 ///////////////////////////////////////////////////////////////
//                      maintenance page                     //
///////////////////////////////////////////////////////////////
//  Build Process                                            //
//                                                           //
//  Files Required:                                          //
//    iostream,vector,Exec_Anal.h,Tokenizer.h,				 //
//	  SemiExpression.h,Parser.h,ActionsAndRules.h,			 //
//	  ConfigureParser.h,Nav.h,Fileinfo.h,					 //
//	  StringConversion.h,Windows.h,WinTools.h			     //	
//                                                           //
//  Building with Visual C++ , 8.0, from command line:       //
//    cl -EHsc Exec_Anal.cpp							     //
//                                                           //
///////////////////////////////////////////////////////////////


Maintenance History:

Version 1.0 - 13-Feb 2011.
-Modified the getFiles function to asynchronously assign values to header and cpp stacks.
*/


#include <iostream>
#include <vector>
#include "WinTools.h"
#include "FileInfo.h"
#include "StringConversion.h"
#include "nav.h"
using namespace std;
using namespace Win32Tools;

//Class for navigating across directories in the specified path.
class Navigation 
{
private:
	static std::vector<std::string> hstack;
	static std::vector<std::string> cppstack;

public:
	void getFiles(std::string& path,std::string recurse,std::string& pattern);
	//Funciton to load the header files into header stack.
	std::vector<std::string> gethstack();
	//Function to load Cpp files into Cpp stack.
	std::vector<std::string> getcppstack();

};

#endif