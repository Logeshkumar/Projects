/////////////////////////////////////////////////////////////////////
//  Container.cpp - Helps in storing data                          // 
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   XML Metadata Manager			                   //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////


#include "Container.h"
using namespace std;
string container::key;
std::vector<std::string> container::ContainerVec;
std::vector<std::string> container::DirVec;
map<std::string, std::vector<std::string>> container::ContainerMap;
string container::hfilename;
string container::cppfilename;

void container::SetKey(string key)
	{
		this->key = key;
	}

std::string container::GetKey()
	{
		return key;
	}
void container::Sethfile(string hfilename)
	{
		this->hfilename =hfilename;
	}

std::string container::GetHfile()
	{
		return hfilename;
	}
void container::Setcppfile(string cppfilename)
	{
		this->cppfilename =cppfilename;
	}

std::string container::Getcppfile()
	{
		return cppfilename;
	}
	
	void container::SetVector(std::vector<std::string> ContainerVec)
	{
		this->ContainerVec = ContainerVec;

	}
	std::vector<std::string> container::GetVector()
	{
		return ContainerVec;
	}

	void container::SetdirVector(std::vector<std::string> DirVec)
	{
		this->DirVec = DirVec;

	}
	std::vector<std::string> container::GetdirVector()
	{
		return DirVec;
	}
	void container::SetMap(map<std::string, std::vector<std::string>> ContainerMap)
	{
		this->ContainerMap = ContainerMap;
	}
	map<std::string, std::vector<std::string>> container::GetMap()
	{
		return ContainerMap;
	}
	

	#ifdef TEST_CONTAINERINFO_H

	int main(int argc, char* argv[])
	{
		return 0;
	}
# endif