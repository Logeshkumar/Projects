// $ANTLR 3.1.3 Mar 18, 2009 10:09:25 Query.g 2011-12-09 13:28:43


#pragma warning disable 0219
using edu.syr.cse784.eskimodb.rootserver;



using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

public class QueryParser : Parser 
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"NAME", 
		"NUMBER", 
		"WHITESPACE", 
		"'create table'", 
		"'CREATE TABLE'", 
		"'('", 
		"');'", 
		"','", 
		"'primary key'", 
		"'PRIMARY KEY'", 
		"'index'", 
		"'INDEX'", 
		"'char'", 
		"'CHAR'", 
		"'short'", 
		"'SHORT'", 
		"' int'", 
		"' INT'", 
		"'long'", 
		"'LONG'", 
		"'biglong'", 
		"'BIGLONG'", 
		"'float'", 
		"'FLOAT'", 
		"'double'", 
		"'DOUBLE'", 
		"'VARCHAR('", 
		"')'", 
		"'varchar('", 
		"'delete '", 
		"'DELETE '", 
		"'column '", 
		"'COLUMN '", 
		"' in '", 
		"' IN '", 
		"'table '", 
		"'TABLE '", 
		"';'", 
		"'add '", 
		"'ADD '", 
		"'.'", 
		"'create db '", 
		"'CREATE DB '", 
		"'select db '", 
		"'SELECT DB '", 
		"'delete db '", 
		"'DELETE DB '", 
		"'delete table '", 
		"'DELETE TABLE '", 
		"'empty table '", 
		"'EMPTY TABLE '", 
		"'select '", 
		"'SELECT '", 
		"' from '", 
		"' FROM '", 
		"'*'", 
		"', '", 
		"' WHERE '", 
		"' where '", 
		"' and '", 
		"' AND '", 
		"'='", 
		"'<'", 
		"'>'", 
		"'<='", 
		"'>='", 
		"' = '", 
		"' < '", 
		"' > '", 
		"' <= '", 
		"' >= '", 
		"' order by '", 
		"' ORDER BY '", 
		"' asc'", 
		"' ASC'", 
		"' dsc'", 
		"' DSC'", 
		"'LIMIT'", 
		"'limit'", 
		"' , '", 
		"'COUNT('", 
		"'count('", 
		"'UPDATE'", 
		"'update'", 
		"'SET'", 
		"'set'", 
		"'AND'", 
		"'and'", 
		"'delete'", 
		"'DELETE'", 
		"'from'", 
		"'FROM'", 
		"'insert into'", 
		"'INSERT INTO'", 
		"'values'", 
		"'VALUES'", 
		"'rename '", 
		"'RENAME '", 
		"' TO '"
    };

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
    public const int NAME = 4;
    public const int T__92 = 92;
    public const int T__16 = 16;
    public const int T__15 = 15;
    public const int T__90 = 90;
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



        public QueryParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public QueryParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
       }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return QueryParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "Query.g"; }
    }


    protected void mismatch(IIntStream input,int ttype,BitSet follow)
    {
    	throw new MismatchedTokenException(ttype,input);
    }
    public void recoverFromMismatchedSet(IIntStream input, RecognitionException e, BitSet follow)
    {
    	throw e;
    }



    public class statement_return : ParserRuleReturnScope
    {
        public Statement ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "statement"
    // Query.g:62:1: statement returns [Statement ret] : ( create_db | select_db | delete_db | delete_table | empty_table | mod_table | create_table | select_rows | insert_row | rename_table | update_row | delete_row | rename_column );
    public QueryParser.statement_return statement() // throws RecognitionException [1]
    {   
        QueryParser.statement_return retval = new QueryParser.statement_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        QueryParser.create_db_return create_db1 = null;

        QueryParser.select_db_return select_db2 = null;

        QueryParser.delete_db_return delete_db3 = null;

        QueryParser.delete_table_return delete_table4 = null;

        QueryParser.empty_table_return empty_table5 = null;

        QueryParser.mod_table_return mod_table6 = null;

        QueryParser.create_table_return create_table7 = null;

        QueryParser.select_rows_return select_rows8 = null;

        QueryParser.insert_row_return insert_row9 = null;

        QueryParser.rename_table_return rename_table10 = null;

        QueryParser.update_row_return update_row11 = null;

        QueryParser.delete_row_return delete_row12 = null;

        QueryParser.rename_column_return rename_column13 = null;



        try 
    	{
            // Query.g:64:1: ( create_db | select_db | delete_db | delete_table | empty_table | mod_table | create_table | select_rows | insert_row | rename_table | update_row | delete_row | rename_column )
            int alt1 = 13;
            alt1 = dfa1.Predict(input);
            switch (alt1) 
            {
                case 1 :
                    // Query.g:64:3: create_db
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_create_db_in_statement78);
                    	create_db1 = create_db();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, create_db1.Tree);
                    	 retval.ret = ((create_db1 != null) ? create_db1.ret : null);

                    }
                    break;
                case 2 :
                    // Query.g:65:3: select_db
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_select_db_in_statement85);
                    	select_db2 = select_db();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, select_db2.Tree);
                    	 retval.ret = ((select_db2 != null) ? select_db2.ret : null);

                    }
                    break;
                case 3 :
                    // Query.g:66:3: delete_db
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_delete_db_in_statement91);
                    	delete_db3 = delete_db();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, delete_db3.Tree);
                    	retval.ret = ((delete_db3 != null) ? delete_db3.ret : null);

                    }
                    break;
                case 4 :
                    // Query.g:67:3: delete_table
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_delete_table_in_statement97);
                    	delete_table4 = delete_table();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, delete_table4.Tree);
                    	retval.ret = ((delete_table4 != null) ? delete_table4.ret : null);

                    }
                    break;
                case 5 :
                    // Query.g:68:3: empty_table
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_empty_table_in_statement103);
                    	empty_table5 = empty_table();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, empty_table5.Tree);
                    	retval.ret = ((empty_table5 != null) ? empty_table5.ret : null);

                    }
                    break;
                case 6 :
                    // Query.g:69:3: mod_table
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_mod_table_in_statement109);
                    	mod_table6 = mod_table();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, mod_table6.Tree);
                    	retval.ret = ((mod_table6 != null) ? mod_table6.ret : null);

                    }
                    break;
                case 7 :
                    // Query.g:70:3: create_table
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_create_table_in_statement115);
                    	create_table7 = create_table();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, create_table7.Tree);
                    	retval.ret = ((create_table7 != null) ? create_table7.ret : null);

                    }
                    break;
                case 8 :
                    // Query.g:71:3: select_rows
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_select_rows_in_statement121);
                    	select_rows8 = select_rows();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, select_rows8.Tree);
                    	 retval.ret = ((select_rows8 != null) ? select_rows8.ret : null);

                    }
                    break;
                case 9 :
                    // Query.g:72:3: insert_row
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_insert_row_in_statement127);
                    	insert_row9 = insert_row();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, insert_row9.Tree);
                    	retval.ret = ((insert_row9 != null) ? insert_row9.ret : null);

                    }
                    break;
                case 10 :
                    // Query.g:73:3: rename_table
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_rename_table_in_statement133);
                    	rename_table10 = rename_table();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, rename_table10.Tree);
                    	retval.ret = ((rename_table10 != null) ? rename_table10.ret : null);

                    }
                    break;
                case 11 :
                    // Query.g:74:3: update_row
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_update_row_in_statement139);
                    	update_row11 = update_row();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, update_row11.Tree);
                    	 retval.ret = ((update_row11 != null) ? update_row11.ret : null);

                    }
                    break;
                case 12 :
                    // Query.g:75:3: delete_row
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_delete_row_in_statement145);
                    	delete_row12 = delete_row();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, delete_row12.Tree);
                    	 retval.ret = ((delete_row12 != null) ? delete_row12.ret : null);

                    }
                    break;
                case 13 :
                    // Query.g:76:3: rename_column
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_rename_column_in_statement151);
                    	rename_column13 = rename_column();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, rename_column13.Tree);
                    	retval.ret = ((rename_column13 != null) ? rename_column13.ret : null);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "statement"

    public class create_table_return : ParserRuleReturnScope
    {
        public CreateTable ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "create_table"
    // Query.g:79:1: create_table returns [CreateTable ret] : ( 'create table' | 'CREATE TABLE' ) table_name '(' tlist ');' ;
    public QueryParser.create_table_return create_table() // throws RecognitionException [1]
    {   
        QueryParser.create_table_return retval = new QueryParser.create_table_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set14 = null;
        IToken char_literal16 = null;
        IToken string_literal18 = null;
        QueryParser.table_name_return table_name15 = null;

        QueryParser.tlist_return tlist17 = null;


        object set14_tree=null;
        object char_literal16_tree=null;
        object string_literal18_tree=null;


        	retval.ret = new CreateTable();
        	retval.ret.SetStatementType(StatementType.CREATE_TABLE);

        try 
    	{
            // Query.g:85:1: ( ( 'create table' | 'CREATE TABLE' ) table_name '(' tlist ');' )
            // Query.g:85:2: ( 'create table' | 'CREATE TABLE' ) table_name '(' tlist ');'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set14 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 7 && input.LA(1) <= 8) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set14));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_create_table174);
            	table_name15 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name15.Tree);
            	char_literal16=(IToken)Match(input,9,FOLLOW_9_in_create_table175); 
            		char_literal16_tree = (object)adaptor.Create(char_literal16);
            		adaptor.AddChild(root_0, char_literal16_tree);

            	PushFollow(FOLLOW_tlist_in_create_table177);
            	tlist17 = tlist();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, tlist17.Tree);
            	string_literal18=(IToken)Match(input,10,FOLLOW_10_in_create_table179); 
            		string_literal18_tree = (object)adaptor.Create(string_literal18);
            		adaptor.AddChild(root_0, string_literal18_tree);


            	retval.ret.SetTableName(((table_name15 != null) ? table_name15.ret : null).GetTableName());
            	retval.ret.SetList(((tlist17 != null) ? tlist17.ret : null));


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "create_table"

    public class tlist_return : ParserRuleReturnScope
    {
        public ColumnList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "tlist"
    // Query.g:92:1: tlist returns [ColumnList ret] : t1= tcolumn ( ',' t2= tcolumn )* ;
    public QueryParser.tlist_return tlist() // throws RecognitionException [1]
    {   
        QueryParser.tlist_return retval = new QueryParser.tlist_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal19 = null;
        QueryParser.tcolumn_return t1 = null;

        QueryParser.tcolumn_return t2 = null;


        object char_literal19_tree=null;


               retval.ret = new ColumnList();

        try 
    	{
            // Query.g:97:2: (t1= tcolumn ( ',' t2= tcolumn )* )
            // Query.g:97:3: t1= tcolumn ( ',' t2= tcolumn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_tcolumn_in_tlist202);
            	t1 = tcolumn();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, t1.Tree);

            	 retval.ret.AddToList(((t1 != null) ? t1.ret : null));
            	 
            	// Query.g:100:2: ( ',' t2= tcolumn )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( (LA2_0 == 11) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // Query.g:100:3: ',' t2= tcolumn
            			    {
            			    	char_literal19=(IToken)Match(input,11,FOLLOW_11_in_tlist207); 
            			    		char_literal19_tree = (object)adaptor.Create(char_literal19);
            			    		adaptor.AddChild(root_0, char_literal19_tree);

            			    	PushFollow(FOLLOW_tcolumn_in_tlist213);
            			    	t2 = tcolumn();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, t2.Tree);

            			    	 retval.ret.AddToList(((t2 != null) ? t2.ret : null));
            			    	 

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "tlist"

    public class tcolumn_return : ParserRuleReturnScope
    {
        public TableColumn ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "tcolumn"
    // Query.g:105:1: tcolumn returns [TableColumn ret] : ( ( 'primary key' | 'PRIMARY KEY' ) | ( 'index' | 'INDEX' ) )? NAME type ;
    public QueryParser.tcolumn_return tcolumn() // throws RecognitionException [1]
    {   
        QueryParser.tcolumn_return retval = new QueryParser.tcolumn_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set20 = null;
        IToken set21 = null;
        IToken NAME22 = null;
        QueryParser.type_return type23 = null;


        object set20_tree=null;
        object set21_tree=null;
        object NAME22_tree=null;


        	retval.ret = new TableColumn();

        try 
    	{
            // Query.g:110:1: ( ( ( 'primary key' | 'PRIMARY KEY' ) | ( 'index' | 'INDEX' ) )? NAME type )
            // Query.g:110:2: ( ( 'primary key' | 'PRIMARY KEY' ) | ( 'index' | 'INDEX' ) )? NAME type
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// Query.g:110:2: ( ( 'primary key' | 'PRIMARY KEY' ) | ( 'index' | 'INDEX' ) )?
            	int alt3 = 3;
            	int LA3_0 = input.LA(1);

            	if ( ((LA3_0 >= 12 && LA3_0 <= 13)) )
            	{
            	    alt3 = 1;
            	}
            	else if ( ((LA3_0 >= 14 && LA3_0 <= 15)) )
            	{
            	    alt3 = 2;
            	}
            	switch (alt3) 
            	{
            	    case 1 :
            	        // Query.g:110:3: ( 'primary key' | 'PRIMARY KEY' )
            	        {
            	        	set20 = (IToken)input.LT(1);
            	        	if ( (input.LA(1) >= 12 && input.LA(1) <= 13) ) 
            	        	{
            	        	    input.Consume();
            	        	    adaptor.AddChild(root_0, (object)adaptor.Create(set20));
            	        	    state.errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    throw mse;
            	        	}


            	        	retval.ret.SetUniqueKey("PRIMARY KEY");


            	        }
            	        break;
            	    case 2 :
            	        // Query.g:113:2: ( 'index' | 'INDEX' )
            	        {
            	        	set21 = (IToken)input.LT(1);
            	        	if ( (input.LA(1) >= 14 && input.LA(1) <= 15) ) 
            	        	{
            	        	    input.Consume();
            	        	    adaptor.AddChild(root_0, (object)adaptor.Create(set21));
            	        	    state.errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    throw mse;
            	        	}


            	        	retval.ret.SetUniqueKey("INDEX");


            	        }
            	        break;

            	}

            	NAME22=(IToken)Match(input,NAME,FOLLOW_NAME_in_tcolumn253); 
            		NAME22_tree = (object)adaptor.Create(NAME22);
            		adaptor.AddChild(root_0, NAME22_tree);

            	PushFollow(FOLLOW_type_in_tcolumn255);
            	type23 = type();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, type23.Tree);

            	if(((NAME22 != null) ? NAME22.Text : null) == "<missing NAME>")
            	{		
            		QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Column Name.");
            		throw qpe;
            	}
            	else
            	{	retval.ret.SetColumnName(((NAME22 != null) ? NAME22.Text : null));
            		retval.ret.SetVarType(((type23 != null) ? type23.ret : null));
            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "tcolumn"

    public class type_return : ParserRuleReturnScope
    {
        public VarType ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "type"
    // Query.g:127:1: type returns [VarType ret] : ( ( 'char' | 'CHAR' ) | ( 'short' | 'SHORT' ) | ( ' int' | ' INT' ) | ( 'long' | 'LONG' ) | ( 'biglong' | 'BIGLONG' ) | ( 'float' | 'FLOAT' ) | ( 'double' | 'DOUBLE' ) | ( 'VARCHAR(' n1= NUMBER ')' | 'varchar(' n2= NUMBER ')' ) );
    public QueryParser.type_return type() // throws RecognitionException [1]
    {   
        QueryParser.type_return retval = new QueryParser.type_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken n1 = null;
        IToken n2 = null;
        IToken set24 = null;
        IToken set25 = null;
        IToken set26 = null;
        IToken set27 = null;
        IToken set28 = null;
        IToken set29 = null;
        IToken set30 = null;
        IToken string_literal31 = null;
        IToken char_literal32 = null;
        IToken string_literal33 = null;
        IToken char_literal34 = null;

        object n1_tree=null;
        object n2_tree=null;
        object set24_tree=null;
        object set25_tree=null;
        object set26_tree=null;
        object set27_tree=null;
        object set28_tree=null;
        object set29_tree=null;
        object set30_tree=null;
        object string_literal31_tree=null;
        object char_literal32_tree=null;
        object string_literal33_tree=null;
        object char_literal34_tree=null;


        retval.ret = new VarType();

        try 
    	{
            // Query.g:132:1: ( ( 'char' | 'CHAR' ) | ( 'short' | 'SHORT' ) | ( ' int' | ' INT' ) | ( 'long' | 'LONG' ) | ( 'biglong' | 'BIGLONG' ) | ( 'float' | 'FLOAT' ) | ( 'double' | 'DOUBLE' ) | ( 'VARCHAR(' n1= NUMBER ')' | 'varchar(' n2= NUMBER ')' ) )
            int alt5 = 8;
            switch ( input.LA(1) ) 
            {
            case 16:
            case 17:
            	{
                alt5 = 1;
                }
                break;
            case 18:
            case 19:
            	{
                alt5 = 2;
                }
                break;
            case 20:
            case 21:
            	{
                alt5 = 3;
                }
                break;
            case 22:
            case 23:
            	{
                alt5 = 4;
                }
                break;
            case 24:
            case 25:
            	{
                alt5 = 5;
                }
                break;
            case 26:
            case 27:
            	{
                alt5 = 6;
                }
                break;
            case 28:
            case 29:
            	{
                alt5 = 7;
                }
                break;
            case 30:
            case 32:
            	{
                alt5 = 8;
                }
                break;
            	default:
            	    NoViableAltException nvae_d5s0 =
            	        new NoViableAltException("", 5, 0, input);

            	    throw nvae_d5s0;
            }

            switch (alt5) 
            {
                case 1 :
                    // Query.g:132:2: ( 'char' | 'CHAR' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set24 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 16 && input.LA(1) <= 17) ) 
                    	{
                    	    input.Consume();
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(set24));
                    	    state.errorRecovery = false;
                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	retval.ret.SetVarType("CHAR");

                    }
                    break;
                case 2 :
                    // Query.g:133:2: ( 'short' | 'SHORT' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set25 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 18 && input.LA(1) <= 19) ) 
                    	{
                    	    input.Consume();
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(set25));
                    	    state.errorRecovery = false;
                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	retval.ret.SetVarType("SHORT");

                    }
                    break;
                case 3 :
                    // Query.g:134:2: ( ' int' | ' INT' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set26 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 20 && input.LA(1) <= 21) ) 
                    	{
                    	    input.Consume();
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(set26));
                    	    state.errorRecovery = false;
                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	retval.ret.SetVarType("INT");

                    }
                    break;
                case 4 :
                    // Query.g:135:2: ( 'long' | 'LONG' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set27 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 22 && input.LA(1) <= 23) ) 
                    	{
                    	    input.Consume();
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(set27));
                    	    state.errorRecovery = false;
                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	retval.ret.SetVarType("LONG");

                    }
                    break;
                case 5 :
                    // Query.g:136:2: ( 'biglong' | 'BIGLONG' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set28 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 24 && input.LA(1) <= 25) ) 
                    	{
                    	    input.Consume();
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(set28));
                    	    state.errorRecovery = false;
                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	retval.ret.SetVarType("BIGLONG");

                    }
                    break;
                case 6 :
                    // Query.g:137:2: ( 'float' | 'FLOAT' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set29 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 26 && input.LA(1) <= 27) ) 
                    	{
                    	    input.Consume();
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(set29));
                    	    state.errorRecovery = false;
                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	retval.ret.SetVarType("FLOAT");

                    }
                    break;
                case 7 :
                    // Query.g:138:2: ( 'double' | 'DOUBLE' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set30 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 28 && input.LA(1) <= 29) ) 
                    	{
                    	    input.Consume();
                    	    adaptor.AddChild(root_0, (object)adaptor.Create(set30));
                    	    state.errorRecovery = false;
                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	retval.ret.SetVarType("DOUBLE");

                    }
                    break;
                case 8 :
                    // Query.g:139:3: ( 'VARCHAR(' n1= NUMBER ')' | 'varchar(' n2= NUMBER ')' )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// Query.g:139:3: ( 'VARCHAR(' n1= NUMBER ')' | 'varchar(' n2= NUMBER ')' )
                    	int alt4 = 2;
                    	int LA4_0 = input.LA(1);

                    	if ( (LA4_0 == 30) )
                    	{
                    	    alt4 = 1;
                    	}
                    	else if ( (LA4_0 == 32) )
                    	{
                    	    alt4 = 2;
                    	}
                    	else 
                    	{
                    	    NoViableAltException nvae_d4s0 =
                    	        new NoViableAltException("", 4, 0, input);

                    	    throw nvae_d4s0;
                    	}
                    	switch (alt4) 
                    	{
                    	    case 1 :
                    	        // Query.g:139:4: 'VARCHAR(' n1= NUMBER ')'
                    	        {
                    	        	string_literal31=(IToken)Match(input,30,FOLLOW_30_in_type329); 
                    	        		string_literal31_tree = (object)adaptor.Create(string_literal31);
                    	        		adaptor.AddChild(root_0, string_literal31_tree);

                    	        	n1=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_type332); 
                    	        		n1_tree = (object)adaptor.Create(n1);
                    	        		adaptor.AddChild(root_0, n1_tree);


                    	        	if(((n1 != null) ? n1.Text : null)=="<missing NUMBER>")
                    	        	{
                    	        	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing VARCHAR Range.");
                    	        		throw qpe;
                    	        	}
                    	        	else{
                    	        	retval.ret.SetVarRange(((n1 != null) ? n1.Text : null));}

                    	        	char_literal32=(IToken)Match(input,31,FOLLOW_31_in_type334); 
                    	        		char_literal32_tree = (object)adaptor.Create(char_literal32);
                    	        		adaptor.AddChild(root_0, char_literal32_tree);


                    	        }
                    	        break;
                    	    case 2 :
                    	        // Query.g:147:7: 'varchar(' n2= NUMBER ')'
                    	        {
                    	        	string_literal33=(IToken)Match(input,32,FOLLOW_32_in_type337); 
                    	        		string_literal33_tree = (object)adaptor.Create(string_literal33);
                    	        		adaptor.AddChild(root_0, string_literal33_tree);

                    	        	n2=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_type340); 
                    	        		n2_tree = (object)adaptor.Create(n2);
                    	        		adaptor.AddChild(root_0, n2_tree);


                    	        	if(((n2 != null) ? n2.Text : null)=="<missing NUMBER>")
                    	        	{
                    	        	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing VARCHAR Range.");
                    	        		throw qpe;
                    	        	}
                    	        	else
                    	        	{
                    	        	retval.ret.SetVarRange(((n2 != null) ? n2.Text : null));
                    	        	}

                    	        	char_literal34=(IToken)Match(input,31,FOLLOW_31_in_type344); 
                    	        		char_literal34_tree = (object)adaptor.Create(char_literal34);
                    	        		adaptor.AddChild(root_0, char_literal34_tree);


                    	        }
                    	        break;

                    	}


                    	retval.ret.SetVarType("VARCHAR");


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "type"

    public class mod_table_return : ParserRuleReturnScope
    {
        public ModifyTab ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "mod_table"
    // Query.g:163:1: mod_table returns [ModifyTab ret] : ( delete_column | add_column );
    public QueryParser.mod_table_return mod_table() // throws RecognitionException [1]
    {   
        QueryParser.mod_table_return retval = new QueryParser.mod_table_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        QueryParser.delete_column_return delete_column35 = null;

        QueryParser.add_column_return add_column36 = null;




        retval.ret = new ModifyTab();
        retval.ret.SetStatementType(StatementType.MOD_TABLE);

        try 
    	{
            // Query.g:169:1: ( delete_column | add_column )
            int alt6 = 2;
            int LA6_0 = input.LA(1);

            if ( ((LA6_0 >= 33 && LA6_0 <= 34)) )
            {
                alt6 = 1;
            }
            else if ( ((LA6_0 >= 42 && LA6_0 <= 43)) )
            {
                alt6 = 2;
            }
            else 
            {
                NoViableAltException nvae_d6s0 =
                    new NoViableAltException("", 6, 0, input);

                throw nvae_d6s0;
            }
            switch (alt6) 
            {
                case 1 :
                    // Query.g:169:2: delete_column
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_delete_column_in_mod_table363);
                    	delete_column35 = delete_column();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, delete_column35.Tree);

                    	retval.ret.SetType("DELETE");
                    	retval.ret.SetDelColumnData(((delete_column35 != null) ? delete_column35.ret : null));


                    }
                    break;
                case 2 :
                    // Query.g:174:3: add_column
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_add_column_in_mod_table370);
                    	add_column36 = add_column();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, add_column36.Tree);

                    	retval.ret.SetType("ADD");
                    	retval.ret.SetAddColumnData(((add_column36 != null) ? add_column36.ret : null));


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "mod_table"

    public class delete_column_return : ParserRuleReturnScope
    {
        public DeleteColumn ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "delete_column"
    // Query.g:180:1: delete_column returns [DeleteColumn ret] : ( 'delete ' | 'DELETE ' ) ( 'column ' | 'COLUMN ' ) NAME ( ' in ' | ' IN ' ) ( 'table ' | 'TABLE ' ) table_name ';' ;
    public QueryParser.delete_column_return delete_column() // throws RecognitionException [1]
    {   
        QueryParser.delete_column_return retval = new QueryParser.delete_column_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set37 = null;
        IToken set38 = null;
        IToken NAME39 = null;
        IToken set40 = null;
        IToken set41 = null;
        IToken char_literal43 = null;
        QueryParser.table_name_return table_name42 = null;


        object set37_tree=null;
        object set38_tree=null;
        object NAME39_tree=null;
        object set40_tree=null;
        object set41_tree=null;
        object char_literal43_tree=null;


        retval.ret = new DeleteColumn();


        try 
    	{
            // Query.g:186:1: ( ( 'delete ' | 'DELETE ' ) ( 'column ' | 'COLUMN ' ) NAME ( ' in ' | ' IN ' ) ( 'table ' | 'TABLE ' ) table_name ';' )
            // Query.g:186:2: ( 'delete ' | 'DELETE ' ) ( 'column ' | 'COLUMN ' ) NAME ( ' in ' | ' IN ' ) ( 'table ' | 'TABLE ' ) table_name ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set37 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 33 && input.LA(1) <= 34) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set37));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	set38 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 35 && input.LA(1) <= 36) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set38));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	NAME39=(IToken)Match(input,NAME,FOLLOW_NAME_in_delete_column399); 
            		NAME39_tree = (object)adaptor.Create(NAME39);
            		adaptor.AddChild(root_0, NAME39_tree);

            	set40 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 37 && input.LA(1) <= 38) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set40));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	set41 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 39 && input.LA(1) <= 40) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set41));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_delete_column411);
            	table_name42 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name42.Tree);
            	char_literal43=(IToken)Match(input,41,FOLLOW_41_in_delete_column412); 
            		char_literal43_tree = (object)adaptor.Create(char_literal43);
            		adaptor.AddChild(root_0, char_literal43_tree);


            	if(((NAME39 != null) ? NAME39.Text : null) == "<missing NAME>")
            	{		
            		QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Column Name.");
            		throw qpe;
            	}
            	else
            	{							
            	retval.ret.SetColumnData(((NAME39 != null) ? NAME39.Text : null));
            	retval.ret.SetTableName(((table_name42 != null) ? table_name42.ret : null).GetTableName());
            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "delete_column"

    public class add_column_return : ParserRuleReturnScope
    {
        public AddColumn ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "add_column"
    // Query.g:200:1: add_column returns [AddColumn ret] : ( 'add ' | 'ADD ' ) ( 'column ' | 'COLUMN ' ) tcolumn ( ' in ' | ' IN ' ) ( 'table ' | 'TABLE ' ) table_name ';' ;
    public QueryParser.add_column_return add_column() // throws RecognitionException [1]
    {   
        QueryParser.add_column_return retval = new QueryParser.add_column_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set44 = null;
        IToken set45 = null;
        IToken set47 = null;
        IToken set48 = null;
        IToken char_literal50 = null;
        QueryParser.tcolumn_return tcolumn46 = null;

        QueryParser.table_name_return table_name49 = null;


        object set44_tree=null;
        object set45_tree=null;
        object set47_tree=null;
        object set48_tree=null;
        object char_literal50_tree=null;


        retval.ret = new AddColumn();

        try 
    	{
            // Query.g:205:1: ( ( 'add ' | 'ADD ' ) ( 'column ' | 'COLUMN ' ) tcolumn ( ' in ' | ' IN ' ) ( 'table ' | 'TABLE ' ) table_name ';' )
            // Query.g:205:2: ( 'add ' | 'ADD ' ) ( 'column ' | 'COLUMN ' ) tcolumn ( ' in ' | ' IN ' ) ( 'table ' | 'TABLE ' ) table_name ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set44 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 42 && input.LA(1) <= 43) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set44));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	set45 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 35 && input.LA(1) <= 36) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set45));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_tcolumn_in_add_column440);
            	tcolumn46 = tcolumn();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, tcolumn46.Tree);
            	retval.ret.SetColumnData(((tcolumn46 != null) ? tcolumn46.ret : null));
            	set47 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 37 && input.LA(1) <= 38) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set47));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	set48 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 39 && input.LA(1) <= 40) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set48));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_add_column453);
            	table_name49 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name49.Tree);
            	char_literal50=(IToken)Match(input,41,FOLLOW_41_in_add_column454); 
            		char_literal50_tree = (object)adaptor.Create(char_literal50);
            		adaptor.AddChild(root_0, char_literal50_tree);

            								
            	retval.ret.SetTableName(((table_name49 != null) ? table_name49.ret : null).GetTableName());


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "add_column"

    public class table_name_return : ParserRuleReturnScope
    {
        public Table ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "table_name"
    // Query.g:210:1: table_name returns [Table ret] : (Name1= NAME '.' Name3= NAME | Name2= NAME );
    public QueryParser.table_name_return table_name() // throws RecognitionException [1]
    {   
        QueryParser.table_name_return retval = new QueryParser.table_name_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken Name1 = null;
        IToken Name3 = null;
        IToken Name2 = null;
        IToken char_literal51 = null;

        object Name1_tree=null;
        object Name3_tree=null;
        object Name2_tree=null;
        object char_literal51_tree=null;


        	retval.ret = new Table();

        try 
    	{
            // Query.g:215:1: (Name1= NAME '.' Name3= NAME | Name2= NAME )
            int alt7 = 2;
            int LA7_0 = input.LA(1);

            if ( (LA7_0 == NAME) )
            {
                int LA7_1 = input.LA(2);

                if ( (LA7_1 == 44) )
                {
                    alt7 = 1;
                }
                else if ( (LA7_1 == EOF || LA7_1 == 9 || LA7_1 == 41 || (LA7_1 >= 61 && LA7_1 <= 62) || (LA7_1 >= 75 && LA7_1 <= 76) || (LA7_1 >= 81 && LA7_1 <= 82) || (LA7_1 >= 88 && LA7_1 <= 89) || LA7_1 == 102) )
                {
                    alt7 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d7s1 =
                        new NoViableAltException("", 7, 1, input);

                    throw nvae_d7s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d7s0 =
                    new NoViableAltException("", 7, 0, input);

                throw nvae_d7s0;
            }
            switch (alt7) 
            {
                case 1 :
                    // Query.g:215:3: Name1= NAME '.' Name3= NAME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	Name1=(IToken)Match(input,NAME,FOLLOW_NAME_in_table_name476); 
                    		Name1_tree = (object)adaptor.Create(Name1);
                    		adaptor.AddChild(root_0, Name1_tree);

                    	char_literal51=(IToken)Match(input,44,FOLLOW_44_in_table_name477); 
                    		char_literal51_tree = (object)adaptor.Create(char_literal51);
                    		adaptor.AddChild(root_0, char_literal51_tree);

                    	Name3=(IToken)Match(input,NAME,FOLLOW_NAME_in_table_name480); 
                    		Name3_tree = (object)adaptor.Create(Name3);
                    		adaptor.AddChild(root_0, Name3_tree);


                    	if(((Name1 != null) ? Name1.Text : null) == "<missing NAME>" || ((Name2 != null) ? Name2.Text : null) == "<missing NAME>")
                    	{		
                    	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Table Name.");
                    	throw qpe;
                    	}
                    	else			
                    	retval.ret.SetTableName(((Name1 != null) ? Name1.Text : null)+"."+((Name3 != null) ? Name3.Text : null)); 

                    }
                    break;
                case 2 :
                    // Query.g:224:3: Name2= NAME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	Name2=(IToken)Match(input,NAME,FOLLOW_NAME_in_table_name490); 
                    		Name2_tree = (object)adaptor.Create(Name2);
                    		adaptor.AddChild(root_0, Name2_tree);


                    	if(((Name2 != null) ? Name2.Text : null) == "<missing NAME>")
                    	{		
                    	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Table Name.");
                    	throw qpe;
                    	}
                    	else						
                    	retval.ret.SetTableName(((Name2 != null) ? Name2.Text : null)); 


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "table_name"

    public class create_db_return : ParserRuleReturnScope
    {
        public CreateDB ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "create_db"
    // Query.g:235:1: create_db returns [CreateDB ret] : ( 'create db ' | 'CREATE DB ' ) NAME ';' ;
    public QueryParser.create_db_return create_db() // throws RecognitionException [1]
    {   
        QueryParser.create_db_return retval = new QueryParser.create_db_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set52 = null;
        IToken NAME53 = null;
        IToken char_literal54 = null;

        object set52_tree=null;
        object NAME53_tree=null;
        object char_literal54_tree=null;


        	retval.ret = new CreateDB();
        	retval.ret.SetStatementType(StatementType.CREATE_DB);

        try 
    	{
            // Query.g:241:1: ( ( 'create db ' | 'CREATE DB ' ) NAME ';' )
            // Query.g:241:2: ( 'create db ' | 'CREATE DB ' ) NAME ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set52 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 45 && input.LA(1) <= 46) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set52));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	NAME53=(IToken)Match(input,NAME,FOLLOW_NAME_in_create_db514); 
            		NAME53_tree = (object)adaptor.Create(NAME53);
            		adaptor.AddChild(root_0, NAME53_tree);

            	char_literal54=(IToken)Match(input,41,FOLLOW_41_in_create_db515); 
            		char_literal54_tree = (object)adaptor.Create(char_literal54);
            		adaptor.AddChild(root_0, char_literal54_tree);


            	if(((NAME53 != null) ? NAME53.Text : null) == "<missing NAME>")
            	{		
            	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Database Name.");
            	throw qpe;
            	}
            	else
            	retval.ret.SetDatabaseName(((NAME53 != null) ? NAME53.Text : null));


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "create_db"

    public class select_db_return : ParserRuleReturnScope
    {
        public SelectDB ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "select_db"
    // Query.g:252:1: select_db returns [SelectDB ret] : ( 'select db ' | 'SELECT DB ' ) NAME ';' ;
    public QueryParser.select_db_return select_db() // throws RecognitionException [1]
    {   
        QueryParser.select_db_return retval = new QueryParser.select_db_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set55 = null;
        IToken NAME56 = null;
        IToken char_literal57 = null;

        object set55_tree=null;
        object NAME56_tree=null;
        object char_literal57_tree=null;


        	retval.ret = new SelectDB();
        	retval.ret.SetStatementType(StatementType.SELECT_DB);

        try 
    	{
            // Query.g:258:1: ( ( 'select db ' | 'SELECT DB ' ) NAME ';' )
            // Query.g:258:3: ( 'select db ' | 'SELECT DB ' ) NAME ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set55 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 47 && input.LA(1) <= 48) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set55));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	NAME56=(IToken)Match(input,NAME,FOLLOW_NAME_in_select_db539); 
            		NAME56_tree = (object)adaptor.Create(NAME56);
            		adaptor.AddChild(root_0, NAME56_tree);

            	char_literal57=(IToken)Match(input,41,FOLLOW_41_in_select_db540); 
            		char_literal57_tree = (object)adaptor.Create(char_literal57);
            		adaptor.AddChild(root_0, char_literal57_tree);


            	if(((NAME56 != null) ? NAME56.Text : null) == "<missing NAME>")
            	{		
            	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Database Name.");
            	throw qpe;
            	}
            	else
            	retval.ret.SetDatabaseName(((NAME56 != null) ? NAME56.Text : null));


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "select_db"

    public class delete_db_return : ParserRuleReturnScope
    {
        public DeleteDB ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "delete_db"
    // Query.g:269:1: delete_db returns [DeleteDB ret] : ( 'delete db ' | 'DELETE DB ' ) NAME ';' ;
    public QueryParser.delete_db_return delete_db() // throws RecognitionException [1]
    {   
        QueryParser.delete_db_return retval = new QueryParser.delete_db_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set58 = null;
        IToken NAME59 = null;
        IToken char_literal60 = null;

        object set58_tree=null;
        object NAME59_tree=null;
        object char_literal60_tree=null;


        	retval.ret = new DeleteDB();
        	retval.ret.SetStatementType(StatementType.DELETE_DB);

        try 
    	{
            // Query.g:275:1: ( ( 'delete db ' | 'DELETE DB ' ) NAME ';' )
            // Query.g:275:2: ( 'delete db ' | 'DELETE DB ' ) NAME ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set58 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 49 && input.LA(1) <= 50) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set58));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	NAME59=(IToken)Match(input,NAME,FOLLOW_NAME_in_delete_db563); 
            		NAME59_tree = (object)adaptor.Create(NAME59);
            		adaptor.AddChild(root_0, NAME59_tree);

            	char_literal60=(IToken)Match(input,41,FOLLOW_41_in_delete_db564); 
            		char_literal60_tree = (object)adaptor.Create(char_literal60);
            		adaptor.AddChild(root_0, char_literal60_tree);


            	if(((NAME59 != null) ? NAME59.Text : null) == "<missing NAME>")
            	{		
            	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Database Name.");
            	throw qpe;
            	}
            	else
            	retval.ret.SetDatabaseName(((NAME59 != null) ? NAME59.Text : null));


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "delete_db"

    public class delete_table_return : ParserRuleReturnScope
    {
        public DeleteTable ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "delete_table"
    // Query.g:286:1: delete_table returns [DeleteTable ret] : ( 'delete table ' | 'DELETE TABLE ' ) table_name ';' ;
    public QueryParser.delete_table_return delete_table() // throws RecognitionException [1]
    {   
        QueryParser.delete_table_return retval = new QueryParser.delete_table_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set61 = null;
        IToken char_literal63 = null;
        QueryParser.table_name_return table_name62 = null;


        object set61_tree=null;
        object char_literal63_tree=null;


        	retval.ret = new DeleteTable();
        	retval.ret.SetStatementType(StatementType.DELETE_TABLE);

        try 
    	{
            // Query.g:292:1: ( ( 'delete table ' | 'DELETE TABLE ' ) table_name ';' )
            // Query.g:292:2: ( 'delete table ' | 'DELETE TABLE ' ) table_name ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set61 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 51 && input.LA(1) <= 52) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set61));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_delete_table587);
            	table_name62 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name62.Tree);
            	char_literal63=(IToken)Match(input,41,FOLLOW_41_in_delete_table588); 
            		char_literal63_tree = (object)adaptor.Create(char_literal63);
            		adaptor.AddChild(root_0, char_literal63_tree);


            	retval.ret.SetTableName(((table_name62 != null) ? table_name62.ret : null).GetTableName());


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "delete_table"

    public class empty_table_return : ParserRuleReturnScope
    {
        public EmptyTable ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "empty_table"
    // Query.g:297:1: empty_table returns [EmptyTable ret] : ( 'empty table ' | 'EMPTY TABLE ' ) table_name ';' ;
    public QueryParser.empty_table_return empty_table() // throws RecognitionException [1]
    {   
        QueryParser.empty_table_return retval = new QueryParser.empty_table_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set64 = null;
        IToken char_literal66 = null;
        QueryParser.table_name_return table_name65 = null;


        object set64_tree=null;
        object char_literal66_tree=null;


        	retval.ret = new EmptyTable();
        	retval.ret.SetStatementType(StatementType.EMPTY_TABLE);

        try 
    	{
            // Query.g:303:1: ( ( 'empty table ' | 'EMPTY TABLE ' ) table_name ';' )
            // Query.g:303:2: ( 'empty table ' | 'EMPTY TABLE ' ) table_name ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set64 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 53 && input.LA(1) <= 54) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set64));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_empty_table613);
            	table_name65 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name65.Tree);
            	char_literal66=(IToken)Match(input,41,FOLLOW_41_in_empty_table614); 
            		char_literal66_tree = (object)adaptor.Create(char_literal66);
            		adaptor.AddChild(root_0, char_literal66_tree);



            	retval.ret.SetTableName(((table_name65 != null) ? table_name65.ret : null).GetTableName());


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "empty_table"

    public class select_rows_return : ParserRuleReturnScope
    {
        public SelectRows ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "select_rows"
    // Query.g:308:1: select_rows returns [SelectRows ret] : ( 'select ' | 'SELECT ' ) select_row_table_column_list ( ' from ' | ' FROM ' ) table_name ( where_list )? ( order_by_list )? ( limit_range )? ';' ;
    public QueryParser.select_rows_return select_rows() // throws RecognitionException [1]
    {   
        QueryParser.select_rows_return retval = new QueryParser.select_rows_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set67 = null;
        IToken set69 = null;
        IToken char_literal74 = null;
        QueryParser.select_row_table_column_list_return select_row_table_column_list68 = null;

        QueryParser.table_name_return table_name70 = null;

        QueryParser.where_list_return where_list71 = null;

        QueryParser.order_by_list_return order_by_list72 = null;

        QueryParser.limit_range_return limit_range73 = null;


        object set67_tree=null;
        object set69_tree=null;
        object char_literal74_tree=null;


        	retval.ret = new SelectRows();
        	retval.ret.SetStatementType(StatementType.SELECT_ROW);

        try 
    	{
            // Query.g:314:1: ( ( 'select ' | 'SELECT ' ) select_row_table_column_list ( ' from ' | ' FROM ' ) table_name ( where_list )? ( order_by_list )? ( limit_range )? ';' )
            // Query.g:314:2: ( 'select ' | 'SELECT ' ) select_row_table_column_list ( ' from ' | ' FROM ' ) table_name ( where_list )? ( order_by_list )? ( limit_range )? ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set67 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 55 && input.LA(1) <= 56) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set67));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_select_row_table_column_list_in_select_rows638);
            	select_row_table_column_list68 = select_row_table_column_list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, select_row_table_column_list68.Tree);
            	 retval.ret.SetSelectRowTableColList(((select_row_table_column_list68 != null) ? select_row_table_column_list68.ret : null)); 
            	set69 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 57 && input.LA(1) <= 58) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set69));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_select_rows651);
            	table_name70 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name70.Tree);
            	 retval.ret.SetTableName(((table_name70 != null) ? table_name70.ret : null)); 
            	// Query.g:316:2: ( where_list )?
            	int alt8 = 2;
            	int LA8_0 = input.LA(1);

            	if ( ((LA8_0 >= 61 && LA8_0 <= 62)) )
            	{
            	    alt8 = 1;
            	}
            	switch (alt8) 
            	{
            	    case 1 :
            	        // Query.g:316:2: where_list
            	        {
            	        	PushFollow(FOLLOW_where_list_in_select_rows656);
            	        	where_list71 = where_list();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, where_list71.Tree);

            	        }
            	        break;

            	}

            	 retval.ret.SetWhereList(((where_list71 != null) ? where_list71.ret : null)); if( retval.ret.GetWhereList() == null)
            																	retval.ret.SetWhereListFlag(false); 
            																else 
            																	retval.ret.SetWhereListFlag(true); 
            	// Query.g:320:2: ( order_by_list )?
            	int alt9 = 2;
            	int LA9_0 = input.LA(1);

            	if ( ((LA9_0 >= 75 && LA9_0 <= 76)) )
            	{
            	    alt9 = 1;
            	}
            	switch (alt9) 
            	{
            	    case 1 :
            	        // Query.g:320:2: order_by_list
            	        {
            	        	PushFollow(FOLLOW_order_by_list_in_select_rows662);
            	        	order_by_list72 = order_by_list();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, order_by_list72.Tree);

            	        }
            	        break;

            	}

            	 retval.ret.SetOrderByList(((order_by_list72 != null) ? order_by_list72.ret : null)); 
            																if( retval.ret.GetOrderByList() == null)
            																	retval.ret.SetOrderByFlag(false);
            																else
            																	retval.ret.SetOrderByFlag(true); 
            	// Query.g:325:2: ( limit_range )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( ((LA10_0 >= 81 && LA10_0 <= 82)) )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // Query.g:325:2: limit_range
            	        {
            	        	PushFollow(FOLLOW_limit_range_in_select_rows668);
            	        	limit_range73 = limit_range();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, limit_range73.Tree);

            	        }
            	        break;

            	}

            	 retval.ret.SetLimitRange(((limit_range73 != null) ? limit_range73.ret : null)); 
            																if( retval.ret.GetLimitRange() == null)
            																	retval.ret.SetLimitRangeFlag(false);
            																else
            																	retval.ret.SetLimitRangeFlag(true);
            	char_literal74=(IToken)Match(input,41,FOLLOW_41_in_select_rows674); 
            		char_literal74_tree = (object)adaptor.Create(char_literal74);
            		adaptor.AddChild(root_0, char_literal74_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "select_rows"

    public class select_row_table_column_list_return : ParserRuleReturnScope
    {
        public SelectRowTableColList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "select_row_table_column_list"
    // Query.g:332:1: select_row_table_column_list returns [SelectRowTableColList ret] : ( '*' | col_list | count_rows );
    public QueryParser.select_row_table_column_list_return select_row_table_column_list() // throws RecognitionException [1]
    {   
        QueryParser.select_row_table_column_list_return retval = new QueryParser.select_row_table_column_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal75 = null;
        QueryParser.col_list_return col_list76 = null;

        QueryParser.count_rows_return count_rows77 = null;


        object char_literal75_tree=null;


        	retval.ret = new SelectRowTableColList(); 

        try 
    	{
            // Query.g:337:1: ( '*' | col_list | count_rows )
            int alt11 = 3;
            switch ( input.LA(1) ) 
            {
            case 59:
            	{
                alt11 = 1;
                }
                break;
            case NAME:
            	{
                alt11 = 2;
                }
                break;
            case 84:
            case 85:
            	{
                alt11 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d11s0 =
            	        new NoViableAltException("", 11, 0, input);

            	    throw nvae_d11s0;
            }

            switch (alt11) 
            {
                case 1 :
                    // Query.g:337:2: '*'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal75=(IToken)Match(input,59,FOLLOW_59_in_select_row_table_column_list691); 
                    		char_literal75_tree = (object)adaptor.Create(char_literal75);
                    		adaptor.AddChild(root_0, char_literal75_tree);

                    	 retval.ret.SetSelectRowsColumnType(SelectRowColumnType.ALL_COLUMNS);

                    }
                    break;
                case 2 :
                    // Query.g:338:4: col_list
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_col_list_in_select_row_table_column_list699);
                    	col_list76 = col_list();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, col_list76.Tree);
                    	 retval.ret.SetSelectRowsColumnType(SelectRowColumnType.SPECIFIC_COLUMNS); retval.ret.SetTableColumnList(((col_list76 != null) ? col_list76.ret : null));

                    }
                    break;
                case 3 :
                    // Query.g:339:4: count_rows
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_count_rows_in_select_row_table_column_list707);
                    	count_rows77 = count_rows();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, count_rows77.Tree);
                    	 retval.ret.SetSelectRowsColumnType(SelectRowColumnType.COUNT_ROWS); retval.ret.SetCountRows(((count_rows77 != null) ? count_rows77.ret : null));

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "select_row_table_column_list"

    public class col_list_return : ParserRuleReturnScope
    {
        public SelectColumnList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "col_list"
    // Query.g:341:1: col_list returns [SelectColumnList ret] : t1= NAME ( ', ' t2= NAME )* ;
    public QueryParser.col_list_return col_list() // throws RecognitionException [1]
    {   
        QueryParser.col_list_return retval = new QueryParser.col_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken t1 = null;
        IToken t2 = null;
        IToken string_literal78 = null;

        object t1_tree=null;
        object t2_tree=null;
        object string_literal78_tree=null;


               retval.ret = new SelectColumnList();

        try 
    	{
            // Query.g:346:1: (t1= NAME ( ', ' t2= NAME )* )
            // Query.g:346:3: t1= NAME ( ', ' t2= NAME )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	t1=(IToken)Match(input,NAME,FOLLOW_NAME_in_col_list731); 
            		t1_tree = (object)adaptor.Create(t1);
            		adaptor.AddChild(root_0, t1_tree);

            	retval.ret.AddToList(((t1 != null) ? t1.Text : null));
            	// Query.g:346:47: ( ', ' t2= NAME )*
            	do 
            	{
            	    int alt12 = 2;
            	    int LA12_0 = input.LA(1);

            	    if ( (LA12_0 == 60) )
            	    {
            	        alt12 = 1;
            	    }


            	    switch (alt12) 
            		{
            			case 1 :
            			    // Query.g:346:48: ', ' t2= NAME
            			    {
            			    	string_literal78=(IToken)Match(input,60,FOLLOW_60_in_col_list736); 
            			    		string_literal78_tree = (object)adaptor.Create(string_literal78);
            			    		adaptor.AddChild(root_0, string_literal78_tree);

            			    	t2=(IToken)Match(input,NAME,FOLLOW_NAME_in_col_list742); 
            			    		t2_tree = (object)adaptor.Create(t2);
            			    		adaptor.AddChild(root_0, t2_tree);

            			    	retval.ret.AddToList(((t2 != null) ? t2.Text : null));

            			    }
            			    break;

            			default:
            			    goto loop12;
            	    }
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "col_list"

    public class where_list_return : ParserRuleReturnScope
    {
        public WhereList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "where_list"
    // Query.g:349:1: where_list returns [WhereList ret] : ( ' WHERE ' | ' where ' ) sub_where_list ;
    public QueryParser.where_list_return where_list() // throws RecognitionException [1]
    {   
        QueryParser.where_list_return retval = new QueryParser.where_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set79 = null;
        QueryParser.sub_where_list_return sub_where_list80 = null;


        object set79_tree=null;


        	retval.ret = new WhereList();

        try 
    	{
            // Query.g:354:1: ( ( ' WHERE ' | ' where ' ) sub_where_list )
            // Query.g:354:2: ( ' WHERE ' | ' where ' ) sub_where_list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set79 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 61 && input.LA(1) <= 62) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set79));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_sub_where_list_in_where_list772);
            	sub_where_list80 = sub_where_list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, sub_where_list80.Tree);
            	 retval.ret.SetSubWhereList(((sub_where_list80 != null) ? sub_where_list80.ret : null));

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "where_list"

    public class sub_where_list_return : ParserRuleReturnScope
    {
        public SubWhereList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sub_where_list"
    // Query.g:356:1: sub_where_list returns [SubWhereList ret] : we1= where_entry ( ( ' and ' | ' AND ' ) we2= where_entry )* ;
    public QueryParser.sub_where_list_return sub_where_list() // throws RecognitionException [1]
    {   
        QueryParser.sub_where_list_return retval = new QueryParser.sub_where_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set81 = null;
        QueryParser.where_entry_return we1 = null;

        QueryParser.where_entry_return we2 = null;


        object set81_tree=null;


        	retval.ret = new SubWhereList();

        try 
    	{
            // Query.g:361:1: (we1= where_entry ( ( ' and ' | ' AND ' ) we2= where_entry )* )
            // Query.g:361:3: we1= where_entry ( ( ' and ' | ' AND ' ) we2= where_entry )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_where_entry_in_sub_where_list795);
            	we1 = where_entry();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, we1.Tree);
            	 retval.ret.AddWhereEntryList(((we1 != null) ? we1.ret : null));
            	// Query.g:362:2: ( ( ' and ' | ' AND ' ) we2= where_entry )*
            	do 
            	{
            	    int alt13 = 2;
            	    int LA13_0 = input.LA(1);

            	    if ( ((LA13_0 >= 63 && LA13_0 <= 64)) )
            	    {
            	        alt13 = 1;
            	    }


            	    switch (alt13) 
            		{
            			case 1 :
            			    // Query.g:362:3: ( ' and ' | ' AND ' ) we2= where_entry
            			    {
            			    	set81 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 63 && input.LA(1) <= 64) ) 
            			    	{
            			    	    input.Consume();
            			    	    adaptor.AddChild(root_0, (object)adaptor.Create(set81));
            			    	    state.errorRecovery = false;
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_where_entry_in_sub_where_list814);
            			    	we2 = where_entry();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, we2.Tree);
            			    	 retval.ret.AddWhereEntryList(((we2 != null) ? we2.ret : null));

            			    }
            			    break;

            			default:
            			    goto loop13;
            	    }
            	} while (true);

            	loop13:
            		;	// Stops C# compiler whining that label 'loop13' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "sub_where_list"

    public class where_entry_return : ParserRuleReturnScope
    {
        public WhereEntry ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "where_entry"
    // Query.g:364:1: where_entry returns [WhereEntry ret] : NAME ( '=' | '<' | '>' | '<=' | '>=' | ' = ' | ' < ' | ' > ' | ' <= ' | ' >= ' ) column_value ;
    public QueryParser.where_entry_return where_entry() // throws RecognitionException [1]
    {   
        QueryParser.where_entry_return retval = new QueryParser.where_entry_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken NAME82 = null;
        IToken char_literal83 = null;
        IToken char_literal84 = null;
        IToken char_literal85 = null;
        IToken string_literal86 = null;
        IToken string_literal87 = null;
        IToken string_literal88 = null;
        IToken string_literal89 = null;
        IToken string_literal90 = null;
        IToken string_literal91 = null;
        IToken string_literal92 = null;
        QueryParser.column_value_return column_value93 = null;


        object NAME82_tree=null;
        object char_literal83_tree=null;
        object char_literal84_tree=null;
        object char_literal85_tree=null;
        object string_literal86_tree=null;
        object string_literal87_tree=null;
        object string_literal88_tree=null;
        object string_literal89_tree=null;
        object string_literal90_tree=null;
        object string_literal91_tree=null;
        object string_literal92_tree=null;


        	retval.ret = new WhereEntry();

        try 
    	{
            // Query.g:369:1: ( NAME ( '=' | '<' | '>' | '<=' | '>=' | ' = ' | ' < ' | ' > ' | ' <= ' | ' >= ' ) column_value )
            // Query.g:369:3: NAME ( '=' | '<' | '>' | '<=' | '>=' | ' = ' | ' < ' | ' > ' | ' <= ' | ' >= ' ) column_value
            {
            	root_0 = (object)adaptor.GetNilNode();

            	NAME82=(IToken)Match(input,NAME,FOLLOW_NAME_in_where_entry835); 
            		NAME82_tree = (object)adaptor.Create(NAME82);
            		adaptor.AddChild(root_0, NAME82_tree);

            	retval.ret.SetColumnName(((NAME82 != null) ? NAME82.Text : null));
            	// Query.g:370:2: ( '=' | '<' | '>' | '<=' | '>=' | ' = ' | ' < ' | ' > ' | ' <= ' | ' >= ' )
            	int alt14 = 10;
            	switch ( input.LA(1) ) 
            	{
            	case 65:
            		{
            	    alt14 = 1;
            	    }
            	    break;
            	case 66:
            		{
            	    alt14 = 2;
            	    }
            	    break;
            	case 67:
            		{
            	    alt14 = 3;
            	    }
            	    break;
            	case 68:
            		{
            	    alt14 = 4;
            	    }
            	    break;
            	case 69:
            		{
            	    alt14 = 5;
            	    }
            	    break;
            	case 70:
            		{
            	    alt14 = 6;
            	    }
            	    break;
            	case 71:
            		{
            	    alt14 = 7;
            	    }
            	    break;
            	case 72:
            		{
            	    alt14 = 8;
            	    }
            	    break;
            	case 73:
            		{
            	    alt14 = 9;
            	    }
            	    break;
            	case 74:
            		{
            	    alt14 = 10;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d14s0 =
            		        new NoViableAltException("", 14, 0, input);

            		    throw nvae_d14s0;
            	}

            	switch (alt14) 
            	{
            	    case 1 :
            	        // Query.g:370:3: '='
            	        {
            	        	char_literal83=(IToken)Match(input,65,FOLLOW_65_in_where_entry842); 
            	        		char_literal83_tree = (object)adaptor.Create(char_literal83);
            	        		adaptor.AddChild(root_0, char_literal83_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.EQUALITY);

            	        }
            	        break;
            	    case 2 :
            	        // Query.g:371:3: '<'
            	        {
            	        	char_literal84=(IToken)Match(input,66,FOLLOW_66_in_where_entry848); 
            	        		char_literal84_tree = (object)adaptor.Create(char_literal84);
            	        		adaptor.AddChild(root_0, char_literal84_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.LESS_THAN);

            	        }
            	        break;
            	    case 3 :
            	        // Query.g:372:3: '>'
            	        {
            	        	char_literal85=(IToken)Match(input,67,FOLLOW_67_in_where_entry854); 
            	        		char_literal85_tree = (object)adaptor.Create(char_literal85);
            	        		adaptor.AddChild(root_0, char_literal85_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.GREATER_THAN);

            	        }
            	        break;
            	    case 4 :
            	        // Query.g:373:3: '<='
            	        {
            	        	string_literal86=(IToken)Match(input,68,FOLLOW_68_in_where_entry860); 
            	        		string_literal86_tree = (object)adaptor.Create(string_literal86);
            	        		adaptor.AddChild(root_0, string_literal86_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.LESS_THAN_EQUAL);

            	        }
            	        break;
            	    case 5 :
            	        // Query.g:374:3: '>='
            	        {
            	        	string_literal87=(IToken)Match(input,69,FOLLOW_69_in_where_entry866); 
            	        		string_literal87_tree = (object)adaptor.Create(string_literal87);
            	        		adaptor.AddChild(root_0, string_literal87_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.GREATER_THAN_EQUAL);

            	        }
            	        break;
            	    case 6 :
            	        // Query.g:375:3: ' = '
            	        {
            	        	string_literal88=(IToken)Match(input,70,FOLLOW_70_in_where_entry872); 
            	        		string_literal88_tree = (object)adaptor.Create(string_literal88);
            	        		adaptor.AddChild(root_0, string_literal88_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.EQUALITY);

            	        }
            	        break;
            	    case 7 :
            	        // Query.g:376:3: ' < '
            	        {
            	        	string_literal89=(IToken)Match(input,71,FOLLOW_71_in_where_entry878); 
            	        		string_literal89_tree = (object)adaptor.Create(string_literal89);
            	        		adaptor.AddChild(root_0, string_literal89_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.LESS_THAN);

            	        }
            	        break;
            	    case 8 :
            	        // Query.g:377:3: ' > '
            	        {
            	        	string_literal90=(IToken)Match(input,72,FOLLOW_72_in_where_entry884); 
            	        		string_literal90_tree = (object)adaptor.Create(string_literal90);
            	        		adaptor.AddChild(root_0, string_literal90_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.GREATER_THAN);

            	        }
            	        break;
            	    case 9 :
            	        // Query.g:378:3: ' <= '
            	        {
            	        	string_literal91=(IToken)Match(input,73,FOLLOW_73_in_where_entry890); 
            	        		string_literal91_tree = (object)adaptor.Create(string_literal91);
            	        		adaptor.AddChild(root_0, string_literal91_tree);

            	        	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.LESS_THAN_EQUAL);

            	        }
            	        break;
            	    case 10 :
            	        // Query.g:379:3: ' >= '
            	        {
            	        	string_literal92=(IToken)Match(input,74,FOLLOW_74_in_where_entry896); 
            	        		string_literal92_tree = (object)adaptor.Create(string_literal92);
            	        		adaptor.AddChild(root_0, string_literal92_tree);


            	        }
            	        break;

            	}

            	 retval.ret.SetComparisonOperatorType(ComparisonOperatorType.GREATER_THAN_EQUAL);
            	PushFollow(FOLLOW_column_value_in_where_entry902);
            	column_value93 = column_value();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, column_value93.Tree);
            	retval.ret.SetColumnValue(((column_value93 != null) ? column_value93.ret : null));

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "where_entry"

    public class column_value_return : ParserRuleReturnScope
    {
        public ColumnValue ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "column_value"
    // Query.g:382:1: column_value returns [ColumnValue ret] : ( NUMBER | NAME | (t1= NUMBER '.' t2= NUMBER ) );
    public QueryParser.column_value_return column_value() // throws RecognitionException [1]
    {   
        QueryParser.column_value_return retval = new QueryParser.column_value_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken t1 = null;
        IToken t2 = null;
        IToken NUMBER94 = null;
        IToken NAME95 = null;
        IToken char_literal96 = null;

        object t1_tree=null;
        object t2_tree=null;
        object NUMBER94_tree=null;
        object NAME95_tree=null;
        object char_literal96_tree=null;


        	retval.ret = new ColumnValue();

        try 
    	{
            // Query.g:387:1: ( NUMBER | NAME | (t1= NUMBER '.' t2= NUMBER ) )
            int alt15 = 3;
            int LA15_0 = input.LA(1);

            if ( (LA15_0 == NUMBER) )
            {
                int LA15_1 = input.LA(2);

                if ( (LA15_1 == 44) )
                {
                    alt15 = 3;
                }
                else if ( (LA15_1 == EOF || (LA15_1 >= 10 && LA15_1 <= 11) || LA15_1 == 41 || (LA15_1 >= 61 && LA15_1 <= 64) || (LA15_1 >= 75 && LA15_1 <= 76) || (LA15_1 >= 81 && LA15_1 <= 82) || (LA15_1 >= 90 && LA15_1 <= 91)) )
                {
                    alt15 = 1;
                }
                else 
                {
                    NoViableAltException nvae_d15s1 =
                        new NoViableAltException("", 15, 1, input);

                    throw nvae_d15s1;
                }
            }
            else if ( (LA15_0 == NAME) )
            {
                alt15 = 2;
            }
            else 
            {
                NoViableAltException nvae_d15s0 =
                    new NoViableAltException("", 15, 0, input);

                throw nvae_d15s0;
            }
            switch (alt15) 
            {
                case 1 :
                    // Query.g:387:3: NUMBER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NUMBER94=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_column_value922); 
                    		NUMBER94_tree = (object)adaptor.Create(NUMBER94);
                    		adaptor.AddChild(root_0, NUMBER94_tree);

                    	 retval.ret.SetColumnValueType(ColValueType.INTEGER); retval.ret.SetIntColumnValue(((NUMBER94 != null) ? NUMBER94.Text : null)); 

                    }
                    break;
                case 2 :
                    // Query.g:388:3: NAME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NAME95=(IToken)Match(input,NAME,FOLLOW_NAME_in_column_value929); 
                    		NAME95_tree = (object)adaptor.Create(NAME95);
                    		adaptor.AddChild(root_0, NAME95_tree);

                    	 retval.ret.SetColumnValueType(ColValueType.STRING); retval.ret.SetStringColumnValue(((NAME95 != null) ? NAME95.Text : null)); 

                    }
                    break;
                case 3 :
                    // Query.g:389:3: (t1= NUMBER '.' t2= NUMBER )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// Query.g:389:3: (t1= NUMBER '.' t2= NUMBER )
                    	// Query.g:389:4: t1= NUMBER '.' t2= NUMBER
                    	{
                    		t1=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_column_value940); 
                    			t1_tree = (object)adaptor.Create(t1);
                    			adaptor.AddChild(root_0, t1_tree);

                    		char_literal96=(IToken)Match(input,44,FOLLOW_44_in_column_value942); 
                    			char_literal96_tree = (object)adaptor.Create(char_literal96);
                    			adaptor.AddChild(root_0, char_literal96_tree);

                    		t2=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_column_value948); 
                    			t2_tree = (object)adaptor.Create(t2);
                    			adaptor.AddChild(root_0, t2_tree);


                    	}

                    	 retval.ret.SetColumnValueType(ColValueType.DOUBLE); retval.ret.SetDoubleColumnValue(((t1 != null) ? t1.Text : null) + "." + ((t2 != null) ? t2.Text : null)); 

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "column_value"

    public class order_by_list_return : ParserRuleReturnScope
    {
        public OrderByList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "order_by_list"
    // Query.g:391:1: order_by_list returns [OrderByList ret] : ( ' order by ' | ' ORDER BY ' ) sub_order_by_list ;
    public QueryParser.order_by_list_return order_by_list() // throws RecognitionException [1]
    {   
        QueryParser.order_by_list_return retval = new QueryParser.order_by_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set97 = null;
        QueryParser.sub_order_by_list_return sub_order_by_list98 = null;


        object set97_tree=null;


        	retval.ret = new OrderByList();

        try 
    	{
            // Query.g:396:1: ( ( ' order by ' | ' ORDER BY ' ) sub_order_by_list )
            // Query.g:396:2: ( ' order by ' | ' ORDER BY ' ) sub_order_by_list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set97 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 75 && input.LA(1) <= 76) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set97));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_sub_order_by_list_in_order_by_list976);
            	sub_order_by_list98 = sub_order_by_list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, sub_order_by_list98.Tree);
            	 retval.ret.SetSubOrderByList(((sub_order_by_list98 != null) ? sub_order_by_list98.ret : null));

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "order_by_list"

    public class sub_order_by_list_return : ParserRuleReturnScope
    {
        public SubOrderByList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sub_order_by_list"
    // Query.g:398:1: sub_order_by_list returns [SubOrderByList ret] : obe1= order_by_entry ( ( ', ' ) obe2= order_by_entry )* ;
    public QueryParser.sub_order_by_list_return sub_order_by_list() // throws RecognitionException [1]
    {   
        QueryParser.sub_order_by_list_return retval = new QueryParser.sub_order_by_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken string_literal99 = null;
        QueryParser.order_by_entry_return obe1 = null;

        QueryParser.order_by_entry_return obe2 = null;


        object string_literal99_tree=null;


        	retval.ret = new SubOrderByList();

        try 
    	{
            // Query.g:403:1: (obe1= order_by_entry ( ( ', ' ) obe2= order_by_entry )* )
            // Query.g:403:3: obe1= order_by_entry ( ( ', ' ) obe2= order_by_entry )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_order_by_entry_in_sub_order_by_list999);
            	obe1 = order_by_entry();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, obe1.Tree);
            	 retval.ret.AddOrderByEntryList(((obe1 != null) ? obe1.ret : null));
            	// Query.g:404:2: ( ( ', ' ) obe2= order_by_entry )*
            	do 
            	{
            	    int alt16 = 2;
            	    int LA16_0 = input.LA(1);

            	    if ( (LA16_0 == 60) )
            	    {
            	        alt16 = 1;
            	    }


            	    switch (alt16) 
            		{
            			case 1 :
            			    // Query.g:404:3: ( ', ' ) obe2= order_by_entry
            			    {
            			    	// Query.g:404:3: ( ', ' )
            			    	// Query.g:404:4: ', '
            			    	{
            			    		string_literal99=(IToken)Match(input,60,FOLLOW_60_in_sub_order_by_list1007); 
            			    			string_literal99_tree = (object)adaptor.Create(string_literal99);
            			    			adaptor.AddChild(root_0, string_literal99_tree);


            			    	}

            			    	PushFollow(FOLLOW_order_by_entry_in_sub_order_by_list1014);
            			    	obe2 = order_by_entry();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, obe2.Tree);
            			    	 retval.ret.AddOrderByEntryList(((obe2 != null) ? obe2.ret : null));

            			    }
            			    break;

            			default:
            			    goto loop16;
            	    }
            	} while (true);

            	loop16:
            		;	// Stops C# compiler whining that label 'loop16' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "sub_order_by_list"

    public class order_by_entry_return : ParserRuleReturnScope
    {
        public OrderByEntry ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "order_by_entry"
    // Query.g:406:1: order_by_entry returns [OrderByEntry ret] : NAME ( ( ' asc' | ' ASC' ) | ( ' dsc' | ' DSC' ) ) ;
    public QueryParser.order_by_entry_return order_by_entry() // throws RecognitionException [1]
    {   
        QueryParser.order_by_entry_return retval = new QueryParser.order_by_entry_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken NAME100 = null;
        IToken set101 = null;
        IToken set102 = null;

        object NAME100_tree=null;
        object set101_tree=null;
        object set102_tree=null;


        	retval.ret = new OrderByEntry();

        try 
    	{
            // Query.g:411:1: ( NAME ( ( ' asc' | ' ASC' ) | ( ' dsc' | ' DSC' ) ) )
            // Query.g:411:2: NAME ( ( ' asc' | ' ASC' ) | ( ' dsc' | ' DSC' ) )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	NAME100=(IToken)Match(input,NAME,FOLLOW_NAME_in_order_by_entry1034); 
            		NAME100_tree = (object)adaptor.Create(NAME100);
            		adaptor.AddChild(root_0, NAME100_tree);

            	 retval.ret.SetColumnName(((NAME100 != null) ? NAME100.Text : null)); 
            	// Query.g:411:49: ( ( ' asc' | ' ASC' ) | ( ' dsc' | ' DSC' ) )
            	int alt17 = 2;
            	int LA17_0 = input.LA(1);

            	if ( ((LA17_0 >= 77 && LA17_0 <= 78)) )
            	{
            	    alt17 = 1;
            	}
            	else if ( ((LA17_0 >= 79 && LA17_0 <= 80)) )
            	{
            	    alt17 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d17s0 =
            	        new NoViableAltException("", 17, 0, input);

            	    throw nvae_d17s0;
            	}
            	switch (alt17) 
            	{
            	    case 1 :
            	        // Query.g:411:50: ( ' asc' | ' ASC' )
            	        {
            	        	set101 = (IToken)input.LT(1);
            	        	if ( (input.LA(1) >= 77 && input.LA(1) <= 78) ) 
            	        	{
            	        	    input.Consume();
            	        	    adaptor.AddChild(root_0, (object)adaptor.Create(set101));
            	        	    state.errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    throw mse;
            	        	}

            	        	 retval.ret.SetOrderByType("ASC");

            	        }
            	        break;
            	    case 2 :
            	        // Query.g:411:104: ( ' dsc' | ' DSC' )
            	        {
            	        	set102 = (IToken)input.LT(1);
            	        	if ( (input.LA(1) >= 79 && input.LA(1) <= 80) ) 
            	        	{
            	        	    input.Consume();
            	        	    adaptor.AddChild(root_0, (object)adaptor.Create(set102));
            	        	    state.errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    throw mse;
            	        	}

            	        	 retval.ret.SetOrderByType("DSC");

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "order_by_entry"

    public class limit_range_return : ParserRuleReturnScope
    {
        public LimitRange ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "limit_range"
    // Query.g:414:1: limit_range returns [LimitRange ret] : ( 'LIMIT' | 'limit' ) n1= NUMBER ' , ' n2= NUMBER ;
    public QueryParser.limit_range_return limit_range() // throws RecognitionException [1]
    {   
        QueryParser.limit_range_return retval = new QueryParser.limit_range_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken n1 = null;
        IToken n2 = null;
        IToken set103 = null;
        IToken string_literal104 = null;

        object n1_tree=null;
        object n2_tree=null;
        object set103_tree=null;
        object string_literal104_tree=null;


        	retval.ret = new LimitRange();

        try 
    	{
            // Query.g:419:1: ( ( 'LIMIT' | 'limit' ) n1= NUMBER ' , ' n2= NUMBER )
            // Query.g:419:2: ( 'LIMIT' | 'limit' ) n1= NUMBER ' , ' n2= NUMBER
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set103 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 81 && input.LA(1) <= 82) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set103));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	n1=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_limit_range1094); 
            		n1_tree = (object)adaptor.Create(n1);
            		adaptor.AddChild(root_0, n1_tree);

            	 retval.ret.SetStartIndex(((n1 != null) ? n1.Text : null)); 
            	string_literal104=(IToken)Match(input,83,FOLLOW_83_in_limit_range1097); 
            		string_literal104_tree = (object)adaptor.Create(string_literal104);
            		adaptor.AddChild(root_0, string_literal104_tree);

            	n2=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_limit_range1103); 
            		n2_tree = (object)adaptor.Create(n2);
            		adaptor.AddChild(root_0, n2_tree);

            	 retval.ret.SetCount(((n2 != null) ? n2.Text : null));

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "limit_range"

    public class count_rows_return : ParserRuleReturnScope
    {
        public CountRows ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "count_rows"
    // Query.g:421:1: count_rows returns [CountRows ret] : ( 'COUNT(' | 'count(' ) ( NAME | '*' ) ')' ;
    public QueryParser.count_rows_return count_rows() // throws RecognitionException [1]
    {   
        QueryParser.count_rows_return retval = new QueryParser.count_rows_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set105 = null;
        IToken NAME106 = null;
        IToken char_literal107 = null;
        IToken char_literal108 = null;

        object set105_tree=null;
        object NAME106_tree=null;
        object char_literal107_tree=null;
        object char_literal108_tree=null;


        	retval.ret =  new CountRows();

        try 
    	{
            // Query.g:426:1: ( ( 'COUNT(' | 'count(' ) ( NAME | '*' ) ')' )
            // Query.g:426:2: ( 'COUNT(' | 'count(' ) ( NAME | '*' ) ')'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set105 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 84 && input.LA(1) <= 85) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set105));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	// Query.g:426:24: ( NAME | '*' )
            	int alt18 = 2;
            	int LA18_0 = input.LA(1);

            	if ( (LA18_0 == NAME) )
            	{
            	    alt18 = 1;
            	}
            	else if ( (LA18_0 == 59) )
            	{
            	    alt18 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d18s0 =
            	        new NoViableAltException("", 18, 0, input);

            	    throw nvae_d18s0;
            	}
            	switch (alt18) 
            	{
            	    case 1 :
            	        // Query.g:426:26: NAME
            	        {
            	        	NAME106=(IToken)Match(input,NAME,FOLLOW_NAME_in_count_rows1132); 
            	        		NAME106_tree = (object)adaptor.Create(NAME106);
            	        		adaptor.AddChild(root_0, NAME106_tree);

            	        	 retval.ret.SetColumnName(((NAME106 != null) ? NAME106.Text : null)); retval.ret.SetCountAllRowsFlag(false); 

            	        }
            	        break;
            	    case 2 :
            	        // Query.g:427:9: '*'
            	        {
            	        	char_literal107=(IToken)Match(input,59,FOLLOW_59_in_count_rows1145); 
            	        		char_literal107_tree = (object)adaptor.Create(char_literal107);
            	        		adaptor.AddChild(root_0, char_literal107_tree);

            	        	 retval.ret.SetCountAllRowsFlag(true);

            	        }
            	        break;

            	}

            	char_literal108=(IToken)Match(input,31,FOLLOW_31_in_count_rows1150); 
            		char_literal108_tree = (object)adaptor.Create(char_literal108);
            		adaptor.AddChild(root_0, char_literal108_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "count_rows"

    public class update_row_return : ParserRuleReturnScope
    {
        public UpdateRows ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "update_row"
    // Query.g:430:1: update_row returns [UpdateRows ret] : ( 'UPDATE' | 'update' ) table_name ( 'SET' | 'set' ) set_list ( where_list )? ';' ;
    public QueryParser.update_row_return update_row() // throws RecognitionException [1]
    {   
        QueryParser.update_row_return retval = new QueryParser.update_row_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set109 = null;
        IToken set111 = null;
        IToken char_literal114 = null;
        QueryParser.table_name_return table_name110 = null;

        QueryParser.set_list_return set_list112 = null;

        QueryParser.where_list_return where_list113 = null;


        object set109_tree=null;
        object set111_tree=null;
        object char_literal114_tree=null;


        	retval.ret = new UpdateRows();
        	retval.ret.SetStatementType(StatementType.UPDATE_ROW);
        	retval.ret.SetWhereListFlag(false);

        try 
    	{
            // Query.g:437:1: ( ( 'UPDATE' | 'update' ) table_name ( 'SET' | 'set' ) set_list ( where_list )? ';' )
            // Query.g:437:3: ( 'UPDATE' | 'update' ) table_name ( 'SET' | 'set' ) set_list ( where_list )? ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set109 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 86 && input.LA(1) <= 87) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set109));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_update_row1179);
            	table_name110 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name110.Tree);
            	 retval.ret.SetTableName(((table_name110 != null) ? table_name110.ret : null));
            	set111 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 88 && input.LA(1) <= 89) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set111));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_set_list_in_update_row1196);
            	set_list112 = set_list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, set_list112.Tree);
            	 retval.ret.SetSetList(((set_list112 != null) ? set_list112.ret : null)); 
            	// Query.g:439:3: ( where_list )?
            	int alt19 = 2;
            	int LA19_0 = input.LA(1);

            	if ( ((LA19_0 >= 61 && LA19_0 <= 62)) )
            	{
            	    alt19 = 1;
            	}
            	switch (alt19) 
            	{
            	    case 1 :
            	        // Query.g:439:3: where_list
            	        {
            	        	PushFollow(FOLLOW_where_list_in_update_row1203);
            	        	where_list113 = where_list();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, where_list113.Tree);

            	        }
            	        break;

            	}

            	 retval.ret.SetWhereList(((where_list113 != null) ? where_list113.ret : null)); retval.ret.SetWhereListFlag(true);
            	char_literal114=(IToken)Match(input,41,FOLLOW_41_in_update_row1207); 
            		char_literal114_tree = (object)adaptor.Create(char_literal114);
            		adaptor.AddChild(root_0, char_literal114_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "update_row"

    public class set_list_return : ParserRuleReturnScope
    {
        public SetList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "set_list"
    // Query.g:441:1: set_list returns [SetList ret] : se1= set_entry ( ( 'AND' | 'and' ) se2= set_entry )* ;
    public QueryParser.set_list_return set_list() // throws RecognitionException [1]
    {   
        QueryParser.set_list_return retval = new QueryParser.set_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set115 = null;
        QueryParser.set_entry_return se1 = null;

        QueryParser.set_entry_return se2 = null;


        object set115_tree=null;


        	retval.ret = new SetList();

        try 
    	{
            // Query.g:446:1: (se1= set_entry ( ( 'AND' | 'and' ) se2= set_entry )* )
            // Query.g:446:3: se1= set_entry ( ( 'AND' | 'and' ) se2= set_entry )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_set_entry_in_set_list1229);
            	se1 = set_entry();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, se1.Tree);
            	 retval.ret.AddSetEntryList(((se1 != null) ? se1.ret : null));
            	// Query.g:446:60: ( ( 'AND' | 'and' ) se2= set_entry )*
            	do 
            	{
            	    int alt20 = 2;
            	    int LA20_0 = input.LA(1);

            	    if ( ((LA20_0 >= 90 && LA20_0 <= 91)) )
            	    {
            	        alt20 = 1;
            	    }


            	    switch (alt20) 
            		{
            			case 1 :
            			    // Query.g:446:61: ( 'AND' | 'and' ) se2= set_entry
            			    {
            			    	set115 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 90 && input.LA(1) <= 91) ) 
            			    	{
            			    	    input.Consume();
            			    	    adaptor.AddChild(root_0, (object)adaptor.Create(set115));
            			    	    state.errorRecovery = false;
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_set_entry_in_set_list1248);
            			    	se2 = set_entry();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, se2.Tree);
            			    	 retval.ret.AddSetEntryList(((se2 != null) ? se2.ret : null));

            			    }
            			    break;

            			default:
            			    goto loop20;
            	    }
            	} while (true);

            	loop20:
            		;	// Stops C# compiler whining that label 'loop20' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "set_list"

    public class set_entry_return : ParserRuleReturnScope
    {
        public SetEntry ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "set_entry"
    // Query.g:448:1: set_entry returns [SetEntry ret] : NAME ( '=' | ' = ' ) column_value ;
    public QueryParser.set_entry_return set_entry() // throws RecognitionException [1]
    {   
        QueryParser.set_entry_return retval = new QueryParser.set_entry_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken NAME116 = null;
        IToken set117 = null;
        QueryParser.column_value_return column_value118 = null;


        object NAME116_tree=null;
        object set117_tree=null;


        	retval.ret = new SetEntry();

        try 
    	{
            // Query.g:453:1: ( NAME ( '=' | ' = ' ) column_value )
            // Query.g:453:3: NAME ( '=' | ' = ' ) column_value
            {
            	root_0 = (object)adaptor.GetNilNode();

            	NAME116=(IToken)Match(input,NAME,FOLLOW_NAME_in_set_entry1270); 
            		NAME116_tree = (object)adaptor.Create(NAME116);
            		adaptor.AddChild(root_0, NAME116_tree);

            	 retval.ret.SetColumnName(((NAME116 != null) ? NAME116.Text : null)); 
            	set117 = (IToken)input.LT(1);
            	if ( input.LA(1) == 65 || input.LA(1) == 70 ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set117));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_column_value_in_set_entry1280);
            	column_value118 = column_value();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, column_value118.Tree);
            	 retval.ret.SetColumnValue(((column_value118 != null) ? column_value118.ret : null));

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "set_entry"

    public class delete_row_return : ParserRuleReturnScope
    {
        public DeleteRows ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "delete_row"
    // Query.g:455:1: delete_row returns [DeleteRows ret] : ( 'delete' | 'DELETE' ) ( 'from' | 'FROM' ) table_name ( where_list )? ;
    public QueryParser.delete_row_return delete_row() // throws RecognitionException [1]
    {   
        QueryParser.delete_row_return retval = new QueryParser.delete_row_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set119 = null;
        IToken set120 = null;
        QueryParser.table_name_return table_name121 = null;

        QueryParser.where_list_return where_list122 = null;


        object set119_tree=null;
        object set120_tree=null;


        	retval.ret = new DeleteRows();
        	retval.ret.SetStatementType(StatementType.DELETE_ROWS);
        	retval.ret.SetWhereListFlag(false);

        try 
    	{
            // Query.g:462:1: ( ( 'delete' | 'DELETE' ) ( 'from' | 'FROM' ) table_name ( where_list )? )
            // Query.g:462:3: ( 'delete' | 'DELETE' ) ( 'from' | 'FROM' ) table_name ( where_list )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set119 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 92 && input.LA(1) <= 93) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set119));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	set120 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 94 && input.LA(1) <= 95) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set120));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_delete_row1319);
            	table_name121 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name121.Tree);
            	 retval.ret.SetTableName(((table_name121 != null) ? table_name121.ret : null));
            	// Query.g:462:102: ( where_list )?
            	int alt21 = 2;
            	int LA21_0 = input.LA(1);

            	if ( ((LA21_0 >= 61 && LA21_0 <= 62)) )
            	{
            	    alt21 = 1;
            	}
            	switch (alt21) 
            	{
            	    case 1 :
            	        // Query.g:462:102: where_list
            	        {
            	        	PushFollow(FOLLOW_where_list_in_delete_row1323);
            	        	where_list122 = where_list();
            	        	state.followingStackPointer--;

            	        	adaptor.AddChild(root_0, where_list122.Tree);

            	        }
            	        break;

            	}

            	 retval.ret.SetWhereList(((where_list122 != null) ? where_list122.ret : null)); retval.ret.SetWhereListFlag(true);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "delete_row"

    public class insert_row_return : ParserRuleReturnScope
    {
        public InsertRow ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "insert_row"
    // Query.g:464:1: insert_row returns [InsertRow ret] : ( 'insert into' | 'INSERT INTO' ) table_name '(' table_column_list ')' ( 'values' | 'VALUES' ) '(' column_value_list ');' ;
    public QueryParser.insert_row_return insert_row() // throws RecognitionException [1]
    {   
        QueryParser.insert_row_return retval = new QueryParser.insert_row_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set123 = null;
        IToken char_literal125 = null;
        IToken char_literal127 = null;
        IToken set128 = null;
        IToken char_literal129 = null;
        IToken string_literal131 = null;
        QueryParser.table_name_return table_name124 = null;

        QueryParser.table_column_list_return table_column_list126 = null;

        QueryParser.column_value_list_return column_value_list130 = null;


        object set123_tree=null;
        object char_literal125_tree=null;
        object char_literal127_tree=null;
        object set128_tree=null;
        object char_literal129_tree=null;
        object string_literal131_tree=null;


        retval.ret = new InsertRow();
        retval.ret.SetStatementType(StatementType.INSERT_ROW);

        try 
    	{
            // Query.g:470:1: ( ( 'insert into' | 'INSERT INTO' ) table_name '(' table_column_list ')' ( 'values' | 'VALUES' ) '(' column_value_list ');' )
            // Query.g:470:2: ( 'insert into' | 'INSERT INTO' ) table_name '(' table_column_list ')' ( 'values' | 'VALUES' ) '(' column_value_list ');'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set123 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 96 && input.LA(1) <= 97) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set123));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_insert_row1347);
            	table_name124 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name124.Tree);

            	retval.ret.SetTableName(((table_name124 != null) ? table_name124.ret : null).GetTableName());

            	char_literal125=(IToken)Match(input,9,FOLLOW_9_in_insert_row1350); 
            		char_literal125_tree = (object)adaptor.Create(char_literal125);
            		adaptor.AddChild(root_0, char_literal125_tree);

            	PushFollow(FOLLOW_table_column_list_in_insert_row1352);
            	table_column_list126 = table_column_list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_column_list126.Tree);

            	retval.ret.SetList(((table_column_list126 != null) ? table_column_list126.ret : null).GetColumnList());

            	char_literal127=(IToken)Match(input,31,FOLLOW_31_in_insert_row1355); 
            		char_literal127_tree = (object)adaptor.Create(char_literal127);
            		adaptor.AddChild(root_0, char_literal127_tree);

            	set128 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 98 && input.LA(1) <= 99) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set128));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	char_literal129=(IToken)Match(input,9,FOLLOW_9_in_insert_row1363); 
            		char_literal129_tree = (object)adaptor.Create(char_literal129);
            		adaptor.AddChild(root_0, char_literal129_tree);

            	PushFollow(FOLLOW_column_value_list_in_insert_row1365);
            	column_value_list130 = column_value_list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, column_value_list130.Tree);

            	retval.ret.SetValueList(((column_value_list130 != null) ? column_value_list130.ret : null).GetColumnValue());

            	string_literal131=(IToken)Match(input,10,FOLLOW_10_in_insert_row1368); 
            		string_literal131_tree = (object)adaptor.Create(string_literal131);
            		adaptor.AddChild(root_0, string_literal131_tree);


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "insert_row"

    public class table_column_list_return : ParserRuleReturnScope
    {
        public ColumnList_Ins ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "table_column_list"
    // Query.g:483:1: table_column_list returns [ColumnList_Ins ret] : t1= column_name ( ',' t2= column_name )* ;
    public QueryParser.table_column_list_return table_column_list() // throws RecognitionException [1]
    {   
        QueryParser.table_column_list_return retval = new QueryParser.table_column_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal132 = null;
        QueryParser.column_name_return t1 = null;

        QueryParser.column_name_return t2 = null;


        object char_literal132_tree=null;


        	retval.ret = new ColumnList_Ins();

        try 
    	{
            // Query.g:488:1: (t1= column_name ( ',' t2= column_name )* )
            // Query.g:488:2: t1= column_name ( ',' t2= column_name )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_column_name_in_table_column_list1389);
            	t1 = column_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, t1.Tree);

            	retval.ret.AddToList(((t1 != null) ? t1.ret : null).GetColumnName());

            	// Query.g:491:1: ( ',' t2= column_name )*
            	do 
            	{
            	    int alt22 = 2;
            	    int LA22_0 = input.LA(1);

            	    if ( (LA22_0 == 11) )
            	    {
            	        alt22 = 1;
            	    }


            	    switch (alt22) 
            		{
            			case 1 :
            			    // Query.g:491:2: ',' t2= column_name
            			    {
            			    	char_literal132=(IToken)Match(input,11,FOLLOW_11_in_table_column_list1393); 
            			    		char_literal132_tree = (object)adaptor.Create(char_literal132);
            			    		adaptor.AddChild(root_0, char_literal132_tree);

            			    	PushFollow(FOLLOW_column_name_in_table_column_list1399);
            			    	t2 = column_name();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, t2.Tree);

            			    	retval.ret.AddToList(((t2 != null) ? t2.ret : null).GetColumnName());


            			    }
            			    break;

            			default:
            			    goto loop22;
            	    }
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "table_column_list"

    public class column_name_return : ParserRuleReturnScope
    {
        public ColumnName ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "column_name"
    // Query.g:496:1: column_name returns [ColumnName ret] : NAME ;
    public QueryParser.column_name_return column_name() // throws RecognitionException [1]
    {   
        QueryParser.column_name_return retval = new QueryParser.column_name_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken NAME133 = null;

        object NAME133_tree=null;


        	retval.ret = new ColumnName();

        try 
    	{
            // Query.g:501:1: ( NAME )
            // Query.g:501:2: NAME
            {
            	root_0 = (object)adaptor.GetNilNode();

            	NAME133=(IToken)Match(input,NAME,FOLLOW_NAME_in_column_name1419); 
            		NAME133_tree = (object)adaptor.Create(NAME133);
            		adaptor.AddChild(root_0, NAME133_tree);


            	if(((NAME133 != null) ? NAME133.Text : null) == "<missing NAME>")
            	{		
            		QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Column Name.");
            		throw qpe;
            	}
            	else
            	{	retval.ret.SetColumnName(((NAME133 != null) ? NAME133.Text : null));
            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "column_name"

    public class column_value_list_return : ParserRuleReturnScope
    {
        public ColumnValueList ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "column_value_list"
    // Query.g:513:1: column_value_list returns [ColumnValueList ret] : c1= column_value ( ',' c2= column_value )* ;
    public QueryParser.column_value_list_return column_value_list() // throws RecognitionException [1]
    {   
        QueryParser.column_value_list_return retval = new QueryParser.column_value_list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal134 = null;
        QueryParser.column_value_return c1 = null;

        QueryParser.column_value_return c2 = null;


        object char_literal134_tree=null;


        retval.ret = new ColumnValueList();

        try 
    	{
            // Query.g:518:1: (c1= column_value ( ',' c2= column_value )* )
            // Query.g:518:2: c1= column_value ( ',' c2= column_value )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_column_value_in_column_value_list1440);
            	c1 = column_value();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, c1.Tree);

            	retval.ret.SetColumnValue(((c1 != null) ? c1.ret : null));

            	// Query.g:521:1: ( ',' c2= column_value )*
            	do 
            	{
            	    int alt23 = 2;
            	    int LA23_0 = input.LA(1);

            	    if ( (LA23_0 == 11) )
            	    {
            	        alt23 = 1;
            	    }


            	    switch (alt23) 
            		{
            			case 1 :
            			    // Query.g:521:2: ',' c2= column_value
            			    {
            			    	char_literal134=(IToken)Match(input,11,FOLLOW_11_in_column_value_list1444); 
            			    		char_literal134_tree = (object)adaptor.Create(char_literal134);
            			    		adaptor.AddChild(root_0, char_literal134_tree);

            			    	PushFollow(FOLLOW_column_value_in_column_value_list1450);
            			    	c2 = column_value();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, c2.Tree);

            			    	retval.ret.SetColumnValue(((c2 != null) ? c2.ret : null));


            			    }
            			    break;

            			default:
            			    goto loop23;
            	    }
            	} while (true);

            	loop23:
            		;	// Stops C# compiler whining that label 'loop23' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "column_value_list"

    public class rename_table_return : ParserRuleReturnScope
    {
        public RenameTable ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "rename_table"
    // Query.g:526:1: rename_table returns [RenameTable ret] : ( 'rename ' | 'RENAME ' ) ( 'table ' | 'TABLE ' ) n1= table_name ' TO ' n2= table_name ';' ;
    public QueryParser.rename_table_return rename_table() // throws RecognitionException [1]
    {   
        QueryParser.rename_table_return retval = new QueryParser.rename_table_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set135 = null;
        IToken set136 = null;
        IToken string_literal137 = null;
        IToken char_literal138 = null;
        QueryParser.table_name_return n1 = null;

        QueryParser.table_name_return n2 = null;


        object set135_tree=null;
        object set136_tree=null;
        object string_literal137_tree=null;
        object char_literal138_tree=null;


        retval.ret = new RenameTable();
        retval.ret.SetStatementType(StatementType.RENAME_TABLE);

        try 
    	{
            // Query.g:531:2: ( ( 'rename ' | 'RENAME ' ) ( 'table ' | 'TABLE ' ) n1= table_name ' TO ' n2= table_name ';' )
            // Query.g:531:3: ( 'rename ' | 'RENAME ' ) ( 'table ' | 'TABLE ' ) n1= table_name ' TO ' n2= table_name ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set135 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 100 && input.LA(1) <= 101) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set135));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	set136 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 39 && input.LA(1) <= 40) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set136));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	PushFollow(FOLLOW_table_name_in_rename_table1485);
            	n1 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, n1.Tree);
            	string_literal137=(IToken)Match(input,102,FOLLOW_102_in_rename_table1487); 
            		string_literal137_tree = (object)adaptor.Create(string_literal137);
            		adaptor.AddChild(root_0, string_literal137_tree);

            	PushFollow(FOLLOW_table_name_in_rename_table1493);
            	n2 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, n2.Tree);
            	char_literal138=(IToken)Match(input,41,FOLLOW_41_in_rename_table1494); 
            		char_literal138_tree = (object)adaptor.Create(char_literal138);
            		adaptor.AddChild(root_0, char_literal138_tree);


            	retval.ret.SetOldTableName(((n1 != null) ? n1.ret : null).GetTableName());
            	retval.ret.SetNewTableName(((n2 != null) ? n2.ret : null).GetTableName());


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "rename_table"

    public class rename_column_return : ParserRuleReturnScope
    {
        public RenameColumn ret;
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "rename_column"
    // Query.g:537:1: rename_column returns [RenameColumn ret] : ( 'rename ' | 'RENAME ' ) ( 'column ' | 'COLUMN ' ) Name1= NAME ' TO ' Name2= NAME ' IN ' 'TABLE ' table_name ';' ;
    public QueryParser.rename_column_return rename_column() // throws RecognitionException [1]
    {   
        QueryParser.rename_column_return retval = new QueryParser.rename_column_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken Name1 = null;
        IToken Name2 = null;
        IToken set139 = null;
        IToken set140 = null;
        IToken string_literal141 = null;
        IToken string_literal142 = null;
        IToken string_literal143 = null;
        IToken char_literal145 = null;
        QueryParser.table_name_return table_name144 = null;


        object Name1_tree=null;
        object Name2_tree=null;
        object set139_tree=null;
        object set140_tree=null;
        object string_literal141_tree=null;
        object string_literal142_tree=null;
        object string_literal143_tree=null;
        object char_literal145_tree=null;


        retval.ret = new RenameColumn();
        retval.ret.SetStatementType(StatementType.RENAME_COLUMN);

        try 
    	{
            // Query.g:542:2: ( ( 'rename ' | 'RENAME ' ) ( 'column ' | 'COLUMN ' ) Name1= NAME ' TO ' Name2= NAME ' IN ' 'TABLE ' table_name ';' )
            // Query.g:542:3: ( 'rename ' | 'RENAME ' ) ( 'column ' | 'COLUMN ' ) Name1= NAME ' TO ' Name2= NAME ' IN ' 'TABLE ' table_name ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set139 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 100 && input.LA(1) <= 101) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set139));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	set140 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 35 && input.LA(1) <= 36) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set140));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}

            	Name1=(IToken)Match(input,NAME,FOLLOW_NAME_in_rename_column1527); 
            		Name1_tree = (object)adaptor.Create(Name1);
            		adaptor.AddChild(root_0, Name1_tree);

            	string_literal141=(IToken)Match(input,102,FOLLOW_102_in_rename_column1529); 
            		string_literal141_tree = (object)adaptor.Create(string_literal141);
            		adaptor.AddChild(root_0, string_literal141_tree);

            	Name2=(IToken)Match(input,NAME,FOLLOW_NAME_in_rename_column1535); 
            		Name2_tree = (object)adaptor.Create(Name2);
            		adaptor.AddChild(root_0, Name2_tree);

            	string_literal142=(IToken)Match(input,38,FOLLOW_38_in_rename_column1537); 
            		string_literal142_tree = (object)adaptor.Create(string_literal142);
            		adaptor.AddChild(root_0, string_literal142_tree);

            	string_literal143=(IToken)Match(input,40,FOLLOW_40_in_rename_column1539); 
            		string_literal143_tree = (object)adaptor.Create(string_literal143);
            		adaptor.AddChild(root_0, string_literal143_tree);

            	PushFollow(FOLLOW_table_name_in_rename_column1540);
            	table_name144 = table_name();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, table_name144.Tree);
            	char_literal145=(IToken)Match(input,41,FOLLOW_41_in_rename_column1541); 
            		char_literal145_tree = (object)adaptor.Create(char_literal145);
            		adaptor.AddChild(root_0, char_literal145_tree);


            	if(((Name1 != null) ? Name1.Text : null) == "<missing NAME>" || ((Name2 != null) ? Name2.Text : null) == "<missing NAME>")
            	{		
            	QueryParserException qpe = new QueryParserException("Error in parsing query: Missing Column Name.");
            	throw qpe;
            	}
            	else
            	{
            	retval.ret.SetOldColumnName(((Name1 != null) ? Name1.Text : null));
            	retval.ret.SetNewColumnName(((Name2 != null) ? Name2.Text : null));
            	retval.ret.SetTableName(((table_name144 != null) ? table_name144.ret : null).GetTableName());
            	}


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }

        	catch(RecognitionException e)
        	{
        		throw e;
        	}
        	catch(QueryParserException e)
        	{
        		throw e;
        	}
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "rename_column"

    // Delegated rules


   	protected DFA1 dfa1;
	private void InitializeCyclicDFAs()
	{
    	this.dfa1 = new DFA1(this);
	}

    const string DFA1_eotS =
        "\x0f\uffff";
    const string DFA1_eofS =
        "\x0f\uffff";
    const string DFA1_minS =
        "\x01\x07\x09\uffff\x01\x23\x04\uffff";
    const string DFA1_maxS =
        "\x01\x65\x09\uffff\x01\x28\x04\uffff";
    const string DFA1_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\uffff\x01\x0b\x01\x0c\x01\x0a\x01\x0d";
    const string DFA1_specialS =
        "\x0f\uffff}>";
    static readonly string[] DFA1_transitionS = {
            "\x02\x07\x18\uffff\x02\x06\x07\uffff\x02\x06\x01\uffff\x02"+
            "\x01\x02\x02\x02\x03\x02\x04\x02\x05\x02\x08\x1d\uffff\x02\x0b"+
            "\x04\uffff\x02\x0c\x02\uffff\x02\x09\x02\uffff\x02\x0a",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x02\x0e\x02\uffff\x02\x0d",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA1_eot = DFA.UnpackEncodedString(DFA1_eotS);
    static readonly short[] DFA1_eof = DFA.UnpackEncodedString(DFA1_eofS);
    static readonly char[] DFA1_min = DFA.UnpackEncodedStringToUnsignedChars(DFA1_minS);
    static readonly char[] DFA1_max = DFA.UnpackEncodedStringToUnsignedChars(DFA1_maxS);
    static readonly short[] DFA1_accept = DFA.UnpackEncodedString(DFA1_acceptS);
    static readonly short[] DFA1_special = DFA.UnpackEncodedString(DFA1_specialS);
    static readonly short[][] DFA1_transition = DFA.UnpackEncodedStringArray(DFA1_transitionS);

    protected class DFA1 : DFA
    {
        public DFA1(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 1;
            this.eot = DFA1_eot;
            this.eof = DFA1_eof;
            this.min = DFA1_min;
            this.max = DFA1_max;
            this.accept = DFA1_accept;
            this.special = DFA1_special;
            this.transition = DFA1_transition;

        }

        override public string Description
        {
            get { return "62:1: statement returns [Statement ret] : ( create_db | select_db | delete_db | delete_table | empty_table | mod_table | create_table | select_rows | insert_row | rename_table | update_row | delete_row | rename_column );"; }
        }

    }

 

    public static readonly BitSet FOLLOW_create_db_in_statement78 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_select_db_in_statement85 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_delete_db_in_statement91 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_delete_table_in_statement97 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_empty_table_in_statement103 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_mod_table_in_statement109 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_create_table_in_statement115 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_select_rows_in_statement121 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_insert_row_in_statement127 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_rename_table_in_statement133 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_update_row_in_statement139 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_delete_row_in_statement145 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_rename_column_in_statement151 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_create_table169 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_create_table174 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_9_in_create_table175 = new BitSet(new ulong[]{0x000000000000F010UL});
    public static readonly BitSet FOLLOW_tlist_in_create_table177 = new BitSet(new ulong[]{0x0000000000000400UL});
    public static readonly BitSet FOLLOW_10_in_create_table179 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_tcolumn_in_tlist202 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_11_in_tlist207 = new BitSet(new ulong[]{0x000000000000F010UL});
    public static readonly BitSet FOLLOW_tcolumn_in_tlist213 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_set_in_tcolumn234 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_set_in_tcolumn244 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_tcolumn253 = new BitSet(new ulong[]{0x000000017FFF0000UL});
    public static readonly BitSet FOLLOW_type_in_tcolumn255 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_type271 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_type279 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_type287 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_type295 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_type303 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_type311 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_type319 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_30_in_type329 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_type332 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_type334 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_type337 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_type340 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_type344 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_delete_column_in_mod_table363 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_add_column_in_mod_table370 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_delete_column389 = new BitSet(new ulong[]{0x0000001800000000UL});
    public static readonly BitSet FOLLOW_set_in_delete_column394 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_delete_column399 = new BitSet(new ulong[]{0x0000006000000000UL});
    public static readonly BitSet FOLLOW_set_in_delete_column400 = new BitSet(new ulong[]{0x0000018000000000UL});
    public static readonly BitSet FOLLOW_set_in_delete_column405 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_delete_column411 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_delete_column412 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_add_column430 = new BitSet(new ulong[]{0x0000001800000000UL});
    public static readonly BitSet FOLLOW_set_in_add_column435 = new BitSet(new ulong[]{0x000000000000F010UL});
    public static readonly BitSet FOLLOW_tcolumn_in_add_column440 = new BitSet(new ulong[]{0x0000006000000000UL});
    public static readonly BitSet FOLLOW_set_in_add_column442 = new BitSet(new ulong[]{0x0000018000000000UL});
    public static readonly BitSet FOLLOW_set_in_add_column447 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_add_column453 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_add_column454 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_table_name476 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_table_name477 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_table_name480 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_table_name490 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_create_db509 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_create_db514 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_create_db515 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_select_db534 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_select_db539 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_select_db540 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_delete_db558 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_delete_db563 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_delete_db564 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_delete_table582 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_delete_table587 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_delete_table588 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_empty_table606 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_empty_table613 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_empty_table614 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_select_rows631 = new BitSet(new ulong[]{0x0800000000000010UL,0x0000000000300000UL});
    public static readonly BitSet FOLLOW_select_row_table_column_list_in_select_rows638 = new BitSet(new ulong[]{0x0600000000000000UL});
    public static readonly BitSet FOLLOW_set_in_select_rows643 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_select_rows651 = new BitSet(new ulong[]{0x6000020000000000UL,0x0000000000061800UL});
    public static readonly BitSet FOLLOW_where_list_in_select_rows656 = new BitSet(new ulong[]{0x0000020000000000UL,0x0000000000061800UL});
    public static readonly BitSet FOLLOW_order_by_list_in_select_rows662 = new BitSet(new ulong[]{0x0000020000000000UL,0x0000000000060000UL});
    public static readonly BitSet FOLLOW_limit_range_in_select_rows668 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_select_rows674 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_59_in_select_row_table_column_list691 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_col_list_in_select_row_table_column_list699 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_count_rows_in_select_row_table_column_list707 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_col_list731 = new BitSet(new ulong[]{0x1000000000000002UL});
    public static readonly BitSet FOLLOW_60_in_col_list736 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_col_list742 = new BitSet(new ulong[]{0x1000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_where_list764 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sub_where_list_in_where_list772 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_where_entry_in_sub_where_list795 = new BitSet(new ulong[]{0x8000000000000002UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_set_in_sub_where_list802 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_where_entry_in_sub_where_list814 = new BitSet(new ulong[]{0x8000000000000002UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_NAME_in_where_entry835 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000007FEUL});
    public static readonly BitSet FOLLOW_65_in_where_entry842 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_66_in_where_entry848 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_67_in_where_entry854 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_68_in_where_entry860 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_69_in_where_entry866 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_70_in_where_entry872 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_71_in_where_entry878 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_72_in_where_entry884 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_73_in_where_entry890 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_74_in_where_entry896 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_column_value_in_where_entry902 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NUMBER_in_column_value922 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_column_value929 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NUMBER_in_column_value940 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_column_value942 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_column_value948 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_order_by_list968 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sub_order_by_list_in_order_by_list976 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_order_by_entry_in_sub_order_by_list999 = new BitSet(new ulong[]{0x1000000000000002UL});
    public static readonly BitSet FOLLOW_60_in_sub_order_by_list1007 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_order_by_entry_in_sub_order_by_list1014 = new BitSet(new ulong[]{0x1000000000000002UL});
    public static readonly BitSet FOLLOW_NAME_in_order_by_entry1034 = new BitSet(new ulong[]{0x0000000000000000UL,0x000000000001E000UL});
    public static readonly BitSet FOLLOW_set_in_order_by_entry1039 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_order_by_entry1048 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_limit_range1082 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_limit_range1094 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_83_in_limit_range1097 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_limit_range1103 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_count_rows1122 = new BitSet(new ulong[]{0x0800000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_count_rows1132 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_59_in_count_rows1145 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_count_rows1150 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_update_row1169 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_update_row1179 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000003000000UL});
    public static readonly BitSet FOLLOW_set_in_update_row1186 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_set_list_in_update_row1196 = new BitSet(new ulong[]{0x6000020000000000UL});
    public static readonly BitSet FOLLOW_where_list_in_update_row1203 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_update_row1207 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_entry_in_set_list1229 = new BitSet(new ulong[]{0x0000000000000002UL,0x000000000C000000UL});
    public static readonly BitSet FOLLOW_set_in_set_list1234 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_set_entry_in_set_list1248 = new BitSet(new ulong[]{0x0000000000000002UL,0x000000000C000000UL});
    public static readonly BitSet FOLLOW_NAME_in_set_entry1270 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000042UL});
    public static readonly BitSet FOLLOW_set_in_set_entry1274 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_column_value_in_set_entry1280 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_delete_row1300 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000C0000000UL});
    public static readonly BitSet FOLLOW_set_in_delete_row1309 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_delete_row1319 = new BitSet(new ulong[]{0x6000000000000002UL});
    public static readonly BitSet FOLLOW_where_list_in_delete_row1323 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_insert_row1342 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_insert_row1347 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_9_in_insert_row1350 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_column_list_in_insert_row1352 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_insert_row1355 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_set_in_insert_row1357 = new BitSet(new ulong[]{0x0000000000000200UL});
    public static readonly BitSet FOLLOW_9_in_insert_row1363 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_column_value_list_in_insert_row1365 = new BitSet(new ulong[]{0x0000000000000400UL});
    public static readonly BitSet FOLLOW_10_in_insert_row1368 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_column_name_in_table_column_list1389 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_11_in_table_column_list1393 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_column_name_in_table_column_list1399 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_NAME_in_column_name1419 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_column_value_in_column_value_list1440 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_11_in_column_value_list1444 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_column_value_in_column_value_list1450 = new BitSet(new ulong[]{0x0000000000000802UL});
    public static readonly BitSet FOLLOW_set_in_rename_table1469 = new BitSet(new ulong[]{0x0000018000000000UL});
    public static readonly BitSet FOLLOW_set_in_rename_table1476 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_rename_table1485 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000004000000000UL});
    public static readonly BitSet FOLLOW_102_in_rename_table1487 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_rename_table1493 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_rename_table1494 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_rename_column1511 = new BitSet(new ulong[]{0x0000001800000000UL});
    public static readonly BitSet FOLLOW_set_in_rename_column1518 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_rename_column1527 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000004000000000UL});
    public static readonly BitSet FOLLOW_102_in_rename_column1529 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_NAME_in_rename_column1535 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_38_in_rename_column1537 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_40_in_rename_column1539 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_table_name_in_rename_column1540 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_rename_column1541 = new BitSet(new ulong[]{0x0000000000000002UL});

}
