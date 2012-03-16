// $ANTLR 3.1.3 Mar 18, 2009 10:09:25 Query.g 2011-12-09 13:28:44


using edu.syr.cse784.eskimodb.rootserver;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public class QueryLexer : Lexer {
    public const int T__29 = 29;
    public const int T__28 = 28;
    public const int T__27 = 27;
    public const int T__26 = 26;
    public const int T__25 = 25;
    public const int T__24 = 24;
    public const int T__23 = 23;
    public const int T__22 = 22;
    public const int T__21 = 21;
    public const int T__20 = 20;
    public const int EOF = -1;
    public const int T__9 = 9;
    public const int T__8 = 8;
    public const int T__7 = 7;
    public const int T__93 = 93;
    public const int T__19 = 19;
    public const int T__94 = 94;
    public const int T__91 = 91;
    public const int T__92 = 92;
    public const int NAME = 4;
    public const int T__16 = 16;
    public const int T__90 = 90;
    public const int T__15 = 15;
    public const int T__18 = 18;
    public const int T__17 = 17;
    public const int T__12 = 12;
    public const int T__11 = 11;
    public const int T__14 = 14;
    public const int T__13 = 13;
    public const int T__10 = 10;
    public const int T__99 = 99;
    public const int T__98 = 98;
    public const int T__97 = 97;
    public const int T__96 = 96;
    public const int T__95 = 95;
    public const int T__80 = 80;
    public const int T__81 = 81;
    public const int T__82 = 82;
    public const int T__83 = 83;
    public const int NUMBER = 5;
    public const int WHITESPACE = 6;
    public const int T__85 = 85;
    public const int T__84 = 84;
    public const int T__87 = 87;
    public const int T__86 = 86;
    public const int T__89 = 89;
    public const int T__88 = 88;
    public const int T__71 = 71;
    public const int T__72 = 72;
    public const int T__70 = 70;
    public const int T__76 = 76;
    public const int T__75 = 75;
    public const int T__74 = 74;
    public const int T__73 = 73;
    public const int T__79 = 79;
    public const int T__78 = 78;
    public const int T__77 = 77;
    public const int T__68 = 68;
    public const int T__69 = 69;
    public const int T__66 = 66;
    public const int T__67 = 67;
    public const int T__64 = 64;
    public const int T__65 = 65;
    public const int T__62 = 62;
    public const int T__63 = 63;
    public const int T__61 = 61;
    public const int T__60 = 60;
    public const int T__55 = 55;
    public const int T__56 = 56;
    public const int T__57 = 57;
    public const int T__58 = 58;
    public const int T__51 = 51;
    public const int T__52 = 52;
    public const int T__53 = 53;
    public const int T__54 = 54;
    public const int T__59 = 59;
    public const int T__50 = 50;
    public const int T__42 = 42;
    public const int T__43 = 43;
    public const int T__40 = 40;
    public const int T__41 = 41;
    public const int T__46 = 46;
    public const int T__47 = 47;
    public const int T__44 = 44;
    public const int T__45 = 45;
    public const int T__48 = 48;
    public const int T__49 = 49;
    public const int T__102 = 102;
    public const int T__101 = 101;
    public const int T__100 = 100;
    public const int T__30 = 30;
    public const int T__31 = 31;
    public const int T__32 = 32;
    public const int T__33 = 33;
    public const int T__34 = 34;
    public const int T__35 = 35;
    public const int T__36 = 36;
    public const int T__37 = 37;
    public const int T__38 = 38;
    public const int T__39 = 39;

    // delegates
    // delegators

    public QueryLexer() 
    {
		InitializeCyclicDFAs();
    }
    public QueryLexer(ICharStream input)
		: this(input, null) {
    }
    public QueryLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "Query.g";} 
    }

    // $ANTLR start "T__7"
    public void mT__7() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__7;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:11:6: ( 'create table' )
            // Query.g:11:8: 'create table'
            {
            	Match("create table"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__7"

    // $ANTLR start "T__8"
    public void mT__8() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__8;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:12:6: ( 'CREATE TABLE' )
            // Query.g:12:8: 'CREATE TABLE'
            {
            	Match("CREATE TABLE"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__8"

    // $ANTLR start "T__9"
    public void mT__9() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__9;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:13:6: ( '(' )
            // Query.g:13:8: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__9"

    // $ANTLR start "T__10"
    public void mT__10() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__10;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:14:7: ( ');' )
            // Query.g:14:9: ');'
            {
            	Match(");"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__10"

    // $ANTLR start "T__11"
    public void mT__11() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__11;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:15:7: ( ',' )
            // Query.g:15:9: ','
            {
            	Match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__11"

    // $ANTLR start "T__12"
    public void mT__12() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__12;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:16:7: ( 'primary key' )
            // Query.g:16:9: 'primary key'
            {
            	Match("primary key"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__12"

    // $ANTLR start "T__13"
    public void mT__13() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__13;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:17:7: ( 'PRIMARY KEY' )
            // Query.g:17:9: 'PRIMARY KEY'
            {
            	Match("PRIMARY KEY"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__13"

    // $ANTLR start "T__14"
    public void mT__14() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__14;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:18:7: ( 'index' )
            // Query.g:18:9: 'index'
            {
            	Match("index"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__14"

    // $ANTLR start "T__15"
    public void mT__15() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__15;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:19:7: ( 'INDEX' )
            // Query.g:19:9: 'INDEX'
            {
            	Match("INDEX"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__15"

    // $ANTLR start "T__16"
    public void mT__16() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__16;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:20:7: ( 'char' )
            // Query.g:20:9: 'char'
            {
            	Match("char"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__16"

    // $ANTLR start "T__17"
    public void mT__17() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__17;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:21:7: ( 'CHAR' )
            // Query.g:21:9: 'CHAR'
            {
            	Match("CHAR"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__17"

    // $ANTLR start "T__18"
    public void mT__18() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__18;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:22:7: ( 'short' )
            // Query.g:22:9: 'short'
            {
            	Match("short"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__18"

    // $ANTLR start "T__19"
    public void mT__19() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__19;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:23:7: ( 'SHORT' )
            // Query.g:23:9: 'SHORT'
            {
            	Match("SHORT"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__19"

    // $ANTLR start "T__20"
    public void mT__20() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__20;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:24:7: ( ' int' )
            // Query.g:24:9: ' int'
            {
            	Match(" int"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__20"

    // $ANTLR start "T__21"
    public void mT__21() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__21;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:25:7: ( ' INT' )
            // Query.g:25:9: ' INT'
            {
            	Match(" INT"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__21"

    // $ANTLR start "T__22"
    public void mT__22() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__22;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:26:7: ( 'long' )
            // Query.g:26:9: 'long'
            {
            	Match("long"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__22"

    // $ANTLR start "T__23"
    public void mT__23() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__23;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:27:7: ( 'LONG' )
            // Query.g:27:9: 'LONG'
            {
            	Match("LONG"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__23"

    // $ANTLR start "T__24"
    public void mT__24() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__24;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:28:7: ( 'biglong' )
            // Query.g:28:9: 'biglong'
            {
            	Match("biglong"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__24"

    // $ANTLR start "T__25"
    public void mT__25() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__25;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:29:7: ( 'BIGLONG' )
            // Query.g:29:9: 'BIGLONG'
            {
            	Match("BIGLONG"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__25"

    // $ANTLR start "T__26"
    public void mT__26() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__26;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:30:7: ( 'float' )
            // Query.g:30:9: 'float'
            {
            	Match("float"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__26"

    // $ANTLR start "T__27"
    public void mT__27() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__27;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:31:7: ( 'FLOAT' )
            // Query.g:31:9: 'FLOAT'
            {
            	Match("FLOAT"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__27"

    // $ANTLR start "T__28"
    public void mT__28() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__28;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:32:7: ( 'double' )
            // Query.g:32:9: 'double'
            {
            	Match("double"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__28"

    // $ANTLR start "T__29"
    public void mT__29() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__29;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:33:7: ( 'DOUBLE' )
            // Query.g:33:9: 'DOUBLE'
            {
            	Match("DOUBLE"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__29"

    // $ANTLR start "T__30"
    public void mT__30() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__30;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:34:7: ( 'VARCHAR(' )
            // Query.g:34:9: 'VARCHAR('
            {
            	Match("VARCHAR("); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__30"

    // $ANTLR start "T__31"
    public void mT__31() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__31;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:35:7: ( ')' )
            // Query.g:35:9: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__31"

    // $ANTLR start "T__32"
    public void mT__32() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__32;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:36:7: ( 'varchar(' )
            // Query.g:36:9: 'varchar('
            {
            	Match("varchar("); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__32"

    // $ANTLR start "T__33"
    public void mT__33() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__33;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:37:7: ( 'delete ' )
            // Query.g:37:9: 'delete '
            {
            	Match("delete "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__33"

    // $ANTLR start "T__34"
    public void mT__34() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__34;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:38:7: ( 'DELETE ' )
            // Query.g:38:9: 'DELETE '
            {
            	Match("DELETE "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__34"

    // $ANTLR start "T__35"
    public void mT__35() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__35;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:39:7: ( 'column ' )
            // Query.g:39:9: 'column '
            {
            	Match("column "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__35"

    // $ANTLR start "T__36"
    public void mT__36() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__36;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:40:7: ( 'COLUMN ' )
            // Query.g:40:9: 'COLUMN '
            {
            	Match("COLUMN "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__36"

    // $ANTLR start "T__37"
    public void mT__37() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__37;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:41:7: ( ' in ' )
            // Query.g:41:9: ' in '
            {
            	Match(" in "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__37"

    // $ANTLR start "T__38"
    public void mT__38() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__38;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:42:7: ( ' IN ' )
            // Query.g:42:9: ' IN '
            {
            	Match(" IN "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__38"

    // $ANTLR start "T__39"
    public void mT__39() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__39;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:43:7: ( 'table ' )
            // Query.g:43:9: 'table '
            {
            	Match("table "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__39"

    // $ANTLR start "T__40"
    public void mT__40() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__40;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:44:7: ( 'TABLE ' )
            // Query.g:44:9: 'TABLE '
            {
            	Match("TABLE "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__40"

    // $ANTLR start "T__41"
    public void mT__41() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__41;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:45:7: ( ';' )
            // Query.g:45:9: ';'
            {
            	Match(';'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__41"

    // $ANTLR start "T__42"
    public void mT__42() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__42;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:46:7: ( 'add ' )
            // Query.g:46:9: 'add '
            {
            	Match("add "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__42"

    // $ANTLR start "T__43"
    public void mT__43() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__43;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:47:7: ( 'ADD ' )
            // Query.g:47:9: 'ADD '
            {
            	Match("ADD "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__43"

    // $ANTLR start "T__44"
    public void mT__44() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__44;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:48:7: ( '.' )
            // Query.g:48:9: '.'
            {
            	Match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__44"

    // $ANTLR start "T__45"
    public void mT__45() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__45;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:49:7: ( 'create db ' )
            // Query.g:49:9: 'create db '
            {
            	Match("create db "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__45"

    // $ANTLR start "T__46"
    public void mT__46() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__46;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:50:7: ( 'CREATE DB ' )
            // Query.g:50:9: 'CREATE DB '
            {
            	Match("CREATE DB "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__46"

    // $ANTLR start "T__47"
    public void mT__47() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__47;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:51:7: ( 'select db ' )
            // Query.g:51:9: 'select db '
            {
            	Match("select db "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__47"

    // $ANTLR start "T__48"
    public void mT__48() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__48;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:52:7: ( 'SELECT DB ' )
            // Query.g:52:9: 'SELECT DB '
            {
            	Match("SELECT DB "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__48"

    // $ANTLR start "T__49"
    public void mT__49() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__49;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:53:7: ( 'delete db ' )
            // Query.g:53:9: 'delete db '
            {
            	Match("delete db "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__49"

    // $ANTLR start "T__50"
    public void mT__50() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__50;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:54:7: ( 'DELETE DB ' )
            // Query.g:54:9: 'DELETE DB '
            {
            	Match("DELETE DB "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__50"

    // $ANTLR start "T__51"
    public void mT__51() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__51;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:55:7: ( 'delete table ' )
            // Query.g:55:9: 'delete table '
            {
            	Match("delete table "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__51"

    // $ANTLR start "T__52"
    public void mT__52() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__52;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:56:7: ( 'DELETE TABLE ' )
            // Query.g:56:9: 'DELETE TABLE '
            {
            	Match("DELETE TABLE "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__52"

    // $ANTLR start "T__53"
    public void mT__53() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__53;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:57:7: ( 'empty table ' )
            // Query.g:57:9: 'empty table '
            {
            	Match("empty table "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__53"

    // $ANTLR start "T__54"
    public void mT__54() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__54;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:58:7: ( 'EMPTY TABLE ' )
            // Query.g:58:9: 'EMPTY TABLE '
            {
            	Match("EMPTY TABLE "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__54"

    // $ANTLR start "T__55"
    public void mT__55() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__55;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:59:7: ( 'select ' )
            // Query.g:59:9: 'select '
            {
            	Match("select "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__55"

    // $ANTLR start "T__56"
    public void mT__56() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__56;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:60:7: ( 'SELECT ' )
            // Query.g:60:9: 'SELECT '
            {
            	Match("SELECT "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__56"

    // $ANTLR start "T__57"
    public void mT__57() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__57;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:61:7: ( ' from ' )
            // Query.g:61:9: ' from '
            {
            	Match(" from "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__57"

    // $ANTLR start "T__58"
    public void mT__58() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__58;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:62:7: ( ' FROM ' )
            // Query.g:62:9: ' FROM '
            {
            	Match(" FROM "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__58"

    // $ANTLR start "T__59"
    public void mT__59() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__59;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:63:7: ( '*' )
            // Query.g:63:9: '*'
            {
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__59"

    // $ANTLR start "T__60"
    public void mT__60() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__60;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:64:7: ( ', ' )
            // Query.g:64:9: ', '
            {
            	Match(", "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__60"

    // $ANTLR start "T__61"
    public void mT__61() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__61;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:65:7: ( ' WHERE ' )
            // Query.g:65:9: ' WHERE '
            {
            	Match(" WHERE "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__61"

    // $ANTLR start "T__62"
    public void mT__62() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__62;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:66:7: ( ' where ' )
            // Query.g:66:9: ' where '
            {
            	Match(" where "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__62"

    // $ANTLR start "T__63"
    public void mT__63() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__63;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:67:7: ( ' and ' )
            // Query.g:67:9: ' and '
            {
            	Match(" and "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__63"

    // $ANTLR start "T__64"
    public void mT__64() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__64;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:68:7: ( ' AND ' )
            // Query.g:68:9: ' AND '
            {
            	Match(" AND "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__64"

    // $ANTLR start "T__65"
    public void mT__65() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__65;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:69:7: ( '=' )
            // Query.g:69:9: '='
            {
            	Match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__65"

    // $ANTLR start "T__66"
    public void mT__66() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__66;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:70:7: ( '<' )
            // Query.g:70:9: '<'
            {
            	Match('<'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__66"

    // $ANTLR start "T__67"
    public void mT__67() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__67;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:71:7: ( '>' )
            // Query.g:71:9: '>'
            {
            	Match('>'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__67"

    // $ANTLR start "T__68"
    public void mT__68() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__68;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:72:7: ( '<=' )
            // Query.g:72:9: '<='
            {
            	Match("<="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__68"

    // $ANTLR start "T__69"
    public void mT__69() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__69;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:73:7: ( '>=' )
            // Query.g:73:9: '>='
            {
            	Match(">="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__69"

    // $ANTLR start "T__70"
    public void mT__70() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__70;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:74:7: ( ' = ' )
            // Query.g:74:9: ' = '
            {
            	Match(" = "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__70"

    // $ANTLR start "T__71"
    public void mT__71() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__71;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:75:7: ( ' < ' )
            // Query.g:75:9: ' < '
            {
            	Match(" < "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__71"

    // $ANTLR start "T__72"
    public void mT__72() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__72;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:76:7: ( ' > ' )
            // Query.g:76:9: ' > '
            {
            	Match(" > "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__72"

    // $ANTLR start "T__73"
    public void mT__73() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__73;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:77:7: ( ' <= ' )
            // Query.g:77:9: ' <= '
            {
            	Match(" <= "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__73"

    // $ANTLR start "T__74"
    public void mT__74() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__74;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:78:7: ( ' >= ' )
            // Query.g:78:9: ' >= '
            {
            	Match(" >= "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__74"

    // $ANTLR start "T__75"
    public void mT__75() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__75;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:79:7: ( ' order by ' )
            // Query.g:79:9: ' order by '
            {
            	Match(" order by "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__75"

    // $ANTLR start "T__76"
    public void mT__76() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__76;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:80:7: ( ' ORDER BY ' )
            // Query.g:80:9: ' ORDER BY '
            {
            	Match(" ORDER BY "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__76"

    // $ANTLR start "T__77"
    public void mT__77() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__77;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:81:7: ( ' asc' )
            // Query.g:81:9: ' asc'
            {
            	Match(" asc"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__77"

    // $ANTLR start "T__78"
    public void mT__78() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__78;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:82:7: ( ' ASC' )
            // Query.g:82:9: ' ASC'
            {
            	Match(" ASC"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__78"

    // $ANTLR start "T__79"
    public void mT__79() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__79;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:83:7: ( ' dsc' )
            // Query.g:83:9: ' dsc'
            {
            	Match(" dsc"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__79"

    // $ANTLR start "T__80"
    public void mT__80() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__80;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:84:7: ( ' DSC' )
            // Query.g:84:9: ' DSC'
            {
            	Match(" DSC"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__80"

    // $ANTLR start "T__81"
    public void mT__81() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__81;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:85:7: ( 'LIMIT' )
            // Query.g:85:9: 'LIMIT'
            {
            	Match("LIMIT"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__81"

    // $ANTLR start "T__82"
    public void mT__82() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__82;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:86:7: ( 'limit' )
            // Query.g:86:9: 'limit'
            {
            	Match("limit"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__82"

    // $ANTLR start "T__83"
    public void mT__83() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__83;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:87:7: ( ' , ' )
            // Query.g:87:9: ' , '
            {
            	Match(" , "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__83"

    // $ANTLR start "T__84"
    public void mT__84() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__84;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:88:7: ( 'COUNT(' )
            // Query.g:88:9: 'COUNT('
            {
            	Match("COUNT("); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__84"

    // $ANTLR start "T__85"
    public void mT__85() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__85;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:89:7: ( 'count(' )
            // Query.g:89:9: 'count('
            {
            	Match("count("); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__85"

    // $ANTLR start "T__86"
    public void mT__86() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__86;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:90:7: ( 'UPDATE' )
            // Query.g:90:9: 'UPDATE'
            {
            	Match("UPDATE"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__86"

    // $ANTLR start "T__87"
    public void mT__87() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__87;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:91:7: ( 'update' )
            // Query.g:91:9: 'update'
            {
            	Match("update"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__87"

    // $ANTLR start "T__88"
    public void mT__88() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__88;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:92:7: ( 'SET' )
            // Query.g:92:9: 'SET'
            {
            	Match("SET"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__88"

    // $ANTLR start "T__89"
    public void mT__89() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__89;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:93:7: ( 'set' )
            // Query.g:93:9: 'set'
            {
            	Match("set"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__89"

    // $ANTLR start "T__90"
    public void mT__90() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__90;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:94:7: ( 'AND' )
            // Query.g:94:9: 'AND'
            {
            	Match("AND"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__90"

    // $ANTLR start "T__91"
    public void mT__91() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__91;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:95:7: ( 'and' )
            // Query.g:95:9: 'and'
            {
            	Match("and"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__91"

    // $ANTLR start "T__92"
    public void mT__92() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__92;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:96:7: ( 'delete' )
            // Query.g:96:9: 'delete'
            {
            	Match("delete"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__92"

    // $ANTLR start "T__93"
    public void mT__93() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__93;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:97:7: ( 'DELETE' )
            // Query.g:97:9: 'DELETE'
            {
            	Match("DELETE"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__93"

    // $ANTLR start "T__94"
    public void mT__94() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__94;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:98:7: ( 'from' )
            // Query.g:98:9: 'from'
            {
            	Match("from"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__94"

    // $ANTLR start "T__95"
    public void mT__95() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__95;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:99:7: ( 'FROM' )
            // Query.g:99:9: 'FROM'
            {
            	Match("FROM"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__95"

    // $ANTLR start "T__96"
    public void mT__96() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__96;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:100:7: ( 'insert into' )
            // Query.g:100:9: 'insert into'
            {
            	Match("insert into"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__96"

    // $ANTLR start "T__97"
    public void mT__97() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__97;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:101:7: ( 'INSERT INTO' )
            // Query.g:101:9: 'INSERT INTO'
            {
            	Match("INSERT INTO"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__97"

    // $ANTLR start "T__98"
    public void mT__98() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__98;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:102:7: ( 'values' )
            // Query.g:102:9: 'values'
            {
            	Match("values"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__98"

    // $ANTLR start "T__99"
    public void mT__99() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__99;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:103:7: ( 'VALUES' )
            // Query.g:103:9: 'VALUES'
            {
            	Match("VALUES"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__99"

    // $ANTLR start "T__100"
    public void mT__100() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__100;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:104:8: ( 'rename ' )
            // Query.g:104:10: 'rename '
            {
            	Match("rename "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__100"

    // $ANTLR start "T__101"
    public void mT__101() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__101;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:105:8: ( 'RENAME ' )
            // Query.g:105:10: 'RENAME '
            {
            	Match("RENAME "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__101"

    // $ANTLR start "T__102"
    public void mT__102() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__102;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:106:8: ( ' TO ' )
            // Query.g:106:10: ' TO '
            {
            	Match(" TO "); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__102"

    // $ANTLR start "NAME"
    public void mNAME() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NAME;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:557:6: ( ( 'a' .. 'z' | 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' )* )
            // Query.g:557:8: ( 'a' .. 'z' | 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' )*
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// Query.g:557:27: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( ((LA1_0 >= '0' && LA1_0 <= '9') || (LA1_0 >= 'A' && LA1_0 <= 'Z') || (LA1_0 >= 'a' && LA1_0 <= 'z')) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // Query.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop1;
            	    }
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NAME"

    // $ANTLR start "NUMBER"
    public void mNUMBER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NUMBER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:558:8: ( ( '0' .. '9' ) ( '0' .. '9' )* )
            // Query.g:558:10: ( '0' .. '9' ) ( '0' .. '9' )*
            {
            	// Query.g:558:10: ( '0' .. '9' )
            	// Query.g:558:11: '0' .. '9'
            	{
            		MatchRange('0','9'); 

            	}

            	// Query.g:558:20: ( '0' .. '9' )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= '0' && LA2_0 <= '9')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // Query.g:558:21: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NUMBER"

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Query.g:559:12: ( ( ' ' | '\\t' | '\\n' | '\\r' )+ )
            // Query.g:559:14: ( ' ' | '\\t' | '\\n' | '\\r' )+
            {
            	// Query.g:559:14: ( ' ' | '\\t' | '\\n' | '\\r' )+
            	int cnt3 = 0;
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( ((LA3_0 >= '\t' && LA3_0 <= '\n') || LA3_0 == '\r' || LA3_0 == ' ') )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // Query.g:
            			    {
            			    	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || input.LA(1) == '\r' || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt3 >= 1 ) goto loop3;
            		            EarlyExitException eee3 =
            		                new EarlyExitException(3, input);
            		            throw eee3;
            	    }
            	    cnt3++;
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements

            	_channel = HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WHITESPACE"

    override public void mTokens() // throws RecognitionException 
    {
        // Query.g:1:8: ( T__7 | T__8 | T__9 | T__10 | T__11 | T__12 | T__13 | T__14 | T__15 | T__16 | T__17 | T__18 | T__19 | T__20 | T__21 | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | T__67 | T__68 | T__69 | T__70 | T__71 | T__72 | T__73 | T__74 | T__75 | T__76 | T__77 | T__78 | T__79 | T__80 | T__81 | T__82 | T__83 | T__84 | T__85 | T__86 | T__87 | T__88 | T__89 | T__90 | T__91 | T__92 | T__93 | T__94 | T__95 | T__96 | T__97 | T__98 | T__99 | T__100 | T__101 | T__102 | NAME | NUMBER | WHITESPACE )
        int alt4 = 99;
        alt4 = dfa4.Predict(input);
        switch (alt4) 
        {
            case 1 :
                // Query.g:1:10: T__7
                {
                	mT__7(); 

                }
                break;
            case 2 :
                // Query.g:1:15: T__8
                {
                	mT__8(); 

                }
                break;
            case 3 :
                // Query.g:1:20: T__9
                {
                	mT__9(); 

                }
                break;
            case 4 :
                // Query.g:1:25: T__10
                {
                	mT__10(); 

                }
                break;
            case 5 :
                // Query.g:1:31: T__11
                {
                	mT__11(); 

                }
                break;
            case 6 :
                // Query.g:1:37: T__12
                {
                	mT__12(); 

                }
                break;
            case 7 :
                // Query.g:1:43: T__13
                {
                	mT__13(); 

                }
                break;
            case 8 :
                // Query.g:1:49: T__14
                {
                	mT__14(); 

                }
                break;
            case 9 :
                // Query.g:1:55: T__15
                {
                	mT__15(); 

                }
                break;
            case 10 :
                // Query.g:1:61: T__16
                {
                	mT__16(); 

                }
                break;
            case 11 :
                // Query.g:1:67: T__17
                {
                	mT__17(); 

                }
                break;
            case 12 :
                // Query.g:1:73: T__18
                {
                	mT__18(); 

                }
                break;
            case 13 :
                // Query.g:1:79: T__19
                {
                	mT__19(); 

                }
                break;
            case 14 :
                // Query.g:1:85: T__20
                {
                	mT__20(); 

                }
                break;
            case 15 :
                // Query.g:1:91: T__21
                {
                	mT__21(); 

                }
                break;
            case 16 :
                // Query.g:1:97: T__22
                {
                	mT__22(); 

                }
                break;
            case 17 :
                // Query.g:1:103: T__23
                {
                	mT__23(); 

                }
                break;
            case 18 :
                // Query.g:1:109: T__24
                {
                	mT__24(); 

                }
                break;
            case 19 :
                // Query.g:1:115: T__25
                {
                	mT__25(); 

                }
                break;
            case 20 :
                // Query.g:1:121: T__26
                {
                	mT__26(); 

                }
                break;
            case 21 :
                // Query.g:1:127: T__27
                {
                	mT__27(); 

                }
                break;
            case 22 :
                // Query.g:1:133: T__28
                {
                	mT__28(); 

                }
                break;
            case 23 :
                // Query.g:1:139: T__29
                {
                	mT__29(); 

                }
                break;
            case 24 :
                // Query.g:1:145: T__30
                {
                	mT__30(); 

                }
                break;
            case 25 :
                // Query.g:1:151: T__31
                {
                	mT__31(); 

                }
                break;
            case 26 :
                // Query.g:1:157: T__32
                {
                	mT__32(); 

                }
                break;
            case 27 :
                // Query.g:1:163: T__33
                {
                	mT__33(); 

                }
                break;
            case 28 :
                // Query.g:1:169: T__34
                {
                	mT__34(); 

                }
                break;
            case 29 :
                // Query.g:1:175: T__35
                {
                	mT__35(); 

                }
                break;
            case 30 :
                // Query.g:1:181: T__36
                {
                	mT__36(); 

                }
                break;
            case 31 :
                // Query.g:1:187: T__37
                {
                	mT__37(); 

                }
                break;
            case 32 :
                // Query.g:1:193: T__38
                {
                	mT__38(); 

                }
                break;
            case 33 :
                // Query.g:1:199: T__39
                {
                	mT__39(); 

                }
                break;
            case 34 :
                // Query.g:1:205: T__40
                {
                	mT__40(); 

                }
                break;
            case 35 :
                // Query.g:1:211: T__41
                {
                	mT__41(); 

                }
                break;
            case 36 :
                // Query.g:1:217: T__42
                {
                	mT__42(); 

                }
                break;
            case 37 :
                // Query.g:1:223: T__43
                {
                	mT__43(); 

                }
                break;
            case 38 :
                // Query.g:1:229: T__44
                {
                	mT__44(); 

                }
                break;
            case 39 :
                // Query.g:1:235: T__45
                {
                	mT__45(); 

                }
                break;
            case 40 :
                // Query.g:1:241: T__46
                {
                	mT__46(); 

                }
                break;
            case 41 :
                // Query.g:1:247: T__47
                {
                	mT__47(); 

                }
                break;
            case 42 :
                // Query.g:1:253: T__48
                {
                	mT__48(); 

                }
                break;
            case 43 :
                // Query.g:1:259: T__49
                {
                	mT__49(); 

                }
                break;
            case 44 :
                // Query.g:1:265: T__50
                {
                	mT__50(); 

                }
                break;
            case 45 :
                // Query.g:1:271: T__51
                {
                	mT__51(); 

                }
                break;
            case 46 :
                // Query.g:1:277: T__52
                {
                	mT__52(); 

                }
                break;
            case 47 :
                // Query.g:1:283: T__53
                {
                	mT__53(); 

                }
                break;
            case 48 :
                // Query.g:1:289: T__54
                {
                	mT__54(); 

                }
                break;
            case 49 :
                // Query.g:1:295: T__55
                {
                	mT__55(); 

                }
                break;
            case 50 :
                // Query.g:1:301: T__56
                {
                	mT__56(); 

                }
                break;
            case 51 :
                // Query.g:1:307: T__57
                {
                	mT__57(); 

                }
                break;
            case 52 :
                // Query.g:1:313: T__58
                {
                	mT__58(); 

                }
                break;
            case 53 :
                // Query.g:1:319: T__59
                {
                	mT__59(); 

                }
                break;
            case 54 :
                // Query.g:1:325: T__60
                {
                	mT__60(); 

                }
                break;
            case 55 :
                // Query.g:1:331: T__61
                {
                	mT__61(); 

                }
                break;
            case 56 :
                // Query.g:1:337: T__62
                {
                	mT__62(); 

                }
                break;
            case 57 :
                // Query.g:1:343: T__63
                {
                	mT__63(); 

                }
                break;
            case 58 :
                // Query.g:1:349: T__64
                {
                	mT__64(); 

                }
                break;
            case 59 :
                // Query.g:1:355: T__65
                {
                	mT__65(); 

                }
                break;
            case 60 :
                // Query.g:1:361: T__66
                {
                	mT__66(); 

                }
                break;
            case 61 :
                // Query.g:1:367: T__67
                {
                	mT__67(); 

                }
                break;
            case 62 :
                // Query.g:1:373: T__68
                {
                	mT__68(); 

                }
                break;
            case 63 :
                // Query.g:1:379: T__69
                {
                	mT__69(); 

                }
                break;
            case 64 :
                // Query.g:1:385: T__70
                {
                	mT__70(); 

                }
                break;
            case 65 :
                // Query.g:1:391: T__71
                {
                	mT__71(); 

                }
                break;
            case 66 :
                // Query.g:1:397: T__72
                {
                	mT__72(); 

                }
                break;
            case 67 :
                // Query.g:1:403: T__73
                {
                	mT__73(); 

                }
                break;
            case 68 :
                // Query.g:1:409: T__74
                {
                	mT__74(); 

                }
                break;
            case 69 :
                // Query.g:1:415: T__75
                {
                	mT__75(); 

                }
                break;
            case 70 :
                // Query.g:1:421: T__76
                {
                	mT__76(); 

                }
                break;
            case 71 :
                // Query.g:1:427: T__77
                {
                	mT__77(); 

                }
                break;
            case 72 :
                // Query.g:1:433: T__78
                {
                	mT__78(); 

                }
                break;
            case 73 :
                // Query.g:1:439: T__79
                {
                	mT__79(); 

                }
                break;
            case 74 :
                // Query.g:1:445: T__80
                {
                	mT__80(); 

                }
                break;
            case 75 :
                // Query.g:1:451: T__81
                {
                	mT__81(); 

                }
                break;
            case 76 :
                // Query.g:1:457: T__82
                {
                	mT__82(); 

                }
                break;
            case 77 :
                // Query.g:1:463: T__83
                {
                	mT__83(); 

                }
                break;
            case 78 :
                // Query.g:1:469: T__84
                {
                	mT__84(); 

                }
                break;
            case 79 :
                // Query.g:1:475: T__85
                {
                	mT__85(); 

                }
                break;
            case 80 :
                // Query.g:1:481: T__86
                {
                	mT__86(); 

                }
                break;
            case 81 :
                // Query.g:1:487: T__87
                {
                	mT__87(); 

                }
                break;
            case 82 :
                // Query.g:1:493: T__88
                {
                	mT__88(); 

                }
                break;
            case 83 :
                // Query.g:1:499: T__89
                {
                	mT__89(); 

                }
                break;
            case 84 :
                // Query.g:1:505: T__90
                {
                	mT__90(); 

                }
                break;
            case 85 :
                // Query.g:1:511: T__91
                {
                	mT__91(); 

                }
                break;
            case 86 :
                // Query.g:1:517: T__92
                {
                	mT__92(); 

                }
                break;
            case 87 :
                // Query.g:1:523: T__93
                {
                	mT__93(); 

                }
                break;
            case 88 :
                // Query.g:1:529: T__94
                {
                	mT__94(); 

                }
                break;
            case 89 :
                // Query.g:1:535: T__95
                {
                	mT__95(); 

                }
                break;
            case 90 :
                // Query.g:1:541: T__96
                {
                	mT__96(); 

                }
                break;
            case 91 :
                // Query.g:1:547: T__97
                {
                	mT__97(); 

                }
                break;
            case 92 :
                // Query.g:1:553: T__98
                {
                	mT__98(); 

                }
                break;
            case 93 :
                // Query.g:1:559: T__99
                {
                	mT__99(); 

                }
                break;
            case 94 :
                // Query.g:1:565: T__100
                {
                	mT__100(); 

                }
                break;
            case 95 :
                // Query.g:1:572: T__101
                {
                	mT__101(); 

                }
                break;
            case 96 :
                // Query.g:1:579: T__102
                {
                	mT__102(); 

                }
                break;
            case 97 :
                // Query.g:1:586: NAME
                {
                	mNAME(); 

                }
                break;
            case 98 :
                // Query.g:1:591: NUMBER
                {
                	mNUMBER(); 

                }
                break;
            case 99 :
                // Query.g:1:598: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;

        }

    }


    protected DFA4 dfa4;
	private void InitializeCyclicDFAs()
	{
	    this.dfa4 = new DFA4(this);
	}

    const string DFA4_eotS =
        "\x01\uffff\x02\x27\x01\uffff\x01\x31\x01\x33\x06\x27\x01\x29\x0c"+
        "\x27\x01\uffff\x02\x27\x01\uffff\x02\x27\x02\uffff\x01\x66\x01\x68"+
        "\x04\x27\x03\uffff\x06\x27\x04\uffff\x08\x27\x11\uffff\x18\x27\x04"+
        "\uffff\x14\x27\x01\u00b9\x02\x27\x01\u00bc\x0a\uffff\x15\x27\x01"+
        "\u00d6\x01\x27\x01\u00d8\x07\x27\x01\u00e0\x03\x27\x01\u00e4\x0a"+
        "\x27\x01\uffff\x02\x27\x05\uffff\x01\u00f1\x01\x27\x01\u00f3\x04"+
        "\x27\x01\u00f8\x01\x27\x01\u00fa\x0a\x27\x04\uffff\x07\x27\x01\uffff"+
        "\x03\x27\x01\uffff\x04\x27\x01\u0113\x01\x27\x01\u0115\x01\x27\x01"+
        "\u0117\x01\x27\x01\u0119\x01\x27\x01\uffff\x01\u011b\x01\uffff\x01"+
        "\u011c\x02\x27\x01\u011f\x01\uffff\x01\u0120\x01\uffff\x12\x27\x01"+
        "\uffff\x02\x27\x01\uffff\x02\x27\x01\uffff\x01\x27\x01\uffff\x01"+
        "\x27\x01\uffff\x01\x27\x01\uffff\x01\x27\x02\uffff\x02\x27\x02\uffff"+
        "\x01\u013d\x01\u013f\x01\u0140\x01\u0142\x01\x27\x01\u0144\x01\x27"+
        "\x01\u0146\x04\uffff\x01\u0147\x01\u0148\x02\x27\x04\uffff\x02\x27"+
        "\x02\uffff\x01\u0152\x01\u0154\x01\u0155\x01\u0156\x01\uffff\x01"+
        "\u0159\x02\uffff\x01\u015c\x01\uffff\x01\x27\x01\uffff\x01\x27\x19"+
        "\uffff";
    const string DFA4_eofS =
        "\u015f\uffff";
    const string DFA4_minS =
        "\x01\x09\x01\x68\x01\x48\x01\uffff\x01\x3b\x01\x20\x01\x72\x01"+
        "\x52\x01\x6e\x01\x4e\x01\x65\x01\x45\x01\x2c\x01\x69\x01\x49\x01"+
        "\x69\x01\x49\x01\x6c\x01\x4c\x01\x65\x01\x45\x01\x41\x02\x61\x01"+
        "\x41\x01\uffff\x01\x64\x01\x44\x01\uffff\x01\x6d\x01\x4d\x02\uffff"+
        "\x02\x3d\x01\x50\x01\x70\x01\x65\x01\x45\x03\uffff\x01\x65\x01\x61"+
        "\x01\x6c\x01\x45\x01\x41\x01\x4c\x04\uffff\x01\x69\x01\x49\x01\x64"+
        "\x01\x44\x01\x6f\x01\x6c\x01\x4f\x01\x4c\x01\x6e\x01\x4e\x04\uffff"+
        "\x01\x6e\x01\x4e\x01\uffff\x02\x20\x06\uffff\x01\x6e\x01\x6d\x01"+
        "\x4e\x01\x4d\x01\x67\x01\x47\x02\x6f\x02\x4f\x01\x75\x01\x6c\x01"+
        "\x55\x02\x4c\x01\x6c\x01\x62\x01\x42\x02\x64\x02\x44\x01\x70\x01"+
        "\x50\x04\uffff\x01\x44\x01\x64\x01\x6e\x01\x4e\x01\x61\x01\x72\x01"+
        "\x75\x01\x6e\x01\x41\x01\x52\x01\x55\x01\x4e\x01\x6d\x01\x4d\x02"+
        "\x65\x02\x45\x01\x72\x01\x65\x01\x30\x01\x52\x01\x45\x01\x30\x02"+
        "\x20\x08\uffff\x01\x67\x01\x69\x01\x47\x01\x49\x01\x6c\x01\x4c\x01"+
        "\x61\x01\x6d\x01\x41\x01\x4d\x01\x62\x01\x65\x01\x42\x01\x45\x01"+
        "\x43\x01\x55\x01\x63\x01\x75\x01\x6c\x01\x4c\x01\x20\x01\x30\x01"+
        "\x20\x01\x30\x01\x74\x01\x54\x01\x41\x02\x61\x01\x41\x01\x74\x01"+
        "\x30\x01\x6d\x01\x74\x01\x54\x01\x30\x01\x4d\x01\x54\x01\x61\x01"+
        "\x41\x01\x78\x01\x72\x01\x58\x01\x52\x01\x74\x01\x63\x01\uffff\x01"+
        "\x54\x01\x43\x05\uffff\x01\x30\x01\x74\x01\x30\x01\x54\x01\x6f\x01"+
        "\x4f\x01\x74\x01\x30\x01\x54\x01\x30\x01\x6c\x01\x74\x01\x4c\x01"+
        "\x54\x01\x48\x01\x45\x01\x68\x02\x65\x01\x45\x04\uffff\x01\x79\x01"+
        "\x59\x01\x54\x01\x74\x01\x6d\x01\x4d\x01\x65\x01\uffff\x01\x6e\x01"+
        "\x28\x01\x45\x01\uffff\x01\x4e\x01\x28\x01\x72\x01\x52\x01\x30\x01"+
        "\x74\x01\x30\x01\x54\x01\x30\x01\x74\x01\x30\x01\x54\x01\uffff\x01"+
        "\x30\x01\uffff\x01\x30\x01\x6e\x01\x4e\x01\x30\x01\uffff\x01\x30"+
        "\x01\uffff\x02\x65\x02\x45\x01\x41\x01\x53\x01\x61\x01\x73\x04\x20"+
        "\x01\x45\x02\x65\x01\x45\x02\x20\x01\uffff\x02\x20\x01\uffff\x01"+
        "\x79\x01\x59\x01\uffff\x01\x20\x01\uffff\x01\x20\x01\uffff\x01\x20"+
        "\x01\uffff\x01\x20\x02\uffff\x01\x67\x01\x47\x02\uffff\x01\x30\x01"+
        "\x20\x01\x30\x01\x20\x01\x52\x01\x30\x01\x72\x01\x30\x04\uffff\x02"+
        "\x30\x02\x20\x01\x64\x01\uffff\x01\x44\x01\uffff\x02\x20\x02\uffff"+
        "\x01\x64\x01\x44\x02\x30\x01\uffff\x01\x64\x02\uffff\x01\x44\x01"+
        "\uffff\x01\x28\x01\uffff\x01\x28\x19\uffff";
    const string DFA4_maxS =
        "\x01\x7a\x01\x72\x01\x52\x01\uffff\x01\x3b\x01\x20\x01\x72\x01"+
        "\x52\x01\x6e\x01\x4e\x01\x68\x01\x48\x01\x77\x01\x6f\x01\x4f\x01"+
        "\x69\x01\x49\x01\x72\x01\x52\x01\x6f\x01\x4f\x01\x41\x02\x61\x01"+
        "\x41\x01\uffff\x01\x6e\x01\x4e\x01\uffff\x01\x6d\x01\x4d\x02\uffff"+
        "\x02\x3d\x01\x50\x01\x70\x01\x65\x01\x45\x03\uffff\x01\x65\x01\x61"+
        "\x01\x75\x01\x45\x01\x41\x01\x55\x04\uffff\x01\x69\x01\x49\x01\x73"+
        "\x01\x53\x01\x6f\x01\x74\x01\x4f\x01\x54\x01\x6e\x01\x4e\x04\uffff"+
        "\x01\x73\x01\x53\x01\uffff\x02\x3d\x06\uffff\x01\x6e\x01\x6d\x01"+
        "\x4e\x01\x4d\x01\x67\x01\x47\x02\x6f\x02\x4f\x01\x75\x01\x6c\x01"+
        "\x55\x01\x4c\x01\x52\x01\x72\x01\x62\x01\x42\x02\x64\x02\x44\x01"+
        "\x70\x01\x50\x04\uffff\x01\x44\x01\x64\x01\x6e\x01\x4e\x01\x61\x01"+
        "\x72\x01\x75\x01\x6e\x01\x41\x01\x52\x01\x55\x01\x4e\x01\x6d\x01"+
        "\x4d\x02\x65\x02\x45\x01\x72\x01\x65\x01\x7a\x01\x52\x01\x45\x01"+
        "\x7a\x01\x74\x01\x54\x08\uffff\x01\x67\x01\x69\x01\x47\x01\x49\x01"+
        "\x6c\x01\x4c\x01\x61\x01\x6d\x01\x41\x01\x4d\x01\x62\x01\x65\x01"+
        "\x42\x01\x45\x01\x43\x01\x55\x01\x63\x01\x75\x01\x6c\x01\x4c\x01"+
        "\x20\x01\x7a\x01\x20\x01\x7a\x01\x74\x01\x54\x01\x41\x02\x61\x01"+
        "\x41\x01\x74\x01\x7a\x01\x6d\x01\x74\x01\x54\x01\x7a\x01\x4d\x01"+
        "\x54\x01\x61\x01\x41\x01\x78\x01\x72\x01\x58\x01\x52\x01\x74\x01"+
        "\x63\x01\uffff\x01\x54\x01\x43\x05\uffff\x01\x7a\x01\x74\x01\x7a"+
        "\x01\x54\x01\x6f\x01\x4f\x01\x74\x01\x7a\x01\x54\x01\x7a\x01\x6c"+
        "\x01\x74\x01\x4c\x01\x54\x01\x48\x01\x45\x01\x68\x02\x65\x01\x45"+
        "\x04\uffff\x01\x79\x01\x59\x01\x54\x01\x74\x01\x6d\x01\x4d\x01\x65"+
        "\x01\uffff\x01\x6e\x01\x28\x01\x45\x01\uffff\x01\x4e\x01\x28\x01"+
        "\x72\x01\x52\x01\x7a\x01\x74\x01\x7a\x01\x54\x01\x7a\x01\x74\x01"+
        "\x7a\x01\x54\x01\uffff\x01\x7a\x01\uffff\x01\x7a\x01\x6e\x01\x4e"+
        "\x01\x7a\x01\uffff\x01\x7a\x01\uffff\x02\x65\x02\x45\x01\x41\x01"+
        "\x53\x01\x61\x01\x73\x04\x20\x01\x45\x02\x65\x01\x45\x02\x20\x01"+
        "\uffff\x02\x20\x01\uffff\x01\x79\x01\x59\x01\uffff\x01\x20\x01\uffff"+
        "\x01\x20\x01\uffff\x01\x20\x01\uffff\x01\x20\x02\uffff\x01\x67\x01"+
        "\x47\x02\uffff\x04\x7a\x01\x52\x01\x7a\x01\x72\x01\x7a\x04\uffff"+
        "\x02\x7a\x02\x20\x01\x74\x01\uffff\x01\x54\x01\uffff\x02\x20\x02"+
        "\uffff\x01\x64\x01\x44\x02\x7a\x01\uffff\x01\x74\x02\uffff\x01\x54"+
        "\x01\uffff\x01\x28\x01\uffff\x01\x28\x19\uffff";
    const string DFA4_acceptS =
        "\x03\uffff\x01\x03\x15\uffff\x01\x23\x02\uffff\x01\x26\x02\uffff"+
        "\x01\x35\x01\x3b\x06\uffff\x01\x61\x01\x62\x01\x63\x06\uffff\x01"+
        "\x04\x01\x19\x01\x36\x01\x05\x0a\uffff\x01\x33\x01\x34\x01\x37\x01"+
        "\x38\x02\uffff\x01\x40\x02\uffff\x01\x45\x01\x46\x01\x49\x01\x4a"+
        "\x01\x4d\x01\x60\x18\uffff\x01\x3e\x01\x3c\x01\x3f\x01\x3d\x1a\uffff"+
        "\x01\x39\x01\x47\x01\x3a\x01\x48\x01\x41\x01\x43\x01\x42\x01\x44"+
        "\x2e\uffff\x01\x53\x02\uffff\x01\x52\x01\x0e\x01\x1f\x01\x0f\x01"+
        "\x20\x14\uffff\x01\x24\x01\x55\x01\x25\x01\x54\x07\uffff\x01\x0a"+
        "\x03\uffff\x01\x0b\x0c\uffff\x01\x10\x01\uffff\x01\x11\x04\uffff"+
        "\x01\x58\x01\uffff\x01\x59\x12\uffff\x01\x4f\x02\uffff\x01\x4e\x02"+
        "\uffff\x01\x08\x01\uffff\x01\x09\x01\uffff\x01\x0c\x01\uffff\x01"+
        "\x0d\x01\uffff\x01\x4c\x01\x4b\x02\uffff\x01\x14\x01\x15\x08\uffff"+
        "\x01\x21\x01\x22\x01\x2f\x01\x30\x05\uffff\x01\x1d\x01\uffff\x01"+
        "\x1e\x02\uffff\x01\x5a\x01\x5b\x04\uffff\x01\x16\x01\uffff\x01\x56"+
        "\x01\x17\x01\uffff\x01\x57\x01\uffff\x01\x5d\x01\uffff\x01\x5c\x01"+
        "\x50\x01\x51\x01\x5e\x01\x5f\x01\x01\x01\x27\x01\x02\x01\x28\x01"+
        "\x06\x01\x07\x01\x29\x01\x31\x01\x2a\x01\x32\x01\x12\x01\x13\x01"+
        "\x2b\x01\x2d\x01\x1b\x01\x2c\x01\x2e\x01\x1c\x01\x18\x01\x1a";
    const string DFA4_specialS =
        "\u015f\uffff}>";
    static readonly string[] DFA4_transitionS = {
            "\x02\x29\x02\uffff\x01\x29\x12\uffff\x01\x0c\x07\uffff\x01"+
            "\x03\x01\x04\x01\x1f\x01\uffff\x01\x05\x01\uffff\x01\x1c\x01"+
            "\uffff\x0a\x28\x01\uffff\x01\x19\x01\x21\x01\x20\x01\x22\x02"+
            "\uffff\x01\x1b\x01\x10\x01\x02\x01\x14\x01\x1e\x01\x12\x02\x27"+
            "\x01\x09\x02\x27\x01\x0e\x03\x27\x01\x07\x01\x27\x01\x26\x01"+
            "\x0b\x01\x18\x01\x23\x01\x15\x04\x27\x06\uffff\x01\x1a\x01\x0f"+
            "\x01\x01\x01\x13\x01\x1d\x01\x11\x02\x27\x01\x08\x02\x27\x01"+
            "\x0d\x03\x27\x01\x06\x01\x27\x01\x25\x01\x0a\x01\x17\x01\x24"+
            "\x01\x16\x04\x27",
            "\x01\x2b\x06\uffff\x01\x2c\x02\uffff\x01\x2a",
            "\x01\x2e\x06\uffff\x01\x2f\x02\uffff\x01\x2d",
            "",
            "\x01\x30",
            "\x01\x32",
            "\x01\x34",
            "\x01\x35",
            "\x01\x36",
            "\x01\x37",
            "\x01\x39\x02\uffff\x01\x38",
            "\x01\x3b\x02\uffff\x01\x3a",
            "\x01\x4b\x0f\uffff\x01\x45\x01\x44\x01\x46\x02\uffff\x01\x43"+
            "\x02\uffff\x01\x4a\x01\uffff\x01\x3f\x02\uffff\x01\x3d\x05\uffff"+
            "\x01\x48\x04\uffff\x01\x4c\x02\uffff\x01\x40\x09\uffff\x01\x42"+
            "\x02\uffff\x01\x49\x01\uffff\x01\x3e\x02\uffff\x01\x3c\x05\uffff"+
            "\x01\x47\x07\uffff\x01\x41",
            "\x01\x4e\x05\uffff\x01\x4d",
            "\x01\x50\x05\uffff\x01\x4f",
            "\x01\x51",
            "\x01\x52",
            "\x01\x53\x05\uffff\x01\x54",
            "\x01\x55\x05\uffff\x01\x56",
            "\x01\x58\x09\uffff\x01\x57",
            "\x01\x5a\x09\uffff\x01\x59",
            "\x01\x5b",
            "\x01\x5c",
            "\x01\x5d",
            "\x01\x5e",
            "",
            "\x01\x5f\x09\uffff\x01\x60",
            "\x01\x61\x09\uffff\x01\x62",
            "",
            "\x01\x63",
            "\x01\x64",
            "",
            "",
            "\x01\x65",
            "\x01\x67",
            "\x01\x69",
            "\x01\x6a",
            "\x01\x6b",
            "\x01\x6c",
            "",
            "",
            "",
            "\x01\x6d",
            "\x01\x6e",
            "\x01\x6f\x08\uffff\x01\x70",
            "\x01\x71",
            "\x01\x72",
            "\x01\x73\x08\uffff\x01\x74",
            "",
            "",
            "",
            "",
            "\x01\x75",
            "\x01\x76",
            "\x01\x77\x0e\uffff\x01\x78",
            "\x01\x79\x0e\uffff\x01\x7a",
            "\x01\x7b",
            "\x01\x7c\x07\uffff\x01\x7d",
            "\x01\x7e",
            "\x01\x7f\x07\uffff\x01\u0080",
            "\x01\u0081",
            "\x01\u0082",
            "",
            "",
            "",
            "",
            "\x01\u0083\x04\uffff\x01\u0084",
            "\x01\u0085\x04\uffff\x01\u0086",
            "",
            "\x01\u0087\x1c\uffff\x01\u0088",
            "\x01\u0089\x1c\uffff\x01\u008a",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\u008b",
            "\x01\u008c",
            "\x01\u008d",
            "\x01\u008e",
            "\x01\u008f",
            "\x01\u0090",
            "\x01\u0091",
            "\x01\u0092",
            "\x01\u0093",
            "\x01\u0094",
            "\x01\u0095",
            "\x01\u0096",
            "\x01\u0097",
            "\x01\u0098",
            "\x01\u009a\x05\uffff\x01\u0099",
            "\x01\u009c\x05\uffff\x01\u009b",
            "\x01\u009d",
            "\x01\u009e",
            "\x01\u009f",
            "\x01\u00a0",
            "\x01\u00a1",
            "\x01\u00a2",
            "\x01\u00a3",
            "\x01\u00a4",
            "",
            "",
            "",
            "",
            "\x01\u00a5",
            "\x01\u00a6",
            "\x01\u00a7",
            "\x01\u00a8",
            "\x01\u00a9",
            "\x01\u00aa",
            "\x01\u00ab",
            "\x01\u00ac",
            "\x01\u00ad",
            "\x01\u00ae",
            "\x01\u00af",
            "\x01\u00b0",
            "\x01\u00b1",
            "\x01\u00b2",
            "\x01\u00b3",
            "\x01\u00b4",
            "\x01\u00b5",
            "\x01\u00b6",
            "\x01\u00b7",
            "\x01\u00b8",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00ba",
            "\x01\u00bb",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00be\x53\uffff\x01\u00bd",
            "\x01\u00c0\x33\uffff\x01\u00bf",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\u00c1",
            "\x01\u00c2",
            "\x01\u00c3",
            "\x01\u00c4",
            "\x01\u00c5",
            "\x01\u00c6",
            "\x01\u00c7",
            "\x01\u00c8",
            "\x01\u00c9",
            "\x01\u00ca",
            "\x01\u00cb",
            "\x01\u00cc",
            "\x01\u00cd",
            "\x01\u00ce",
            "\x01\u00cf",
            "\x01\u00d0",
            "\x01\u00d1",
            "\x01\u00d2",
            "\x01\u00d3",
            "\x01\u00d4",
            "\x01\u00d5",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00d7",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00d9",
            "\x01\u00da",
            "\x01\u00db",
            "\x01\u00dc",
            "\x01\u00dd",
            "\x01\u00de",
            "\x01\u00df",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00e1",
            "\x01\u00e2",
            "\x01\u00e3",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00e5",
            "\x01\u00e6",
            "\x01\u00e7",
            "\x01\u00e8",
            "\x01\u00e9",
            "\x01\u00ea",
            "\x01\u00eb",
            "\x01\u00ec",
            "\x01\u00ed",
            "\x01\u00ee",
            "",
            "\x01\u00ef",
            "\x01\u00f0",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00f2",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00f4",
            "\x01\u00f5",
            "\x01\u00f6",
            "\x01\u00f7",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00f9",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u00fb",
            "\x01\u00fc",
            "\x01\u00fd",
            "\x01\u00fe",
            "\x01\u00ff",
            "\x01\u0100",
            "\x01\u0101",
            "\x01\u0102",
            "\x01\u0103",
            "\x01\u0104",
            "",
            "",
            "",
            "",
            "\x01\u0105",
            "\x01\u0106",
            "\x01\u0107",
            "\x01\u0108",
            "\x01\u0109",
            "\x01\u010a",
            "\x01\u010b",
            "",
            "\x01\u010c",
            "\x01\u010d",
            "\x01\u010e",
            "",
            "\x01\u010f",
            "\x01\u0110",
            "\x01\u0111",
            "\x01\u0112",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u0114",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u0116",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u0118",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u011a",
            "",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u011d",
            "\x01\u011e",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "",
            "\x01\u0121",
            "\x01\u0122",
            "\x01\u0123",
            "\x01\u0124",
            "\x01\u0125",
            "\x01\u0126",
            "\x01\u0127",
            "\x01\u0128",
            "\x01\u0129",
            "\x01\u012a",
            "\x01\u012b",
            "\x01\u012c",
            "\x01\u012d",
            "\x01\u012e",
            "\x01\u012f",
            "\x01\u0130",
            "\x01\u0131",
            "\x01\u0132",
            "",
            "\x01\u0133",
            "\x01\u0134",
            "",
            "\x01\u0135",
            "\x01\u0136",
            "",
            "\x01\u0137",
            "",
            "\x01\u0138",
            "",
            "\x01\u0139",
            "",
            "\x01\u013a",
            "",
            "",
            "\x01\u013b",
            "\x01\u013c",
            "",
            "",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u013e\x0f\uffff\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a"+
            "\x27",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u0141\x0f\uffff\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a"+
            "\x27",
            "\x01\u0143",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u0145",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "",
            "",
            "",
            "",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x01\u0149",
            "\x01\u014a",
            "\x01\u014c\x0f\uffff\x01\u014b",
            "",
            "\x01\u014e\x0f\uffff\x01\u014d",
            "",
            "\x01\u014f",
            "\x01\u0150",
            "",
            "",
            "\x01\u0151",
            "\x01\u0153",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "\x0a\x27\x07\uffff\x1a\x27\x06\uffff\x1a\x27",
            "",
            "\x01\u0157\x0f\uffff\x01\u0158",
            "",
            "",
            "\x01\u015a\x0f\uffff\x01\u015b",
            "",
            "\x01\u015d",
            "",
            "\x01\u015e",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA4_eot = DFA.UnpackEncodedString(DFA4_eotS);
    static readonly short[] DFA4_eof = DFA.UnpackEncodedString(DFA4_eofS);
    static readonly char[] DFA4_min = DFA.UnpackEncodedStringToUnsignedChars(DFA4_minS);
    static readonly char[] DFA4_max = DFA.UnpackEncodedStringToUnsignedChars(DFA4_maxS);
    static readonly short[] DFA4_accept = DFA.UnpackEncodedString(DFA4_acceptS);
    static readonly short[] DFA4_special = DFA.UnpackEncodedString(DFA4_specialS);
    static readonly short[][] DFA4_transition = DFA.UnpackEncodedStringArray(DFA4_transitionS);

    protected class DFA4 : DFA
    {
        public DFA4(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 4;
            this.eot = DFA4_eot;
            this.eof = DFA4_eof;
            this.min = DFA4_min;
            this.max = DFA4_max;
            this.accept = DFA4_accept;
            this.special = DFA4_special;
            this.transition = DFA4_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( T__7 | T__8 | T__9 | T__10 | T__11 | T__12 | T__13 | T__14 | T__15 | T__16 | T__17 | T__18 | T__19 | T__20 | T__21 | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | T__67 | T__68 | T__69 | T__70 | T__71 | T__72 | T__73 | T__74 | T__75 | T__76 | T__77 | T__78 | T__79 | T__80 | T__81 | T__82 | T__83 | T__84 | T__85 | T__86 | T__87 | T__88 | T__89 | T__90 | T__91 | T__92 | T__93 | T__94 | T__95 | T__96 | T__97 | T__98 | T__99 | T__100 | T__101 | T__102 | NAME | NUMBER | WHITESPACE );"; }
        }

    }

 
    
}
