
#include <iostream>
#include <vector>
//#include "../Navigate/Navigate/WinTools.h"
//#include "../Navigate/Navigate/FileInfo.h"
//#include "../Navigate/Navigate/StringConversion.h"
//#include "../Navigate/Navigate/nav.h"
#include "Navigation.h"
using namespace std;
using namespace Win32Tools;

//Navigation::Navigation(){
//
//}
//
//Navigation::~Navigation()
//{
//}
std::vector<std::string> initialize(){
	std::vector<std::string> temp;
	return temp;
}
std::vector<std::string> Navigation::hstack = initialize(); 
//Function to initialize Cpp stack.
std::vector<std::string> initialise(){
	std::vector<std::string> temp;
	return temp;
}

std::vector<std::string> Navigation::cppstack = initialise();
std::vector<std::string> Navigation:: gethstack()
{
	return hstack;
}

std::vector<std::string> Navigation:: getcppstack()
{
	return cppstack;
}

void Navigation::getFiles(std::string& path,std::string recurse,std::string& pattern)
{
	stdStr path1= Convert::ToStdStr(path);
	stdStr pattern1= Convert::ToStdStr(pattern);
	//Setting the given path to the current directory.
	Directory::SetCurrentDirectory(path1);
	std::vector<stdStr> temp1 = Directory::GetFiles(path1,pattern1);
	std::vector<stdStr>::iterator iter;
	//Snippet for loading the header stack.
	if(pattern == "*.h")
	{
		for(iter=temp1.begin();
			iter!=temp1.end();
			iter++)
		{
			//Initializing the Header stack.
			Navigation::hstack.push_back(Convert::ToString(Path::getFullPath(*iter)));
		}
		if(recurse == "-r")
		{
			//Code snippet to implement recurrsive search of files.
			std::vector<stdStr> dir = Directory::GetDirectories(Convert::ToStdStr("*.*"));
			std::vector<stdStr>::iterator iter2;
			for(iter2 = dir.begin(); iter2!= dir.end(); iter2++)
			{
				Directory::SetCurrentDirectory(*iter2);
				getFiles(Convert::ToString(*(iter2)),recurse,pattern);
			}
		}
	}

	//Snipper for loading the cpp stack.
	if(pattern == "*.cpp")
	{
		for(iter=temp1.begin();
			iter!=temp1.end();
			iter++)
		{
			Navigation::cppstack.push_back(Convert::ToString(Path::getFullPath(*iter)));
		}
		if(recurse == "-r")
		{
			std::vector<stdStr> dir = Directory::GetDirectories(Convert::ToStdStr("*.*"));
			std::vector<stdStr>::iterator iter2;
			for(iter2 = dir.begin(); iter2!= dir.end(); iter2++)
			{
				Directory::SetCurrentDirectory(*iter2);
				getFiles(Convert::ToString(*(iter2)),recurse,pattern);
			}
		}
	}
	

}
std::string getFileName(std::string fileName)
{
	std::string temp;
	int len;
	int len1;
	len=fileName.find_last_of("/\\");
	temp=fileName.substr(len+1);
	len1=temp.find_last_of(".");
	std::string temp1= temp.substr(0,len1);
	//std::cout<<temp1<<std::endl;
	return temp1;
}

//std::string getcommandinfo()