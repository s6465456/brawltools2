using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlLib.Audio.SndConv
{
    public partial class SndConv
    {
        uint         soundEntries;
        uint         soundAdpcmEntries;
        uint         soundByteOffset;

        SndConvData[] soundConvdata = new SndConvData[0xFFFF];
        ADPCMInfo[]  soundAdpcminfo = new ADPCMInfo[0xFFFF];

        ///*--------------------------------------------------------------------------*
        //    add an entry
        // *--------------------------------------------------------------------------*/
        //public unsafe void soundOutputAddEntry(
        //        uint format,
        //        uint dataBytes,
        //        void* buffer,
        //        uint samples,
        //        uint sampleRate,
        //        uint loopStart,
        //        uint loopEnd,
        //        ADPCMInfo* adpcminfo,
        //        char        *headerId
        //        )
        //{
        //    SndConvData *sndconvdata = &soundConvdata[soundEntries];

        //    switch (format)
        //    {
        //    case SOUND_FORMAT_ADPCM:

        //         8 byte-aligned ADPCM buffers
        //        while (soundByteOffset % 8)
        //        {
        //            char ch = 0;
        //            fwrite(&ch, 1, 1, outputSamples);
        //            soundByteOffset++;
        //        }

        //         looped sound
        //        if (loopEnd)
        //        {
        //            sndconvdata->type           = SP_TYPE_ADPCM_LOOPED;
        //            sndconvdata->sampleRate     = sampleRate;
        //            sndconvdata->loopAddr       = (soundByteOffset << 1) + getNibbleAddress(loopStart);
        //            sndconvdata->loopEndAddr    = (soundByteOffset << 1) + getNibbleAddress(loopEnd);
        //            sndconvdata->endAddr        = (soundByteOffset << 1) + getNibbleAddress(samples - 1);
        //            sndconvdata->currentAddr    = (soundByteOffset << 1) + getNibbleAddress(0);
        //            sndconvdata->adpcm          = 0;
        //        }
        //        else
        //        {
        //            sndconvdata->type           = SP_TYPE_ADPCM_ONESHOT;
        //            sndconvdata->sampleRate     = sampleRate;
        //            sndconvdata->loopAddr       = 0;
        //            sndconvdata->loopEndAddr    = 0;
        //            sndconvdata->endAddr        = (soundByteOffset << 1) + getNibbleAddress(samples - 1);
        //            sndconvdata->currentAddr    = (soundByteOffset << 1) + getNibbleAddress(0);
        //            sndconvdata->adpcm          = 0;
        //        }

        //         write the buffer to data file
        //        fwrite(buffer, 1, dataBytes, outputSamples);
        //        soundByteOffset += dataBytes;

        //         store the ADPCMINFO
        //        memcpy(
        //            &soundAdpcminfo[soundAdpcmEntries],
        //            adpcminfo,
        //            sizeof(ADPCMINFO)
        //            );

        //        soundAdpcmEntries++;

        //        break;

        //    case SOUND_FORMAT_PCM8:

        //         looped sound
        //        if (loopEnd)
        //        {
        //            sndconvdata->type           = SP_TYPE_PCM8_LOOPED;
        //            sndconvdata->sampleRate     = sampleRate;
        //            sndconvdata->loopAddr       = soundByteOffset + loopStart;
        //            sndconvdata->loopEndAddr    = soundByteOffset + loopEnd;
        //            sndconvdata->endAddr        = soundByteOffset + samples - 1;
        //            sndconvdata->currentAddr    = soundByteOffset;
        //            sndconvdata->adpcm          = 0;
        //        }
        //        else
        //        {
        //            sndconvdata->type           = SP_TYPE_PCM8_ONESHOT;
        //            sndconvdata->sampleRate     = sampleRate;
        //            sndconvdata->loopAddr       = 0;
        //            sndconvdata->loopEndAddr    = 0;
        //            sndconvdata->endAddr        = soundByteOffset + samples - 1;
        //            sndconvdata->currentAddr    = soundByteOffset;
        //            sndconvdata->adpcm          = 0;
        //        }

        //         write the buffer to data file
        //        fwrite(buffer, 1, dataBytes, outputSamples);
        //        soundByteOffset += dataBytes;

        //        break;

        //    case SOUND_FORMAT_PCM16:

        //         16 bit-aligned the data
        //        if (soundByteOffset & 1)
        //        {
        //            char ch = 0;
        //            fwrite(&ch, 1, 1, outputSamples);
        //            soundByteOffset++;
        //        }

        //         looped sound
        //        if (loopEnd)
        //        {
        //            sndconvdata->type           = SP_TYPE_PCM16_LOOPED;
        //            sndconvdata->sampleRate     = sampleRate;
        //            sndconvdata->loopAddr       = (soundByteOffset >> 1) + loopStart;
        //            sndconvdata->loopEndAddr    = (soundByteOffset >> 1) + loopEnd;
        //            sndconvdata->endAddr        = (soundByteOffset >> 1) + samples - 1; 
        //            sndconvdata->currentAddr    = soundByteOffset >> 1;
        //            sndconvdata->adpcm          = 0;
        //        }
        //        else
        //        {
        //            sndconvdata->type           = SP_TYPE_PCM16_ONESHOT;
        //            sndconvdata->sampleRate     = sampleRate;
        //            sndconvdata->loopAddr       = 0;
        //            sndconvdata->loopEndAddr    = 0;
        //            sndconvdata->endAddr        = (soundByteOffset >> 1) + samples - 1;
        //            sndconvdata->currentAddr    = soundByteOffset >> 1;
        //            sndconvdata->adpcm          = 0;
        //        }

        //         reverse the endian then write the buffer to data file
        //        reverse_buffer_16(buffer, samples);
        //        fwrite(buffer, 1, dataBytes, outputSamples);
        //        soundByteOffset += dataBytes;

        //        break;
        //    }

        //    if (outputHeader)
        //        fprintf(outputHeader, "#define %s\t\t%d\n", headerId, soundEntries);

        //    soundEntries++;
        //}
    }
}
