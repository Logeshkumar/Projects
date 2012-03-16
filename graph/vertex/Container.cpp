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
std::vector<std::string> Container::Vec;
string Container::temporary;

void Container::vecClear()
{
	ContainerVec.clear();
}
void Container::SetKey(string key)
	{
		this->key = key;
	}

std::string Container::GetKey()
	{
		return key;
	}

void Container::SetTemp(string temporary)
	{
		this->temporary = temporary;
	}

std::string Container::GetTemp()
	{
		return temporary;
	}
void Container::Sethfile(string hfilename)
	{
		this->hfilename =hfilename;
	}

std::string Container::GetHfile()
	{
		return hfilename;
	}

void Container::pushvector(std::string file)
{
	ContainerVec.push_back(file);
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

	void Container::SetXVector(std::vector<std::string> Vec)
	{
		this->Vec = Vec;

	}
	std::vector<std::string> Container::GetXVector()
	{
		return Vec;
	}
	
	

	#ifdef TEST_CONTAINERINFO_H

	int main(int argc, char* argv[])
	{
		return 0;
	}
# endif