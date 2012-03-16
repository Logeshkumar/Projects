/////////////////////////////////////////////////////////////////////
//  Container.h - Helps in storing data                            //
//  ver 1.0                                                        //
//  Language:      Visual C++ 2010				                   //
//  Platform:      Windows 7								       //
//  Application:   XML Metadata Manager			                   //
//  Author:        logeshkumar								       //
/////////////////////////////////////////////////////////////////////

#include "Container.h"
using namespace std;
string Container::key;
std::vector<std::string> Container::ContainerVec;
string Container::hfilename;
std::vector<std::string> Container::RemoverVec;

void Container::SetKey(string key)
	{
		this->key = key;
	}

std::string Container::GetKey()
	{
		return key;
	}
void Container::Sethfile(string hfilename)
	{
		this->hfilename =hfilename;
	}

std::string Container::GetHfile()
	{
		return hfilename;
	}

	
	void Container::SetVector(std::vector<std::string> ContainerVec)
	{
		this->ContainerVec = ContainerVec;

	}
	std::vector<std::string> Container::GetVector()
	{
		return ContainerVec;
	}
	void Container::SetRVector(std::vector<std::string> RemoverVec)
	{
		this->RemoverVec = RemoverVec;

	}
	std::vector<std::string> Container::GetRVector()
	{
		return RemoverVec;
	}

	
	

	#ifdef TEST_CONTAINERINFO_H

	int main(int argc, char* argv[])
	{
		return 0;
	}
# endif