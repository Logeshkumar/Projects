///////////////////////////////////////////////////////////////////////
//  wintools.cpp - Win32 API-based helper functions                  //
//  ver 3.3                                                         //
//  Platform:      Dell Precision T7400, Vista Ultimate, SP1         //
//  Application:   CSE775 Project #1, Spring 2009                    //
//  Author:        Jim Fawcett, Syracuse University CST 4-187        //
//                 (315) 443-3948, jfawcett@twcny.rr.com             //
///////////////////////////////////////////////////////////////////////

#include <sstream>
#include <iomanip>
#include <iostream>
#include<string>
#include "WinTools.h"

using namespace Win32Tools;

//----< set path to return to on call to RestorePath() >---------------
 static std::vector<stdStr> xfiles;
   	 
bool Directory::SetRestorePath(const stdStr& path)
{
  if(Directory::DirectoryExists(path))
  {
    RestorePath_ = path;
    return true;
  }
  return false;
}
//----< does this directory exist? >-----------------------------------

bool Directory::DirectoryExists(const stdStr& path)
{
  stdStr temp = GetCurrentDirectory();
  if(SetCurrentDirectory(path))
  {
    SetCurrentDirectory(temp);
    return true;
  }
  return false;
}
//----< create directory >---------------------------------------------

bool Directory::CreateDirectory(const stdStr& path)
{
  return (::CreateDirectory(path.c_str(),0) != 0);
}
//----< remove directory >---------------------------------------------

bool Directory::RemoveDirectory(const stdStr &path, bool confirm)
{
  return (::RemoveDirectory(path.c_str()) != 0);
}
//----< get path of current directory >--------------------------------

stdStr Directory::GetCurrentDirectory()
{
  const size_t BufSize = 256;
  stdChar buffer[BufSize];
  ::GetCurrentDirectory(BufSize, buffer);
  return stdStr(buffer);
}
//----< set path of current directory >--------------------------------

bool Directory::SetCurrentDirectory(const stdStr& path)
{
  return (::SetCurrentDirectory(path.c_str()) != 0);
}

//----< get files >----------------------------------------------------

std::vector<stdStr> Directory::GetFiles(const stdStr& path, const stdStr& pattern)
{
  std::vector<stdStr> files;
  fileInfo fi;
  if(fi.firstFile(path,pattern))
  {
    if(!fi.isDirectory())
      files.push_back(fi.name());
    while(fi.nextFile())
      if(!fi.isDirectory())
        files.push_back(fi.name());
  }
  return files;
}
//----< get files >----------------------------------------------------

std::vector<stdStr> Directory::GetFiles(const stdStr& pattern)
{
  return GetFiles(GetCurrentDirectory(),pattern);
}
//----< get directories >----------------------------------------------

std::vector<stdStr> Directory::GetDirectories(const stdStr& path, const stdStr& pattern)
{
  std::vector<stdStr> files;
  fileInfo fi;
  if(fi.firstFile(path,pattern))
  {
    if(fi.isDirectory())
    {
      if(fi.name() != TEXT(".") && fi.name() != TEXT(".."))
        files.push_back(Path::fileSpec(path,fi.name()));
    }
    while(fi.nextFile())
      if(fi.isDirectory())
        if(fi.name() != TEXT(".") && fi.name() != TEXT(".."))
          files.push_back(Path::fileSpec(path,fi.name()));
  }
  return files;
}
//----< get directories >----------------------------------------------

std::vector<stdStr> Directory::GetDirectories(const stdStr& pattern)
{
  return GetDirectories(GetCurrentDirectory(),pattern);
}
//----< get fileInfo objects >-----------------------------------------

std::vector<fileInfo> Directory::GetFileInfos(const stdStr& path, const stdStr& pattern)
{
  std::vector<fileInfo> dinfos;
  fileInfo fi;
  if(fi.firstFile(path,pattern))
  {
    dinfos.push_back(fi);
    while(fi.nextFile())
      dinfos.push_back(fi);
  }
  return dinfos;
}
//----< get fileInfo objects >-----------------------------------------
std::vector<stdStr> Directory::getxvector()
{
	return xfiles;
}


std::vector<fileInfo> Directory::GetFileInfos(const stdStr& pattern)
{
  return GetFileInfos(GetCurrentDirectory(),pattern);
}
//----< copy files matching from filespec to toPath >----------------

bool Directory::CopyFiles(
       const stdStr& from, 
       const stdStr& toPath,
       bool FailIfExists
     )
{
  stdStr SrcDir = Path::getFullPath(from);
  stdStr CurrDir = Directory::GetCurrentDirectory();
  bool ok = true;
  if(Directory::SetCurrentDirectory(SrcDir))
  {
    std::vector<stdStr> files 
      = Directory::GetFiles(Path::getName(from));
    if(files.size() == 0)
      ok = false;
    for(size_t i=0; i<files.size(); ++i)
    {
      stdStr toFileSpec = Path::fileSpec(toPath,files[i]);
      stdStr fromFileSpec = Path::fileSpec(SrcDir,files[i]);
      if(!::CopyFile(fromFileSpec.c_str(),toFileSpec.c_str(),FailIfExists))
        ok = false;
    }
  }
  else
    ok = false;
  Directory::SetCurrentDirectory(CurrDir);
  return ok;
}

//----< convert string to lower case chars >---------------------------

stdStr Path::toLower(const stdStr& src)
{
  stdStr temp;
  for(size_t i=0; i<src.length(); ++i)
    temp += tolower(src[i]);
  return temp;
}
//----< convert string to upper case chars >---------------------------

stdStr Path::toUpper(const stdStr& src)
{
  stdStr temp;
  for(size_t i=0; i<src.length(); ++i)
    temp += toupper(src[i]);
  return temp;
}
//----< convert from ANSII to Unicode >--------------------------------

std::wstring toUnicode(const stdStr& src)
{
  std::wstring temp;
  for(size_t i=0; i<src.length(); ++i)
    temp += static_cast<wchar_t>(src[i]);
  return temp;
}
//----< convert from Unicode to ANSII >--------------------------------

stdStr toANSII(const std::wstring& src)
{
  stdStr temp;
  for(size_t i=0; i<src.length(); ++i)
    temp += static_cast<char>(src[i]);
  return temp;
}

//----< get path from fileSpec >---------------------------------------

stdStr Path::getName(const stdStr &fileSpec)
{
  size_t pos = fileSpec.find_last_of(TEXT("/"));
  if(pos >= fileSpec.length())
    pos = fileSpec.find_last_of(TEXT("\\"));
  if(pos >= fileSpec.length())
    return toLower(fileSpec);
  return toLower(fileSpec.substr(pos+1,fileSpec.length()-pos));
}
//----< get extension from fileSpec >----------------------------------

stdStr Path::getExt(const stdStr& fileSpec)
{
  size_t pos = fileSpec.find_last_of(TEXT("."));
  if(pos < fileSpec.length())
    return toLower(fileSpec.substr(pos+1,fileSpec.length()-pos));
  return TEXT("");
}
//----< get path from fileSpec >---------------------------------------

stdStr Path::getPath(const stdStr &fileSpec)
{
  size_t pos = fileSpec.find_last_of(TEXT("/"));
  if(pos >= fileSpec.length())
    pos = fileSpec.find_last_of(TEXT("\\"));
  if(pos >= fileSpec.length())
    return TEXT(".");
  if(fileSpec.find(TEXT("."),pos+1))
    return toLower(fileSpec.substr(0,pos+1));
  return fileSpec;
}
//----< get absoluth path from fileSpec >------------------------------

stdStr Path::getFullPath(const stdStr &fileSpec)
{
  const size_t BufSize = 256;
  TCHAR buffer[BufSize];
  TCHAR filebuffer[BufSize];  // don't use but GetFullPathName will
  TCHAR* name = filebuffer;
  ::GetFullPathName(fileSpec.c_str(),BufSize, buffer, &name);
  return stdStr(buffer);
}

//----< create file spec from path and name >--------------------------

stdStr Path::fileSpec(const stdStr &path, const stdStr &name)
{
  stdStr fs;
  size_t len = path.size();
  if(path[len-1] == '/' || path[len-1] == '\\')
    fs = path + name;
  else
  {
    if(path.find(TEXT("/")) < path.size())
      fs = path + TEXT("/") + name;
    else if(path.find(TEXT("\\")) < path.size())
      fs = path + TEXT("\\") + name;
  }
  return fs;
}

//----< throw exception string >---------------------------------------

void SystemError::ThrowString(const stdStr msg, const stdStr file, int line) {

  stdOstringstream collect;
  collect << msg << TEXT(": ") << GetLastMsg()
          << TEXT("  file: ") << file 
          << TEXT(", line: ") << line;
  throw collect.str();
}
//----< get system error message string >----------------------

stdStr SystemError::GetLastMsg() {

// ask system what type of error occurred

  DWORD errorCode = GetLastError();
  if(errorCode == 0)
    return TEXT("no error");

// map errorCode into a system defined error string
    
  DWORD dwFlags = 
    FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_ALLOCATE_BUFFER;
  LPCVOID lpSource = NULL;
  DWORD dwMessageID = errorCode;
  DWORD dwLanguageId = MAKELANGID(LANG_ENGLISH,SUBLANG_ENGLISH_US);
  TCHAR* lpBuffer;
  DWORD nSize = 0;
  va_list *Arguments = NULL;

  FormatMessage(
    dwFlags,lpSource,dwMessageID,dwLanguageId, 
    (TCHAR*)&lpBuffer,nSize,Arguments
  );

  _msg = lpBuffer;
  LocalFree(lpBuffer);
  return _msg;
}

//----< save a path for reading files >------------------------------

void FileHandler::setReadPath(const stdStr& path)
{
  _ReadPath = path;
}
//----< save a path for writing files >------------------------------

void FileHandler::setWritePath(const stdStr& path)
{
  _WritePath = path;
}
//----< open file for shared reading >-------------------------------

bool FileHandler::openFileReader(const stdStr& file)
{
  stdStr _file(_ReadPath);
  _file.append(TEXT("/"));
  _file.append(file);
  _hReadFile = CreateFile(
                           _file.c_str(),GENERIC_READ,
                           FILE_SHARE_READ,NULL,OPEN_EXISTING,
                           FILE_FLAG_SEQUENTIAL_SCAN,NULL
                         );
  if(_hReadFile != INVALID_HANDLE_VALUE)
  {
    return true;
  }
  return false;
}
//----< open file for writing >--------------------------------------

bool FileHandler::openFileWriter(const stdStr& file)
{
  stdStr _file(_WritePath);
  _file.append(TEXT("/"));
  _file.append(file);
  _hWriteFile = CreateFile(
                            _file.c_str(),GENERIC_WRITE,
                            0,NULL,CREATE_ALWAYS,
                            FILE_FLAG_SEQUENTIAL_SCAN,NULL
                          );
  if(_hWriteFile != INVALID_HANDLE_VALUE)
  {
    return true;
  }
  return false;
}

//----< read block of bytes from file, returning number read >-------

size_t FileHandler::getBlock(byte_* pBlock, size_t size)
{
  DWORD numBytesRead;
  ::ReadFile(_hReadFile,pBlock,(DWORD)size,&numBytesRead,NULL);
  return (size_t)numBytesRead;
}
//----< write block of bytes to file, returning number written >-----

size_t FileHandler::putBlock(byte_* pBlock, size_t size)
{
  DWORD numBytesWritten;
  ::WriteFile(_hWriteFile,pBlock,(DWORD)size,&numBytesWritten,NULL);
  return (size_t)numBytesWritten;
}
//----< close FileReader >-------------------------------------------

void FileHandler::closeFileReader()
{
  CloseHandle(_hReadFile);
}
//----< close FileWriter >-------------------------------------------

void FileHandler::closeFileWriter()
{
  
  CloseHandle(_hWriteFile);
}
//----< convert block of bytes to a string >-------------------------

stdStr FileHandler::blockToString(byte_* pBlock, size_t size)
{
  stdStr temp;
  for(size_t i=0; i<size; ++i)
    temp += static_cast<char>(pBlock[i]);
  return temp;
}


// The FileCollection function gets the files in the current directory
// Hence from all the files, the .xml files are stored in a vector 
void Directory::FileCollection(stdStr& direc)
{
  stdStr path = Path::getFullPath(direc);
  std::vector<stdStr> xmlfiles = Directory::GetFiles(TEXT("*.xml"));
  std::cout << "\n  XML files in this directory are:";
  for(size_t i=0; i<xmlfiles.size(); ++i)
  stdOut << TEXT("\n    ") << xmlfiles[i];
  for(size_t i=0; i<xmlfiles.size(); ++i)
     {
	 size_t position;
	 stdStr ztring = xmlfiles[i];
	 stdStr head = TEXT("."); 
	 position = ztring.find(head);
	 stdStr newString ;
	 newString = ztring.substr(0,position);
	 xfiles.push_back(newString);
	}
}

/*

//----< test stub >----------------------------------------------------

#include <iostream>

int main() {

  stdOut << "\n  Testing WinTools ";
  stdOut << "\n ==================\n";

  SystemError se;
  stdOut << TEXT("\n  Last error code = ") << ::GetLastError();
  stdOut << TEXT("\n  Last error message = ") << se.GetLastMsg();
  stdOut << std::endl;

  std::cout << "\n  testing directory management ";
  std::cout << "\n ------------------------------";

  Directory dir;
  stdOut << TEXT("\n  Current directory is: ") << dir.GetCurrentDirectory();
  std::cout << std::endl;

  std::vector<stdStr> cppfiles = Directory::GetFiles(TEXT("*.cpp"));
  std::cout << "\n  cpp files in this directory are:";
  for(size_t i=0; i<cppfiles.size(); ++i)
    stdOut << TEXT("\n    ") << cppfiles[i];
  std::cout << std::endl;

  std::vector<stdStr> headerfiles = Directory::GetFiles(TEXT("*.h"));
  std::cout << "\n header files in this directory are:";
  for(size_t i=0; i<headerfiles.size(); ++i)
    stdOut << TEXT("\n    ") << headerfiles[i];
  std::cout << std::endl;
   std::vector<stdStr> hfiles;
   	 std::vector<stdStr> cfiles;
   for(size_t i=0; i<headerfiles.size(); ++i)
   {
	 size_t position;
	 stdStr ztring = headerfiles[i];
	 stdStr head = TEXT("."); 
	 position = ztring.find(head);
	
	 stdStr newString ;
	 newString = ztring.substr(0,position);
	 hfiles.push_back(newString);

     }
   for(size_t i=0; i<cppfiles.size(); ++i)
   {
	 size_t position;
	 stdStr ztring = headerfiles[i];
	 stdStr cead = TEXT("."); 
	 position = ztring.find(cead);

	 stdStr nwString ;
	 nwString = ztring.substr(0,position);
	 cfiles.push_back(nwString);

     }

  for(size_t i=0;i<hfiles.size();++i)
  {
	  for(size_t j=0;j<cfiles.size();++j)
	  {
	  if(hfiles[i]==cfiles[j])
	  {
		 std::cout<<"\n this is a package";
	  }
	  }
  }

  }*/

