using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlLib.Audio.SndConv
{
    public unsafe partial class SndConv
    {
        public struct SoundInfo
        {
            uint channels;
            uint bitsPerSample;
            uint sampleRate;
            uint samples;
            uint loopStart;
            uint loopEnd;
            uint bufferLength;
        }

        public struct ADPCMInfo
        {
            // start context
            public fixed ushort coef[16];
            ushort gain;
            ushort pred_scale;
            ushort yn1;
            ushort yn2;

            // loop context
            ushort loop_pred_scale;
            ushort loop_yn1;
            ushort loop_yn2;
        }

        public const int STATUS_SUCCESS = 0;
        public const int STATUS_EOF = 1;
        public const int STATUS_ERROR = 2;

        public const int STATE_BEGIN = 0;
        public const int STATE_END = 1;

        public const int SOUND_FORMAT_ADPCM =  0;
        public const int SOUND_FORMAT_PCM8 =  1;
        public const int SOUND_FORMAT_PCM16 =  2;
            
        public const int SOUND_STEREO_COMBINE = 0;
        public const int SOUND_STEREO_LEFT =  1;
        public const int SOUND_STEREO_RIGHT = 2;


        public const uint SOUND_DATA_NO_USER_INPUT = 0xFFFFFFFF;

        public struct SndConvData
        {
            uint type;
            uint sampleRate;
            uint loopAddr;
            uint loopEndAddr;
            uint endAddr;
            uint currentAddr;
            uint adpcm;
        }

        public const int SP_TYPE_ADPCM_ONESHOT = 0;
        public const int SP_TYPE_ADPCM_LOOPED = 1;
        public const int SP_TYPE_PCM16_ONESHOT = 2;
        public const int SP_TYPE_PCM16_LOOPED = 3;
        public const int SP_TYPE_PCM8_ONESHOT = 4;
        public const int SP_TYPE_PCM8_LOOPED = 5;

        //static int  state;
        //static int  line;
        //static char seps[]   = " ,\t\n";

        //static char *inputPath;
        //static char path[1024];
        //static char error[1024];

        //HINSTANCE   hDllSoundfile;
        //HINSTANCE   hDllDsptool;


        ///*--------------------------------------------------------------------------*
        //    absolutePath()

        //    - changes '/' to '\\' to handle paths from bash    
        // *--------------------------------------------------------------------------*/
        //int absolutePath(char *token)
        //{
        //    if ((strchr(token, ':')) || (*token == '\\'))
        //        return 1;

        //    return 0;
        //}


        ///*--------------------------------------------------------------------------*
        //    fixString()

        //    - changes '/' to '\\' to handle paths from bash    
        // *--------------------------------------------------------------------------*/
        //void fixString(char *ch)
        //{
        //    while(*ch)
        //    {
        //        if (*ch == '/')
        //            *ch = '\\';

        //        ch++;
        //    }
        //}


        ///*--------------------------------------------------------------------------*
        //    parsePathStatement()

        //    - parse for path to set
        //    - copy the string for later use
        // *--------------------------------------------------------------------------*/
        //void parsePathStatement(void)
        //{
        //    char *token;

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] != ';')
        //        {
        //            // save the path for file accessing
        //            strcpy(path, token);
        //            fixString(path);
        ////            printf("Setting path to %s\n", token);
        //            return;
        //        }
        //    }
    
        //    printf("%cError! Incomplete PATH statement on line %d.\n", 7, line);
        //}


        ///*--------------------------------------------------------------------------*
        //    parseBeginStatement()

        //    - check for end state
        //    - parse for sound id
        //    - set sound id in sound.c
        //    - set state flag to begin
        // *--------------------------------------------------------------------------*/
        //void parseBeginStatement(void)
        //{
        //    char *token;

        //    if (state == STATE_BEGIN)
        //        printf("%cWarning! BEGIN statement made prior to END on line %d.\n", 7, line);

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] != ';')
        //        {
        //            soundInitParams();
        //            soundSetIdString(token);
        ////            printf("Begin sound id %s\n", token);
        //            state = STATE_BEGIN;
        
        //            return;
        //        }
        //    }

        //    printf("%cError! Incomplete BEGIN statement on line %d.\n", 7, line);
        //}


        ///*--------------------------------------------------------------------------*
        //    parseFileStatement()

        //    - parse for sound file path
        //    - set sound file path in sound.c
        // *--------------------------------------------------------------------------*/
        //void parseFileStatement(void)
        //{
        //    char *token;

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] != ';')
        //        {
        //            fixString(token);

        //            if (absolutePath(token))
        //            {
        //                soundSetSoundFile(token);
        //            }
        //            else if (path[0] != 0)
        //            {
        //                char ch[1024];

        //                strcpy(ch, path);
        //                strcat(ch, "\\");
        //                strcat(ch, token);
        //                soundSetSoundFile(ch);
        //            }
        //            else
        //            {
        //                soundSetSoundFile(token);
        //            }

        ////            printf("\tSound file %s\n", token);
        //            return;
        //        }
        //    }

        //    printf("%cError! Incomplete FILE statement on line %d.\n", 7, line);
        //}

        ///*--------------------------------------------------------------------------*
        //    parseOutputStatment()

        //    - parse output mode
        //    - set flag in sound.c
        // *--------------------------------------------------------------------------*/
        //void parseOutputStatement(void)
        //{
        //    char *token;

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] != ';')
        //        {
        //            strupr(token);

        //            if (strcmp(token, "ADPCM") == 0)
        //                soundSetFormat(SOUND_FORMAT_ADPCM);
        //            else if (strcmp(token, "8BIT") == 0)
        //                soundSetFormat(SOUND_FORMAT_PCM8);
        //            else if (strcmp(token, "16BIT") == 0)
        //                soundSetFormat(SOUND_FORMAT_PCM16);
        //            else
        //                printf("%cWarning! Invalid token \"%s\" on line %d.\n", 7, token, line);
            
        ////            printf("\tOutput %s\n", token);
        //            return;
        //        }
        //    }

        //    printf("%cError! Incomplete OUTPUT statement on line %d.\n", 7, line);
        //}


        ///*--------------------------------------------------------------------------*
        //    parseSampleRateStatement()

        //    - parse sample rate
        //    - set sample rate in sound.c
        // *--------------------------------------------------------------------------*/
        //void parseSamplerateStatement(void)
        //{
        //    char *token;

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] != ';')
        //        {
        //            int i = atoi(token);
            
        ////            printf("\tSample rate %d\n", i);
            
        //            soundSetSampleRate(i);

        //            return;
        //        }
        //    }

        //    printf("%cError! Incomplete SAMPLERATE statement on line %d.\n", 7, line);
        //}


        ///*--------------------------------------------------------------------------*
        //    parseLoopStatement()

        //    - parse loop start and end
        //    - set loop points in sound.c
        // *--------------------------------------------------------------------------*/
        //void parseLoopStatement(void)
        //{
        //    char *token;
        //    int loopStart, loopEnd;

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] != ';')
        //        {
        //            loopStart = atoi(token);

        //            if (token = strtok(NULL, seps))
        //            {
        //                if (token[0] != ';')
        //                {
        //                    loopEnd = atoi(token);

        ////                    printf("\tLoop %d %d\n", loopStart, loopEnd);

        //                    soundSetLoopStart(loopStart);
        //                    soundSetLoopEnd(loopEnd);

        //                    return;
        //                }
        //            }
        //        }
        //    }

        //    printf("%cError! Incomplete LOOP statement on line %d.\n", 7, line);
        //}


        ///*--------------------------------------------------------------------------*
        //    parseMixStatement()

        //    - parse mix
        //    - set the output mix flag in sound.c
        // *--------------------------------------------------------------------------*/
        //void parseMixStatement(void)
        //{
        //    char *token;

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] != ';')
        //        {
        //            strupr(token);

        //            if (strcmp(token, "COMBINE") == 0)
        //                soundSetMix(SOUND_STEREO_COMBINE);
        //            else if (strcmp(token, "LEFT") == 0)
        //                soundSetMix(SOUND_STEREO_LEFT);
        //            else if (strcmp(token, "RIGHT") == 0)
        //                soundSetMix(SOUND_STEREO_RIGHT);
        //            else
        //                printf("%cWarning! Invalid token \"%s\" on line %d.\n", 7, token, line);

        ////            printf("\tMix %s\n", token);
        //            return;
        //        }
        //    }

        //    printf("%cError! Incomplete MIX statement on line %d.\n", 7, line);
        //}


        ///*--------------------------------------------------------------------------*
        //    parseCommentStatement()

        //    - parse comment
        //    - write comment to output header file
        // *--------------------------------------------------------------------------*/
        //void parseCommentStatement(void)
        //{
        //    char *token;
        //    char ch[1024];

        //    sprintf(ch, "//  ");

        //    if (token = strtok(NULL, ""))
        //            strcat(ch, token);

        //    if (ch[strlen(ch) - 1] != '\n')
        //            strcat(ch, "\n");

        //    soundOutputComment(ch);
        ////    printf("%s", ch);
        //}


        ///*--------------------------------------------------------------------------*
        //    parseEndStatement()

        //    - print sound to data file
        //    - add entry for sound
        //    - set state flag to end
        // *--------------------------------------------------------------------------*/
        //void parseEndStatement(void)
        //{
        //    char *token;

        //    if (state == STATE_END)
        //        printf("%cWarning! END statement made prior to BEGIN on line %d.\n", 7, line);

        //    if (soundPrintSound() != STATUS_SUCCESS)
        //        printf("%cError! Sound not converted on line %d.\n", 7, line);

        ////    printf("End sound\n");
        //    printf(".");

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] == ';')
        //            return;

        //        printf("%cWarning! Unexpected token \"%s\" after END statement on line %d.\n", 7, token, line);
        //    }

        //    state = STATE_END;
        //}


        ///*--------------------------------------------------------------------------*
        //    parseIncludeStatement()

        //    - get file path to include
        //    - eat the file
        // *--------------------------------------------------------------------------*/
        //int eatFile(char *ch);
        //void parseIncludeStatement(void)
        //{
        //    char *token;

        //    if (token = strtok(NULL, seps))
        //    {
        //        if (token[0] != ';')
        //        {
        //            int tempLine = line;
        //            line = 1;

        //            fixString(token);

        //            if (absolutePath(token))
        //            {
        //                eatFile(token);
        //            }
        //            else if (path[0] != 0)
        //            {
        //                char ch[1024];

        //                strcpy(ch, path);
        //                strcat(ch, "\\");
        //                strcat(ch, token);
        //                eatFile(ch);
        //            }
        //            else
        //            {
        //                eatFile(token);
        //            }

        //            line = tempLine;
           
        ////            printf("\tInclude file %s\n", token);

        //            return;
        //        }
        //    }

        //    printf("%cError! Incomplete INCLUDE statement on line %d.\n", 7, line);
        //}


        ///*--------------------------------------------------------------------------*
        //    parseLine()

        //    - parse line for command
        // *--------------------------------------------------------------------------*/
        //void parseLine(char *ch)
        //{
        //    char *token = strtok(ch, seps);
    
        //    while(token != NULL)
        //    {
        //        if (token[0] == ';')
        //            break;

        //        // convert string to all upper case
        //        _strupr(token);

        //        // see what the command is
        //        if (strcmp(token, "PATH") == 0)
        //        {
        //            parsePathStatement();
        //        }
        //        else if (strcmp(token, "BEGIN") == 0)
        //        {
        //            parseBeginStatement();
        //        }
        //        else if (strcmp(token, "FILE") == 0)
        //        {
        //            parseFileStatement();
        //        }
        //        else if (strcmp(token, "OUTPUT") == 0)
        //        {
        //            parseOutputStatement();
        //        }
        //        else if (strcmp(token, "SAMPLERATE") == 0)
        //        {
        //            parseSamplerateStatement();
        //        }
        //        else if (strcmp(token, "LOOP") == 0)
        //        {
        //            parseLoopStatement();
        //        }
        //        else if (strcmp(token, "MIX") == 0)
        //        {
        //            parseMixStatement();
        //        }
        //        else if (strcmp(token, "END") == 0)
        //        {
        //            parseEndStatement();
        //        }
        //        else if (strcmp(token, "COMMENT") == 0)
        //        {
        //            parseCommentStatement();
        //        }
        //        else if (strcmp(token, "INCLUDE") == 0)
        //        {
        //            parseIncludeStatement();

        //            // since this cause other strtok() to be called
        //            // for other instances of file reads... we better reset
        //            // the strtok by doing a read from the start of this string
        //            strtok(ch, seps);
        //            strtok(NULL, seps);
        //        }
        //        else
        //        {
        //            printf("%c\nWarning unknown token \"%s\" on line number %d!!!\n",
        //                    7, token, line);
        //        }

        //        token = strtok(NULL, seps);
        //   }           
        //}


        ///*--------------------------------------------------------------------------*
        //    nextLine()

        //    - get next line from file
        //    - parse line
        // *--------------------------------------------------------------------------*/
        //int nextLine(FILE *file)
        //{
        //    int     status;
        //    char    ch[256];

        //    if (fgets(ch, 256, file))
        //    {
        //        parseLine(ch);
        //        status = STATUS_SUCCESS;
        //    }
        //    else
        //    {
        //        if (feof(file) == 0)
        //            status = STATUS_ERROR;
        //        else
        //            status = STATUS_EOF;
        //    }

        //    return status;
        //}


        ///*--------------------------------------------------------------------------*
        //    satFile()

        //    - read file by line
        //    - send lines to parser
        // *--------------------------------------------------------------------------*/
        //int eatFile(char *s)
        //{
        //    FILE *file;
        //    int status = STATUS_ERROR;
    
        //    if (file = fopen(s, "r"))
        //    {
        //        do
        //        {
        //            status = nextLine(file);
        //            line++;
        //        }
        //        while (status == STATUS_SUCCESS);

        //        switch (status)
        //        {
        //        case STATUS_EOF:

        ////            printf("\n\nEnd of script file %s reached.\n", s);

        //            break;

        //        case STATUS_ERROR:

        //            printf("%c\n\nError encountered while reading file, line %d!\n", 7, line);

        //            break;
        //        }

        //        fclose(file);
        //    }
        //    else
        //    {
        //        printf("%c\nError, cannot open %s for reading!!!\n", 7, s);
        //    }

        //    return status;
        //}


        ///*--------------------------------------------------------------------------*
        //    printBanner()
        // *--------------------------------------------------------------------------*/
        //void printBanner(void)
        //{
        //    printf("\n");
        //    printf("sndconv.exe v1.2\n");
        //    printf("Sound converter for Dolphin AX sound player.\n");
        //    printf("Copyright 2001 Nintendo Technology Development, Inc.\n");
        //    printf("\n");
        //}


        ///*--------------------------------------------------------------------------*
        //    printUsage()
        // *--------------------------------------------------------------------------*/
        //void printUsage(void)
        //{
        //    printf("Usage:\n\n");
        //    printf("SNDCONV <inputfile> [-option]\n");
        //    printf("Where:\n");
        //    printf("   <scriptfile>.......Script file (required)\n\n");

        //    printf("Options are:\n");
        //    printf("   -a.................Default output to ADPCM\n");
        //    printf("   -w.................Default output to 16bit PCM\n");
        //    printf("   -b.................Default output to 8bit PCM\n");
        //    printf("   -h.................This help text.\n");
        ////    printf("   -v.................Verbose mode.\n");
        //    printf("\n\n");
        //    printf("This tool generates data files for AX SP library.\n");

        //    printf("\n");
        //}


        ///*--------------------------------------------------------------------------*
        //    cleanup()

        //    - quit output code module
        //    - free libraries
        // *--------------------------------------------------------------------------*/
        //void cleanup(void)
        //{
        //    soundOutputQuit();

        //    if (hDllSoundfile)  FreeLibrary(hDllSoundfile);
        //    if (hDllDsptool)    FreeLibrary(hDllDsptool);
        //}


        ///*--------------------------------------------------------------------------*
        //    loadDlls()

        //    - load soundfile.dll and dsptool.dll
        //    - get export function pointers
        // *--------------------------------------------------------------------------*/
        //// soundfile.dll exports
        //typedef int (*FUNCTION1)(u8 *path, SOUNDINFO *soundinfo);
        //typedef int (*FUNCTION2)(u8 *path, SOUNDINFO *soundinfo, void *dest);
        //FUNCTION1   getSoundInfo;
        //FUNCTION2   getSoundSamples;

        //// dsptool.dll exports
        //typedef void (*FUNCTION3)(u16*, u8*, ADPCMINFO*, int);
        //typedef int (*FUNCTION4)(int);
        //typedef void (*FUNCTION5)(u8 *src, ADPCMINFO *cxt, u32 samples);
        //FUNCTION3   encode;
        //FUNCTION4   getBytesForAdpcmBuffer;
        //FUNCTION4   getBytesForAdpcmSamples;
        //FUNCTION4   getNibbleAddress;
        //FUNCTION5   getLoopContext;


        //int loadDlls(void)
        //{
        //    getSoundInfo            = NULL;
        //    getSoundSamples         = NULL;
        //    encode                  = NULL;
        //    getBytesForAdpcmBuffer  = NULL;

        //    if (hDllSoundfile = LoadLibrary("soundfile.dll"))
        //    {
        //        getSoundInfo            = (FUNCTION1)GetProcAddress(hDllSoundfile, "getSoundInfo");
        //        getSoundSamples         = (FUNCTION2)GetProcAddress(hDllSoundfile, "getSoundSamples");
        //    }

        //    if (hDllDsptool = LoadLibrary("dsptool.dll"))
        //    {
        //        encode                  = (FUNCTION3)GetProcAddress(hDllDsptool, "encode");
        //        getBytesForAdpcmBuffer  = (FUNCTION4)GetProcAddress(hDllDsptool, "getBytesForAdpcmBuffer");
        //        getBytesForAdpcmSamples = (FUNCTION4)GetProcAddress(hDllDsptool, "getBytesForAdpcmSamples");
        //        getNibbleAddress        = (FUNCTION4)GetProcAddress(hDllDsptool, "getNibbleAddress");
        //        getLoopContext          = (FUNCTION5)GetProcAddress(hDllDsptool, "getLoopContext");
        //    }
    
        //    if (getSoundInfo && getSoundSamples && encode && getBytesForAdpcmBuffer && getNibbleAddress)
        //        return STATUS_SUCCESS;
    
        //    printf("\n%cError loading DLL\n", 7);

        //    return STATUS_ERROR;
        //}


        ///*--------------------------------------------------------------------------*
        //    init()

        //    - initialize output code module
        // *--------------------------------------------------------------------------*/
        //int init(char *s)
        //{
        //    char ch[1024];
        //    char *dot;    

        //    // make a copy of the path
        //    strcpy(ch, s);

        //    // check string for forward slash
        //    fixString(ch);

        //    // terminate the path at the last dot
        //    if (dot = strrchr(ch, '.'))
        //        *dot = 0;

        //    // initialize the output module with the new path
        //    if (soundOutputInit(ch) == STATUS_ERROR)
        //    {
        //        return STATUS_ERROR;
        //    }
        //    else
        //    {
        //        // some local variables
        //        line    = 1;
        //        state   = STATE_END;
        //        path[0] = 0;
            
        //        return loadDlls();
        //    }
        //}


        ///*--------------------------------------------------------------------------*
        //    parseArgs()

        //    - check number of arguments
        //    - parse command line
        //    - set default output format and input file path
        // *--------------------------------------------------------------------------*/
        //int parseArgs(int argc, char *argv[])
        //{
        //    int i;

        //    if (argc < 2)
        //    {
        //        printf("\nERROR: Missing parameter\n\n");

        //        return FALSE;
        //    }

        //    for (i = 1; i < argc; i++)
        //    {
        //        switch (argv[i][0])
        //        {
        //        case '?':

        //            return FALSE;

        //            break;

        //        case '-':
        //        case '/':
        //        case '\\':

        //            switch (argv[i][1])
        //            {
        //            case 'a':
        //            case 'A':

        //                soundSetDefaultFormat(SOUND_FORMAT_ADPCM);            

        //                break;

        //            case 'w':
        //            case 'W':

        //                soundSetDefaultFormat(SOUND_FORMAT_PCM16);            

        //                break;

        //            case 'b':
        //            case 'B':

        //                soundSetDefaultFormat(SOUND_FORMAT_PCM8);            

        //                break;

        //            case 'h':
        //            case 'H':

        //                return FALSE;

        //                break;

        //            default:

        //                printf("\n%cERROR: Unknown switch '%c'\n\n", 7, argv[i][1]);
        //                return FALSE;

        //                break;
        //            }

        //            break;

        //        default:

        //            inputPath = argv[i];

        //            break;
        //        }
        //    }

        //    if (inputPath == NULL)
        //    {
        //        printf("\nERROR: No input file specified!\n\n");
        //        return FALSE;
        //    }

        //    return TRUE;
        //}

        ///*--------------------------------------------------------------------------*
        //    main()

        //    - print program banner
        //    - check arguments
        //    - eat script file
        // *--------------------------------------------------------------------------*/
        //int main(int argc, char *argv[])
        //{
        //    int status;

        //    printBanner();

        //    if (parseArgs(argc, argv))
        //    {
        //        soundSetDefaultFormat(SOUND_FORMAT_ADPCM);            
    
        //        if (init(inputPath) == STATUS_SUCCESS)
        //        {
        //            path[0] = 0;
        //            status = eatFile(inputPath);
        //            printf("\n");
        //        }
        //        else
        //        {
        //            status = STATUS_ERROR;
        //        }
        //    }
        //    else
        //    {
        //        printUsage();
        //        status = STATUS_ERROR;
        //    }

        //    cleanup();

        //    if (status == STATUS_ERROR)
        //        return 1;

        //    exit(0);
        //}
    }
}
