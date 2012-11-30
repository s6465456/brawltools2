using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;
using BrawlLib.OpenGL.etc;

namespace BrawlLib.OpenGL
{
    internal unsafe partial class wGlContext : GLContext
    {
        internal override void tkglTbufferMask(Int32 mask) { OpenTK.Graphics.OpenGL.GL.GL_3dfx.TbufferMask(mask); }
        internal override void tkgl2TbufferMask(UInt32 mask) { OpenTK.Graphics.OpenGL.GL.GL_3dfx.TbufferMask(mask); }
        internal override void tkglBeginPerfMonitor(Int32 monitor) { OpenTK.Graphics.OpenGL.GL.Amd.BeginPerfMonitor(monitor); }
        internal override void tkgl2BeginPerfMonitor(UInt32 monitor) { OpenTK.Graphics.OpenGL.GL.Amd.BeginPerfMonitor(monitor); }
        internal override void tkglBlendEquationIndexed(Int32 buf, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend mode) { OpenTK.Graphics.OpenGL.GL.Amd.BlendEquationIndexed(buf, mode); }
        internal override void tkgl2BlendEquationIndexed(UInt32 buf, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend mode) { OpenTK.Graphics.OpenGL.GL.Amd.BlendEquationIndexed(buf, mode); }
        internal override void tkglBlendEquationSeparateIndexed(Int32 buf, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend modeRGB, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend modeAlpha) { OpenTK.Graphics.OpenGL.GL.Amd.BlendEquationSeparateIndexed(buf, modeRGB, modeAlpha); }
        internal override void tkgl2BlendEquationSeparateIndexed(UInt32 buf, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend modeRGB, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend modeAlpha) { OpenTK.Graphics.OpenGL.GL.Amd.BlendEquationSeparateIndexed(buf, modeRGB, modeAlpha); }
        internal override void tkglBlendFuncIndexed(Int32 buf, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend src, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend dst) { OpenTK.Graphics.OpenGL.GL.Amd.BlendFuncIndexed(buf, src, dst); }
        internal override void tkgl2BlendFuncIndexed(UInt32 buf, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend src, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend dst) { OpenTK.Graphics.OpenGL.GL.Amd.BlendFuncIndexed(buf, src, dst); }
        internal override void tkglBlendFuncSeparateIndexed(Int32 buf, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend srcRGB, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend dstRGB, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend srcAlpha, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend dstAlpha) { OpenTK.Graphics.OpenGL.GL.Amd.BlendFuncSeparateIndexed(buf, srcRGB, dstRGB, srcAlpha, dstAlpha); }
        internal override void tkgl2BlendFuncSeparateIndexed(UInt32 buf, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend srcRGB, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend dstRGB, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend srcAlpha, OpenTK.Graphics.OpenGL.AmdDrawBuffersBlend dstAlpha) { OpenTK.Graphics.OpenGL.GL.Amd.BlendFuncSeparateIndexed(buf, srcRGB, dstRGB, srcAlpha, dstAlpha); }
        internal override void tkglDeletePerfMonitors(Int32 n, Int32[] monitors) { OpenTK.Graphics.OpenGL.GL.Amd.DeletePerfMonitors(n, monitors); }
        internal override void tkgl2DeletePerfMonitors(Int32 n, out Int32 monitors) { OpenTK.Graphics.OpenGL.GL.Amd.DeletePerfMonitors(n, out monitors); }
        internal override unsafe void tkgl3DeletePerfMonitors(Int32 n, Int32* monitors) { OpenTK.Graphics.OpenGL.GL.Amd.DeletePerfMonitors(n, monitors); }
        internal override void tkgl4DeletePerfMonitors(Int32 n, UInt32[] monitors) { OpenTK.Graphics.OpenGL.GL.Amd.DeletePerfMonitors(n, monitors); }
        internal override void tkgl5DeletePerfMonitors(Int32 n, out UInt32 monitors) { OpenTK.Graphics.OpenGL.GL.Amd.DeletePerfMonitors(n, out monitors); }
        internal override unsafe void tkgl6DeletePerfMonitors(Int32 n, UInt32* monitors) { OpenTK.Graphics.OpenGL.GL.Amd.DeletePerfMonitors(n, monitors); }
        internal override void tkglEndPerfMonitor(Int32 monitor) { OpenTK.Graphics.OpenGL.GL.Amd.EndPerfMonitor(monitor); }
        internal override void tkgl2EndPerfMonitor(UInt32 monitor) { OpenTK.Graphics.OpenGL.GL.Amd.EndPerfMonitor(monitor); }
        internal override void tkglGenPerfMonitors(Int32 n, Int32[] monitors) { OpenTK.Graphics.OpenGL.GL.Amd.GenPerfMonitors(n, monitors); }
        internal override void tkgl2GenPerfMonitors(Int32 n, out Int32 monitors) { OpenTK.Graphics.OpenGL.GL.Amd.GenPerfMonitors(n, out monitors); }
        internal override unsafe void tkgl3GenPerfMonitors(Int32 n, Int32* monitors) { OpenTK.Graphics.OpenGL.GL.Amd.GenPerfMonitors(n, monitors); }
        internal override void tkgl4GenPerfMonitors(Int32 n, UInt32[] monitors) { OpenTK.Graphics.OpenGL.GL.Amd.GenPerfMonitors(n, monitors); }
        internal override void tkgl5GenPerfMonitors(Int32 n, out UInt32 monitors) { OpenTK.Graphics.OpenGL.GL.Amd.GenPerfMonitors(n, out monitors); }
        internal override unsafe void tkgl6GenPerfMonitors(Int32 n, UInt32* monitors) { OpenTK.Graphics.OpenGL.GL.Amd.GenPerfMonitors(n, monitors); }
        internal override unsafe void tkglGetPerfMonitorCounterData(Int32 monitor, OpenTK.Graphics.OpenGL.AmdPerformanceMonitor pname, Int32 dataSize, Int32[] data, Int32* bytesWritten) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterData(monitor, pname, dataSize, data, bytesWritten); }
        internal override void tkgl2GetPerfMonitorCounterData(Int32 monitor, OpenTK.Graphics.OpenGL.AmdPerformanceMonitor pname, Int32 dataSize, out Int32 data, out Int32 bytesWritten) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterData(monitor, pname, dataSize, out data, out bytesWritten); }
        internal override unsafe void tkgl3GetPerfMonitorCounterData(Int32 monitor, OpenTK.Graphics.OpenGL.AmdPerformanceMonitor pname, Int32 dataSize, Int32* data, Int32* bytesWritten) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterData(monitor, pname, dataSize, data, bytesWritten); }
        internal override unsafe void tkgl4GetPerfMonitorCounterData(UInt32 monitor, OpenTK.Graphics.OpenGL.AmdPerformanceMonitor pname, Int32 dataSize, UInt32[] data, Int32* bytesWritten) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterData(monitor, pname, dataSize, data, bytesWritten); }
        internal override void tkgl5GetPerfMonitorCounterData(UInt32 monitor, OpenTK.Graphics.OpenGL.AmdPerformanceMonitor pname, Int32 dataSize, out UInt32 data, out Int32 bytesWritten) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterData(monitor, pname, dataSize, out data, out bytesWritten); }
        internal override unsafe void tkgl6GetPerfMonitorCounterData(UInt32 monitor, OpenTK.Graphics.OpenGL.AmdPerformanceMonitor pname, Int32 dataSize, UInt32* data, Int32* bytesWritten) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterData(monitor, pname, dataSize, data, bytesWritten); }
        internal override void tkglGetPerfMonitorCounterInfo(Int32 group, Int32 counter, OpenTK.Graphics.OpenGL.AmdPerformanceMonitor pname, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterInfo(group, counter, pname, data); }
        internal override void tkgl2GetPerfMonitorCounterInfo(UInt32 group, UInt32 counter, OpenTK.Graphics.OpenGL.AmdPerformanceMonitor pname, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterInfo(group, counter, pname, data); }
        internal override void tkglGetPerfMonitorCounters(Int32 group, out Int32 numCounters, out Int32 maxActiveCounters, Int32 counterSize, out Int32 counters) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounters(group, out numCounters, out maxActiveCounters, counterSize, out counters); }
        internal override unsafe void tkgl2GetPerfMonitorCounters(Int32 group, Int32* numCounters, Int32* maxActiveCounters, Int32 counterSize, Int32[] counters) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounters(group, numCounters, maxActiveCounters, counterSize, counters); }
        internal override unsafe void tkgl3GetPerfMonitorCounters(Int32 group, Int32* numCounters, Int32* maxActiveCounters, Int32 counterSize, Int32* counters) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounters(group, numCounters, maxActiveCounters, counterSize, counters); }
        internal override void tkgl4GetPerfMonitorCounters(UInt32 group, out Int32 numCounters, out Int32 maxActiveCounters, Int32 counterSize, out UInt32 counters) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounters(group, out numCounters, out maxActiveCounters, counterSize, out counters); }
        internal override unsafe void tkgl5GetPerfMonitorCounters(UInt32 group, Int32* numCounters, Int32* maxActiveCounters, Int32 counterSize, UInt32[] counters) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounters(group, numCounters, maxActiveCounters, counterSize, counters); }
        internal override unsafe void tkgl6GetPerfMonitorCounters(UInt32 group, Int32* numCounters, Int32* maxActiveCounters, Int32 counterSize, UInt32* counters) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounters(group, numCounters, maxActiveCounters, counterSize, counters); }
        internal override void tkglGetPerfMonitorCounterString(Int32 group, Int32 counter, Int32 bufSize, out Int32 length, StringBuilder counterString) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterString(group, counter, bufSize, out length, counterString); }
        internal override unsafe void tkgl2GetPerfMonitorCounterString(Int32 group, Int32 counter, Int32 bufSize, Int32* length, StringBuilder counterString) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterString(group, counter, bufSize, length, counterString); }
        internal override void tkgl3GetPerfMonitorCounterString(UInt32 group, UInt32 counter, Int32 bufSize, out Int32 length, StringBuilder counterString) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterString(group, counter, bufSize, out length, counterString); }
        internal override unsafe void tkgl4GetPerfMonitorCounterString(UInt32 group, UInt32 counter, Int32 bufSize, Int32* length, StringBuilder counterString) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorCounterString(group, counter, bufSize, length, counterString); }
        internal override void tkglGetPerfMonitorGroup(out Int32 numGroups, Int32 groupsSize, out Int32 groups) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroup(out numGroups, groupsSize, out groups); }
        internal override void tkgl2GetPerfMonitorGroup(out Int32 numGroups, Int32 groupsSize, out UInt32 groups) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroup(out numGroups, groupsSize, out groups); }
        internal override unsafe void tkgl3GetPerfMonitorGroup(Int32* numGroups, Int32 groupsSize, Int32[] groups) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroup(numGroups, groupsSize, groups); }
        internal override unsafe void tkgl4GetPerfMonitorGroup(Int32* numGroups, Int32 groupsSize, Int32* groups) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroup(numGroups, groupsSize, groups); }
        internal override unsafe void tkgl5GetPerfMonitorGroup(Int32* numGroups, Int32 groupsSize, UInt32[] groups) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroup(numGroups, groupsSize, groups); }
        internal override unsafe void tkgl6GetPerfMonitorGroup(Int32* numGroups, Int32 groupsSize, UInt32* groups) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroup(numGroups, groupsSize, groups); }
        internal override void tkglGetPerfMonitorGroupString(Int32 group, Int32 bufSize, out Int32 length, StringBuilder groupString) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroupString(group, bufSize, out length, groupString); }
        internal override unsafe void tkgl2GetPerfMonitorGroupString(Int32 group, Int32 bufSize, Int32* length, StringBuilder groupString) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroupString(group, bufSize, length, groupString); }
        internal override void tkgl3GetPerfMonitorGroupString(UInt32 group, Int32 bufSize, out Int32 length, StringBuilder groupString) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroupString(group, bufSize, out length, groupString); }
        internal override unsafe void tkgl4GetPerfMonitorGroupString(UInt32 group, Int32 bufSize, Int32* length, StringBuilder groupString) { OpenTK.Graphics.OpenGL.GL.Amd.GetPerfMonitorGroupString(group, bufSize, length, groupString); }
        internal override void tkglSelectPerfMonitorCounters(Int32 monitor, bool enable, Int32 group, Int32 numCounters, Int32[] counterList) { OpenTK.Graphics.OpenGL.GL.Amd.SelectPerfMonitorCounters(monitor, enable, group, numCounters, counterList); }
        internal override void tkgl2SelectPerfMonitorCounters(Int32 monitor, bool enable, Int32 group, Int32 numCounters, out Int32 counterList) { OpenTK.Graphics.OpenGL.GL.Amd.SelectPerfMonitorCounters(monitor, enable, group, numCounters, out counterList); }
        internal override unsafe void tkgl3SelectPerfMonitorCounters(Int32 monitor, bool enable, Int32 group, Int32 numCounters, Int32* counterList) { OpenTK.Graphics.OpenGL.GL.Amd.SelectPerfMonitorCounters(monitor, enable, group, numCounters, counterList); }
        internal override void tkgl4SelectPerfMonitorCounters(UInt32 monitor, bool enable, UInt32 group, Int32 numCounters, UInt32[] counterList) { OpenTK.Graphics.OpenGL.GL.Amd.SelectPerfMonitorCounters(monitor, enable, group, numCounters, counterList); }
        internal override void tkgl5SelectPerfMonitorCounters(UInt32 monitor, bool enable, UInt32 group, Int32 numCounters, out UInt32 counterList) { OpenTK.Graphics.OpenGL.GL.Amd.SelectPerfMonitorCounters(monitor, enable, group, numCounters, out counterList); }
        internal override unsafe void tkgl6SelectPerfMonitorCounters(UInt32 monitor, bool enable, UInt32 group, Int32 numCounters, UInt32* counterList) { OpenTK.Graphics.OpenGL.GL.Amd.SelectPerfMonitorCounters(monitor, enable, group, numCounters, counterList); }
        internal override void tkglTessellationFactor(Single factor) { OpenTK.Graphics.OpenGL.GL.Amd.TessellationFactor(factor); }
        internal override void tkglTessellationMode(OpenTK.Graphics.OpenGL.AmdVertexShaderTesselator mode) { OpenTK.Graphics.OpenGL.GL.Amd.TessellationMode(mode); }
        internal override void tkglBindVertexArray(Int32 array) { OpenTK.Graphics.OpenGL.GL.Apple.BindVertexArray(array); }
        internal override void tkgl2BindVertexArray(UInt32 array) { OpenTK.Graphics.OpenGL.GL.Apple.BindVertexArray(array); }
        internal override void tkglBufferParameter(OpenTK.Graphics.OpenGL.BufferTarget target, OpenTK.Graphics.OpenGL.BufferParameterApple pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Apple.BufferParameter(target, pname, param); }
        internal override void tkglDeleteFences(Int32 n, Int32[] fences) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteFences(n, fences); }
        internal override void tkgl2DeleteFences(Int32 n, ref Int32 fences) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteFences(n, ref fences); }
        internal override unsafe void tkgl3DeleteFences(Int32 n, Int32* fences) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteFences(n, fences); }
        internal override void tkgl4DeleteFences(Int32 n, UInt32[] fences) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteFences(n, fences); }
        internal override void tkgl5DeleteFences(Int32 n, ref UInt32 fences) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteFences(n, ref fences); }
        internal override unsafe void tkgl6DeleteFences(Int32 n, UInt32* fences) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteFences(n, fences); }
        internal override void tkglDeleteVertexArrays(Int32 n, Int32[] arrays) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteVertexArrays(n, arrays); }
        internal override void tkgl2DeleteVertexArrays(Int32 n, ref Int32 arrays) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteVertexArrays(n, ref arrays); }
        internal override unsafe void tkgl3DeleteVertexArrays(Int32 n, Int32* arrays) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteVertexArrays(n, arrays); }
        internal override void tkgl4DeleteVertexArrays(Int32 n, UInt32[] arrays) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteVertexArrays(n, arrays); }
        internal override void tkgl5DeleteVertexArrays(Int32 n, ref UInt32 arrays) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteVertexArrays(n, ref arrays); }
        internal override unsafe void tkgl6DeleteVertexArrays(Int32 n, UInt32* arrays) { OpenTK.Graphics.OpenGL.GL.Apple.DeleteVertexArrays(n, arrays); }
        internal override void tkglDisableVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.AppleVertexProgramEvaluators pname) { OpenTK.Graphics.OpenGL.GL.Apple.DisableVertexAttrib(index, pname); }
        internal override void tkgl2DisableVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.AppleVertexProgramEvaluators pname) { OpenTK.Graphics.OpenGL.GL.Apple.DisableVertexAttrib(index, pname); }
        internal override void tkglDrawElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 first, Int32 count) { OpenTK.Graphics.OpenGL.GL.Apple.DrawElementArray(mode, first, count); }
        internal override void tkglDrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 end, Int32 first, Int32 count) { OpenTK.Graphics.OpenGL.GL.Apple.DrawRangeElementArray(mode, start, end, first, count); }
        internal override void tkgl2DrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 first, Int32 count) { OpenTK.Graphics.OpenGL.GL.Apple.DrawRangeElementArray(mode, start, end, first, count); }
        internal override void tkglElementPointer(OpenTK.Graphics.OpenGL.AppleElementArray type, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Apple.ElementPointer(type, pointer); }
        internal override void tkglEnableVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.AppleVertexProgramEvaluators pname) { OpenTK.Graphics.OpenGL.GL.Apple.EnableVertexAttrib(index, pname); }
        internal override void tkgl2EnableVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.AppleVertexProgramEvaluators pname) { OpenTK.Graphics.OpenGL.GL.Apple.EnableVertexAttrib(index, pname); }
        internal override void tkglFinishFence(Int32 fence) { OpenTK.Graphics.OpenGL.GL.Apple.FinishFence(fence); }
        internal override void tkgl2FinishFence(UInt32 fence) { OpenTK.Graphics.OpenGL.GL.Apple.FinishFence(fence); }
        internal override void tkglFinishObject(OpenTK.Graphics.OpenGL.AppleFence @object, Int32 name) { OpenTK.Graphics.OpenGL.GL.Apple.FinishObject(@object, name); }
        internal override void tkglFlushMappedBufferRange(OpenTK.Graphics.OpenGL.BufferTarget target, IntPtr offset, IntPtr size) { OpenTK.Graphics.OpenGL.GL.Apple.FlushMappedBufferRange(target, offset, size); }
        internal override void tkglFlushVertexArrayRange(Int32 length, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Apple.FlushVertexArrayRange(length, pointer); }
        internal override void tkglGenFences(Int32 n, Int32[] fences) { OpenTK.Graphics.OpenGL.GL.Apple.GenFences(n, fences); }
        internal override void tkgl2GenFences(Int32 n, out Int32 fences) { OpenTK.Graphics.OpenGL.GL.Apple.GenFences(n, out fences); }
        internal override unsafe void tkgl3GenFences(Int32 n, Int32* fences) { OpenTK.Graphics.OpenGL.GL.Apple.GenFences(n, fences); }
        internal override void tkgl4GenFences(Int32 n, UInt32[] fences) { OpenTK.Graphics.OpenGL.GL.Apple.GenFences(n, fences); }
        internal override void tkgl5GenFences(Int32 n, out UInt32 fences) { OpenTK.Graphics.OpenGL.GL.Apple.GenFences(n, out fences); }
        internal override unsafe void tkgl6GenFences(Int32 n, UInt32* fences) { OpenTK.Graphics.OpenGL.GL.Apple.GenFences(n, fences); }
        internal override void tkglGenVertexArrays(Int32 n, Int32[] arrays) { OpenTK.Graphics.OpenGL.GL.Apple.GenVertexArrays(n, arrays); }
        internal override void tkgl2GenVertexArrays(Int32 n, out Int32 arrays) { OpenTK.Graphics.OpenGL.GL.Apple.GenVertexArrays(n, out arrays); }
        internal override unsafe void tkgl3GenVertexArrays(Int32 n, Int32* arrays) { OpenTK.Graphics.OpenGL.GL.Apple.GenVertexArrays(n, arrays); }
        internal override void tkgl4GenVertexArrays(Int32 n, UInt32[] arrays) { OpenTK.Graphics.OpenGL.GL.Apple.GenVertexArrays(n, arrays); }
        internal override void tkgl5GenVertexArrays(Int32 n, out UInt32 arrays) { OpenTK.Graphics.OpenGL.GL.Apple.GenVertexArrays(n, out arrays); }
        internal override unsafe void tkgl6GenVertexArrays(Int32 n, UInt32* arrays) { OpenTK.Graphics.OpenGL.GL.Apple.GenVertexArrays(n, arrays); }
        internal override void tkglGetObjectParameter(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, Int32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Apple.GetObjectParameter(objectType, name, pname, @params); }
        internal override void tkgl2GetObjectParameter(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, Int32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Apple.GetObjectParameter(objectType, name, pname, out @params); }
        internal override unsafe void tkgl3GetObjectParameter(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, Int32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Apple.GetObjectParameter(objectType, name, pname, @params); }
        internal override void tkgl4GetObjectParameter(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, UInt32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Apple.GetObjectParameter(objectType, name, pname, @params); }
        internal override void tkgl5GetObjectParameter(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, UInt32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Apple.GetObjectParameter(objectType, name, pname, out @params); }
        internal override unsafe void tkgl6GetObjectParameter(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, UInt32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Apple.GetObjectParameter(objectType, name, pname, @params); }
        internal override void tkglGetTexParameterPointer(OpenTK.Graphics.OpenGL.AppleTextureRange target, OpenTK.Graphics.OpenGL.AppleTextureRange pname, IntPtr @params) { OpenTK.Graphics.OpenGL.GL.Apple.GetTexParameterPointer(target, pname, @params); }
        internal override bool tkglIsFence(Int32 fence) { return OpenTK.Graphics.OpenGL.GL.Apple.IsFence(fence); }
        internal override bool tkgl2IsFence(UInt32 fence) { return OpenTK.Graphics.OpenGL.GL.Apple.IsFence(fence); }
        internal override bool tkglIsVertexArray(Int32 array) { return OpenTK.Graphics.OpenGL.GL.Apple.IsVertexArray(array); }
        internal override bool tkgl2IsVertexArray(UInt32 array) { return OpenTK.Graphics.OpenGL.GL.Apple.IsVertexArray(array); }
        internal override bool tkglIsVertexAttribEnabled(Int32 index, OpenTK.Graphics.OpenGL.AppleVertexProgramEvaluators pname) { return OpenTK.Graphics.OpenGL.GL.Apple.IsVertexAttribEnabled(index, pname); }
        internal override bool tkgl2IsVertexAttribEnabled(UInt32 index, OpenTK.Graphics.OpenGL.AppleVertexProgramEvaluators pname) { return OpenTK.Graphics.OpenGL.GL.Apple.IsVertexAttribEnabled(index, pname); }
        internal override void tkglMapVertexAttrib1(Int32 index, Int32 size, Double u1, Double u2, Int32 stride, Int32 order, Double[] points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, points); }
        internal override void tkgl2MapVertexAttrib1(Int32 index, Int32 size, Double u1, Double u2, Int32 stride, Int32 order, ref Double points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, ref points); }
        internal override unsafe void tkgl3MapVertexAttrib1(Int32 index, Int32 size, Double u1, Double u2, Int32 stride, Int32 order, Double* points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, points); }
        internal override void tkgl4MapVertexAttrib1(UInt32 index, UInt32 size, Double u1, Double u2, Int32 stride, Int32 order, Double[] points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, points); }
        internal override void tkgl5MapVertexAttrib1(UInt32 index, UInt32 size, Double u1, Double u2, Int32 stride, Int32 order, ref Double points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, ref points); }
        internal override unsafe void tkgl6MapVertexAttrib1(UInt32 index, UInt32 size, Double u1, Double u2, Int32 stride, Int32 order, Double* points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, points); }
        internal override void tkgl7MapVertexAttrib1(Int32 index, Int32 size, Single u1, Single u2, Int32 stride, Int32 order, Single[] points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, points); }
        internal override void tkgl8MapVertexAttrib1(Int32 index, Int32 size, Single u1, Single u2, Int32 stride, Int32 order, ref Single points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, ref points); }
        internal override unsafe void tkgl9MapVertexAttrib1(Int32 index, Int32 size, Single u1, Single u2, Int32 stride, Int32 order, Single* points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, points); }
        internal override void tkgl10MapVertexAttrib1(UInt32 index, UInt32 size, Single u1, Single u2, Int32 stride, Int32 order, Single[] points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, points); }
        internal override void tkgl11MapVertexAttrib1(UInt32 index, UInt32 size, Single u1, Single u2, Int32 stride, Int32 order, ref Single points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, ref points); }
        internal override unsafe void tkgl12MapVertexAttrib1(UInt32 index, UInt32 size, Single u1, Single u2, Int32 stride, Int32 order, Single* points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib1(index, size, u1, u2, stride, order, points); }
        internal override void tkglMapVertexAttrib2(Int32 index, Int32 size, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double[] points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl2MapVertexAttrib2(Int32 index, Int32 size, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, ref Double points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, ref points); }
        internal override unsafe void tkgl3MapVertexAttrib2(Int32 index, Int32 size, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double* points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl4MapVertexAttrib2(UInt32 index, UInt32 size, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double[] points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl5MapVertexAttrib2(UInt32 index, UInt32 size, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, ref Double points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, ref points); }
        internal override unsafe void tkgl6MapVertexAttrib2(UInt32 index, UInt32 size, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double* points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl7MapVertexAttrib2(Int32 index, Int32 size, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single[] points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl8MapVertexAttrib2(Int32 index, Int32 size, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, ref Single points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, ref points); }
        internal override unsafe void tkgl9MapVertexAttrib2(Int32 index, Int32 size, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single* points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl10MapVertexAttrib2(UInt32 index, UInt32 size, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single[] points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl11MapVertexAttrib2(UInt32 index, UInt32 size, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, ref Single points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, ref points); }
        internal override unsafe void tkgl12MapVertexAttrib2(UInt32 index, UInt32 size, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single* points) { OpenTK.Graphics.OpenGL.GL.Apple.MapVertexAttrib2(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkglMultiDrawElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32[] first, Int32[] count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawElementArray(mode, first, count, primcount); }
        internal override void tkgl2MultiDrawElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, ref Int32 first, ref Int32 count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawElementArray(mode, ref first, ref count, primcount); }
        internal override unsafe void tkgl3MultiDrawElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32* first, Int32* count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawElementArray(mode, first, count, primcount); }
        internal override void tkglMultiDrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 end, Int32[] first, Int32[] count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawRangeElementArray(mode, start, end, first, count, primcount); }
        internal override void tkgl2MultiDrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 end, ref Int32 first, ref Int32 count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawRangeElementArray(mode, start, end, ref first, ref count, primcount); }
        internal override unsafe void tkgl3MultiDrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 end, Int32* first, Int32* count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawRangeElementArray(mode, start, end, first, count, primcount); }
        internal override void tkgl4MultiDrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32[] first, Int32[] count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawRangeElementArray(mode, start, end, first, count, primcount); }
        internal override void tkgl5MultiDrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, UInt32 start, UInt32 end, ref Int32 first, ref Int32 count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawRangeElementArray(mode, start, end, ref first, ref count, primcount); }
        internal override unsafe void tkgl6MultiDrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32* first, Int32* count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Apple.MultiDrawRangeElementArray(mode, start, end, first, count, primcount); }
        internal override System.IntPtr tkglObjectPurgeable(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, Int32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable option) { return OpenTK.Graphics.OpenGL.GL.Apple.ObjectPurgeable(objectType, name, option); }
        internal override System.IntPtr tkgl2ObjectPurgeable(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, UInt32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable option) { return OpenTK.Graphics.OpenGL.GL.Apple.ObjectPurgeable(objectType, name, option); }
        internal override System.IntPtr tkglObjectUnpurgeable(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, Int32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable option) { return OpenTK.Graphics.OpenGL.GL.Apple.ObjectUnpurgeable(objectType, name, option); }
        internal override System.IntPtr tkgl2ObjectUnpurgeable(OpenTK.Graphics.OpenGL.AppleObjectPurgeable objectType, UInt32 name, OpenTK.Graphics.OpenGL.AppleObjectPurgeable option) { return OpenTK.Graphics.OpenGL.GL.Apple.ObjectUnpurgeable(objectType, name, option); }
        internal override void tkglSetFence(Int32 fence) { OpenTK.Graphics.OpenGL.GL.Apple.SetFence(fence); }
        internal override void tkgl2SetFence(UInt32 fence) { OpenTK.Graphics.OpenGL.GL.Apple.SetFence(fence); }
        internal override bool tkglTestFence(Int32 fence) { return OpenTK.Graphics.OpenGL.GL.Apple.TestFence(fence); }
        internal override bool tkgl2TestFence(UInt32 fence) { return OpenTK.Graphics.OpenGL.GL.Apple.TestFence(fence); }
        internal override bool tkglTestObject(OpenTK.Graphics.OpenGL.AppleFence @object, Int32 name) { return OpenTK.Graphics.OpenGL.GL.Apple.TestObject(@object, name); }
        internal override bool tkgl2TestObject(OpenTK.Graphics.OpenGL.AppleFence @object, UInt32 name) { return OpenTK.Graphics.OpenGL.GL.Apple.TestObject(@object, name); }
        internal override void tkglTextureRange(OpenTK.Graphics.OpenGL.AppleTextureRange target, Int32 length, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Apple.TextureRange(target, length, pointer); }
        internal override void tkglVertexArrayParameter(OpenTK.Graphics.OpenGL.AppleVertexArrayRange pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Apple.VertexArrayParameter(pname, param); }
        internal override void tkglVertexArrayRange(Int32 length, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Apple.VertexArrayRange(length, pointer); }
        internal override void tkglActiveTexture(OpenTK.Graphics.OpenGL.TextureUnit texture) { OpenTK.Graphics.OpenGL.GL.Arb.ActiveTexture(texture); }
        internal override void tkglAttachObject(Int32 containerObj, Int32 obj) { OpenTK.Graphics.OpenGL.GL.Arb.AttachObject(containerObj, obj); }
        internal override void tkgl2AttachObject(UInt32 containerObj, UInt32 obj) { OpenTK.Graphics.OpenGL.GL.Arb.AttachObject(containerObj, obj); }
        internal override void tkglBeginQuery(OpenTK.Graphics.OpenGL.ArbOcclusionQuery target, Int32 id) { OpenTK.Graphics.OpenGL.GL.Arb.BeginQuery(target, id); }
        internal override void tkgl2BeginQuery(OpenTK.Graphics.OpenGL.ArbOcclusionQuery target, UInt32 id) { OpenTK.Graphics.OpenGL.GL.Arb.BeginQuery(target, id); }
        internal override void tkglBindAttribLocation(Int32 programObj, Int32 index, String name) { OpenTK.Graphics.OpenGL.GL.Arb.BindAttribLocation(programObj, index, name); }
        internal override void tkgl2BindAttribLocation(UInt32 programObj, UInt32 index, String name) { OpenTK.Graphics.OpenGL.GL.Arb.BindAttribLocation(programObj, index, name); }
        internal override void tkglBindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb target, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(target, buffer); }
        internal override void tkgl2BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb target, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(target, buffer); }
        internal override void tkglBindProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 program) { OpenTK.Graphics.OpenGL.GL.Arb.BindProgram(target, program); }
        internal override void tkgl2BindProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 program) { OpenTK.Graphics.OpenGL.GL.Arb.BindProgram(target, program); }
        internal override void tkglBufferData(OpenTK.Graphics.OpenGL.BufferTargetArb target, IntPtr size, IntPtr data, OpenTK.Graphics.OpenGL.BufferUsageArb usage) { OpenTK.Graphics.OpenGL.GL.Arb.BufferData(target, size, data, usage); }
        internal override void tkglBufferSubData(OpenTK.Graphics.OpenGL.BufferTargetArb target, IntPtr offset, IntPtr size, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Arb.BufferSubData(target, offset, size, data); }
        internal override void tkglClampColor(OpenTK.Graphics.OpenGL.ArbColorBufferFloat target, OpenTK.Graphics.OpenGL.ArbColorBufferFloat clamp) { OpenTK.Graphics.OpenGL.GL.Arb.ClampColor(target, clamp); }
        internal override void tkglClientActiveTexture(OpenTK.Graphics.OpenGL.TextureUnit texture) { OpenTK.Graphics.OpenGL.GL.Arb.ClientActiveTexture(texture); }
        internal override void tkglCompileShader(Int32 shaderObj) { OpenTK.Graphics.OpenGL.GL.Arb.CompileShader(shaderObj); }
        internal override void tkgl2CompileShader(UInt32 shaderObj) { OpenTK.Graphics.OpenGL.GL.Arb.CompileShader(shaderObj); }
        internal override void tkglCompressedTexImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 border, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Arb.CompressedTexImage1D(target, level, internalformat, width, border, imageSize, data); }
        internal override void tkglCompressedTexImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Arb.CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data); }
        internal override void tkglCompressedTexImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Arb.CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data); }
        internal override void tkglCompressedTexSubImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Arb.CompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, data); }
        internal override void tkglCompressedTexSubImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Arb.CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data); }
        internal override void tkglCompressedTexSubImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Arb.CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data); }
        internal override Int32 tkglCreateProgramObject() { return OpenTK.Graphics.OpenGL.GL.Arb.CreateProgramObject(); }
        internal override Int32 tkglCreateShaderObject(OpenTK.Graphics.OpenGL.ArbShaderObjects shaderType) { return OpenTK.Graphics.OpenGL.GL.Arb.CreateShaderObject(shaderType); }
        internal override void tkglCurrentPaletteMatrix(Int32 index) { OpenTK.Graphics.OpenGL.GL.Arb.CurrentPaletteMatrix(index); }
        internal override void tkglDeleteBuffers(Int32 n, Int32[] buffers) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteBuffers(n, buffers); }
        internal override void tkgl2DeleteBuffers(Int32 n, ref Int32 buffers) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteBuffers(n, ref buffers); }
        internal override unsafe void tkgl3DeleteBuffers(Int32 n, Int32* buffers) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteBuffers(n, buffers); }
        internal override void tkgl4DeleteBuffers(Int32 n, UInt32[] buffers) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteBuffers(n, buffers); }
        internal override void tkgl5DeleteBuffers(Int32 n, ref UInt32 buffers) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteBuffers(n, ref buffers); }
        internal override unsafe void tkgl6DeleteBuffers(Int32 n, UInt32* buffers) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteBuffers(n, buffers); }
        internal override void tkglDeleteObject(Int32 obj) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteObject(obj); }
        internal override void tkgl2DeleteObject(UInt32 obj) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteObject(obj); }
        internal override void tkglDeleteProgram(Int32 n, Int32[] programs) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteProgram(n, programs); }
        internal override void tkgl2DeleteProgram(Int32 n, ref Int32 programs) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteProgram(n, ref programs); }
        internal override unsafe void tkgl3DeleteProgram(Int32 n, Int32* programs) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteProgram(n, programs); }
        internal override void tkgl4DeleteProgram(Int32 n, UInt32[] programs) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteProgram(n, programs); }
        internal override void tkgl5DeleteProgram(Int32 n, ref UInt32 programs) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteProgram(n, ref programs); }
        internal override unsafe void tkgl6DeleteProgram(Int32 n, UInt32* programs) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteProgram(n, programs); }
        internal override void tkglDeleteQueries(Int32 n, Int32[] ids) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteQueries(n, ids); }
        internal override void tkgl2DeleteQueries(Int32 n, ref Int32 ids) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteQueries(n, ref ids); }
        internal override unsafe void tkgl3DeleteQueries(Int32 n, Int32* ids) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteQueries(n, ids); }
        internal override void tkgl4DeleteQueries(Int32 n, UInt32[] ids) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteQueries(n, ids); }
        internal override void tkgl5DeleteQueries(Int32 n, ref UInt32 ids) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteQueries(n, ref ids); }
        internal override unsafe void tkgl6DeleteQueries(Int32 n, UInt32* ids) { OpenTK.Graphics.OpenGL.GL.Arb.DeleteQueries(n, ids); }
        internal override void tkglDetachObject(Int32 containerObj, Int32 attachedObj) { OpenTK.Graphics.OpenGL.GL.Arb.DetachObject(containerObj, attachedObj); }
        internal override void tkgl2DetachObject(UInt32 containerObj, UInt32 attachedObj) { OpenTK.Graphics.OpenGL.GL.Arb.DetachObject(containerObj, attachedObj); }
        internal override void tkglDisableVertexAttribArray(Int32 index) { OpenTK.Graphics.OpenGL.GL.Arb.DisableVertexAttribArray(index); }
        internal override void tkgl2DisableVertexAttribArray(UInt32 index) { OpenTK.Graphics.OpenGL.GL.Arb.DisableVertexAttribArray(index); }
        internal override void tkglDrawArraysInstanced(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 first, Int32 count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Arb.DrawArraysInstanced(mode, first, count, primcount); }
        internal override void tkglDrawBuffers(Int32 n, OpenTK.Graphics.OpenGL.ArbDrawBuffers[] bufs) { OpenTK.Graphics.OpenGL.GL.Arb.DrawBuffers(n, bufs); }
        internal override void tkgl2DrawBuffers(Int32 n, ref OpenTK.Graphics.OpenGL.ArbDrawBuffers bufs) { OpenTK.Graphics.OpenGL.GL.Arb.DrawBuffers(n, ref bufs); }
        internal override unsafe void tkgl3DrawBuffers(Int32 n, OpenTK.Graphics.OpenGL.ArbDrawBuffers* bufs) { OpenTK.Graphics.OpenGL.GL.Arb.DrawBuffers(n, bufs); }
        internal override void tkglDrawElementsInstanced(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Arb.DrawElementsInstanced(mode, count, type, indices, primcount); }
        internal override void tkglEnableVertexAttribArray(Int32 index) { OpenTK.Graphics.OpenGL.GL.Arb.EnableVertexAttribArray(index); }
        internal override void tkgl2EnableVertexAttribArray(UInt32 index) { OpenTK.Graphics.OpenGL.GL.Arb.EnableVertexAttribArray(index); }
        internal override void tkglEndQuery(OpenTK.Graphics.OpenGL.ArbOcclusionQuery target) { OpenTK.Graphics.OpenGL.GL.Arb.EndQuery(target); }
        internal override void tkglFramebufferTexture(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Arb.FramebufferTexture(target, attachment, texture, level); }
        internal override void tkgl2FramebufferTexture(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Arb.FramebufferTexture(target, attachment, texture, level); }
        internal override void tkglFramebufferTextureFace(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level, OpenTK.Graphics.OpenGL.TextureTarget face) { OpenTK.Graphics.OpenGL.GL.Arb.FramebufferTextureFace(target, attachment, texture, level, face); }
        internal override void tkgl2FramebufferTextureFace(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, OpenTK.Graphics.OpenGL.TextureTarget face) { OpenTK.Graphics.OpenGL.GL.Arb.FramebufferTextureFace(target, attachment, texture, level, face); }
        internal override void tkglFramebufferTextureLayer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level, Int32 layer) { OpenTK.Graphics.OpenGL.GL.Arb.FramebufferTextureLayer(target, attachment, texture, level, layer); }
        internal override void tkgl2FramebufferTextureLayer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, Int32 layer) { OpenTK.Graphics.OpenGL.GL.Arb.FramebufferTextureLayer(target, attachment, texture, level, layer); }
        internal override void tkglGenBuffers(Int32 n, Int32[] buffers) { OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(n, buffers); }
        internal override void tkgl2GenBuffers(Int32 n, out Int32 buffers) { OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(n, out buffers); }
        internal override unsafe void tkgl3GenBuffers(Int32 n, Int32* buffers) { OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(n, buffers); }
        internal override void tkgl4GenBuffers(Int32 n, UInt32[] buffers) { OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(n, buffers); }
        internal override void tkgl5GenBuffers(Int32 n, out UInt32 buffers) { OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(n, out buffers); }
        internal override unsafe void tkgl6GenBuffers(Int32 n, UInt32* buffers) { OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(n, buffers); }
        internal override void tkglGenProgram(Int32 n, Int32[] programs) { OpenTK.Graphics.OpenGL.GL.Arb.GenProgram(n, programs); }
        internal override void tkgl2GenProgram(Int32 n, out Int32 programs) { OpenTK.Graphics.OpenGL.GL.Arb.GenProgram(n, out programs); }
        internal override unsafe void tkgl3GenProgram(Int32 n, Int32* programs) { OpenTK.Graphics.OpenGL.GL.Arb.GenProgram(n, programs); }
        internal override void tkgl4GenProgram(Int32 n, UInt32[] programs) { OpenTK.Graphics.OpenGL.GL.Arb.GenProgram(n, programs); }
        internal override void tkgl5GenProgram(Int32 n, out UInt32 programs) { OpenTK.Graphics.OpenGL.GL.Arb.GenProgram(n, out programs); }
        internal override unsafe void tkgl6GenProgram(Int32 n, UInt32* programs) { OpenTK.Graphics.OpenGL.GL.Arb.GenProgram(n, programs); }
        internal override void tkglGenQueries(Int32 n, Int32[] ids) { OpenTK.Graphics.OpenGL.GL.Arb.GenQueries(n, ids); }
        internal override void tkgl2GenQueries(Int32 n, out Int32 ids) { OpenTK.Graphics.OpenGL.GL.Arb.GenQueries(n, out ids); }
        internal override unsafe void tkgl3GenQueries(Int32 n, Int32* ids) { OpenTK.Graphics.OpenGL.GL.Arb.GenQueries(n, ids); }
        internal override void tkgl4GenQueries(Int32 n, UInt32[] ids) { OpenTK.Graphics.OpenGL.GL.Arb.GenQueries(n, ids); }
        internal override void tkgl5GenQueries(Int32 n, out UInt32 ids) { OpenTK.Graphics.OpenGL.GL.Arb.GenQueries(n, out ids); }
        internal override unsafe void tkgl6GenQueries(Int32 n, UInt32* ids) { OpenTK.Graphics.OpenGL.GL.Arb.GenQueries(n, ids); }
        internal override void tkglGetActiveAttrib(Int32 programObj, Int32 index, Int32 maxLength, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ArbVertexShader type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Arb.GetActiveAttrib(programObj, index, maxLength, out length, out size, out type, name); }
        internal override unsafe void tkgl2GetActiveAttrib(Int32 programObj, Int32 index, Int32 maxLength, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ArbVertexShader* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Arb.GetActiveAttrib(programObj, index, maxLength, length, size, type, name); }
        internal override void tkgl3GetActiveAttrib(UInt32 programObj, UInt32 index, Int32 maxLength, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ArbVertexShader type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Arb.GetActiveAttrib(programObj, index, maxLength, out length, out size, out type, name); }
        internal override unsafe void tkgl4GetActiveAttrib(UInt32 programObj, UInt32 index, Int32 maxLength, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ArbVertexShader* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Arb.GetActiveAttrib(programObj, index, maxLength, length, size, type, name); }
        internal override void tkglGetActiveUniform(Int32 programObj, Int32 index, Int32 maxLength, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ArbShaderObjects type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Arb.GetActiveUniform(programObj, index, maxLength, out length, out size, out type, name); }
        internal override unsafe void tkgl2GetActiveUniform(Int32 programObj, Int32 index, Int32 maxLength, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ArbShaderObjects* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Arb.GetActiveUniform(programObj, index, maxLength, length, size, type, name); }
        internal override void tkgl3GetActiveUniform(UInt32 programObj, UInt32 index, Int32 maxLength, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ArbShaderObjects type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Arb.GetActiveUniform(programObj, index, maxLength, out length, out size, out type, name); }
        internal override unsafe void tkgl4GetActiveUniform(UInt32 programObj, UInt32 index, Int32 maxLength, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ArbShaderObjects* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Arb.GetActiveUniform(programObj, index, maxLength, length, size, type, name); }
        internal override void tkglGetAttachedObjects(Int32 containerObj, Int32 maxCount, out Int32 count, out Int32 obj) { OpenTK.Graphics.OpenGL.GL.Arb.GetAttachedObjects(containerObj, maxCount, out count, out obj); }
        internal override unsafe void tkgl2GetAttachedObjects(Int32 containerObj, Int32 maxCount, Int32* count, Int32[] obj) { OpenTK.Graphics.OpenGL.GL.Arb.GetAttachedObjects(containerObj, maxCount, count, obj); }
        internal override unsafe void tkgl3GetAttachedObjects(Int32 containerObj, Int32 maxCount, Int32* count, Int32* obj) { OpenTK.Graphics.OpenGL.GL.Arb.GetAttachedObjects(containerObj, maxCount, count, obj); }
        internal override void tkgl4GetAttachedObjects(UInt32 containerObj, Int32 maxCount, out Int32 count, out UInt32 obj) { OpenTK.Graphics.OpenGL.GL.Arb.GetAttachedObjects(containerObj, maxCount, out count, out obj); }
        internal override unsafe void tkgl5GetAttachedObjects(UInt32 containerObj, Int32 maxCount, Int32* count, UInt32[] obj) { OpenTK.Graphics.OpenGL.GL.Arb.GetAttachedObjects(containerObj, maxCount, count, obj); }
        internal override unsafe void tkgl6GetAttachedObjects(UInt32 containerObj, Int32 maxCount, Int32* count, UInt32* obj) { OpenTK.Graphics.OpenGL.GL.Arb.GetAttachedObjects(containerObj, maxCount, count, obj); }
        internal override Int32 tkglGetAttribLocation(Int32 programObj, String name) { return OpenTK.Graphics.OpenGL.GL.Arb.GetAttribLocation(programObj, name); }
        internal override Int32 tkgl2GetAttribLocation(UInt32 programObj, String name) { return OpenTK.Graphics.OpenGL.GL.Arb.GetAttribLocation(programObj, name); }
        internal override void tkglGetBufferParameter(OpenTK.Graphics.OpenGL.ArbVertexBufferObject target, OpenTK.Graphics.OpenGL.BufferParameterNameArb pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetBufferParameter(target, pname, @params); }
        internal override void tkgl2GetBufferParameter(OpenTK.Graphics.OpenGL.ArbVertexBufferObject target, OpenTK.Graphics.OpenGL.BufferParameterNameArb pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetBufferParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetBufferParameter(OpenTK.Graphics.OpenGL.ArbVertexBufferObject target, OpenTK.Graphics.OpenGL.BufferParameterNameArb pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetBufferParameter(target, pname, @params); }
        internal override void tkglGetBufferPointer(OpenTK.Graphics.OpenGL.ArbVertexBufferObject target, OpenTK.Graphics.OpenGL.BufferPointerNameArb pname, IntPtr @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetBufferPointer(target, pname, @params); }
        internal override void tkglGetBufferSubData(OpenTK.Graphics.OpenGL.BufferTargetArb target, IntPtr offset, IntPtr size, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Arb.GetBufferSubData(target, offset, size, data); }
        internal override void tkglGetCompressedTexImage(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, IntPtr img) { OpenTK.Graphics.OpenGL.GL.Arb.GetCompressedTexImage(target, level, img); }
        internal override Int32 tkglGetHandle(OpenTK.Graphics.OpenGL.ArbShaderObjects pname) { return OpenTK.Graphics.OpenGL.GL.Arb.GetHandle(pname); }
        internal override void tkglGetInfoLog(Int32 obj, Int32 maxLength, out Int32 length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.Arb.GetInfoLog(obj, maxLength, out length, infoLog); }
        internal override unsafe void tkgl2GetInfoLog(Int32 obj, Int32 maxLength, Int32* length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.Arb.GetInfoLog(obj, maxLength, length, infoLog); }
        internal override void tkgl3GetInfoLog(UInt32 obj, Int32 maxLength, out Int32 length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.Arb.GetInfoLog(obj, maxLength, out length, infoLog); }
        internal override unsafe void tkgl4GetInfoLog(UInt32 obj, Int32 maxLength, Int32* length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.Arb.GetInfoLog(obj, maxLength, length, infoLog); }
        internal override void tkgl7GetObjectParameter(Int32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, @params); }
        internal override void tkgl8GetObjectParameter(Int32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, out @params); }
        internal override unsafe void tkgl9GetObjectParameter(Int32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, @params); }
        internal override void tkgl10GetObjectParameter(UInt32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, @params); }
        internal override void tkgl11GetObjectParameter(UInt32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, out @params); }
        internal override unsafe void tkgl12GetObjectParameter(UInt32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, @params); }
        internal override void tkgl13GetObjectParameter(Int32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, @params); }
        internal override void tkgl14GetObjectParameter(Int32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, out @params); }
        internal override unsafe void tkgl15GetObjectParameter(Int32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, @params); }
        internal override void tkgl16GetObjectParameter(UInt32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, @params); }
        internal override void tkgl17GetObjectParameter(UInt32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, out @params); }
        internal override unsafe void tkgl18GetObjectParameter(UInt32 obj, OpenTK.Graphics.OpenGL.ArbShaderObjects pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetObjectParameter(obj, pname, @params); }
        internal override void tkglGetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, @params); }
        internal override void tkgl2GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, out Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, out @params); }
        internal override unsafe void tkgl3GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, @params); }
        internal override void tkgl4GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, @params); }
        internal override void tkgl5GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, out Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, out @params); }
        internal override unsafe void tkgl6GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, @params); }
        internal override void tkgl7GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, @params); }
        internal override void tkgl8GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, out @params); }
        internal override unsafe void tkgl9GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, @params); }
        internal override void tkgl10GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, @params); }
        internal override void tkgl11GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, out @params); }
        internal override unsafe void tkgl12GetProgramEnvParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramEnvParameter(target, index, @params); }
        internal override void tkglGetProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgram(target, pname, out @params); }
        internal override unsafe void tkgl2GetProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgram(target, pname, @params); }
        internal override void tkglGetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, @params); }
        internal override void tkgl2GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, out Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, out @params); }
        internal override unsafe void tkgl3GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, @params); }
        internal override void tkgl4GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, @params); }
        internal override void tkgl5GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, out Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, out @params); }
        internal override unsafe void tkgl6GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, @params); }
        internal override void tkgl7GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, @params); }
        internal override void tkgl8GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, out @params); }
        internal override unsafe void tkgl9GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, Int32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, @params); }
        internal override void tkgl10GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, @params); }
        internal override void tkgl11GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, out @params); }
        internal override unsafe void tkgl12GetProgramLocalParameter(OpenTK.Graphics.OpenGL.ArbVertexProgram target, UInt32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramLocalParameter(target, index, @params); }
        internal override void tkglGetProgramString(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, IntPtr @string) { OpenTK.Graphics.OpenGL.GL.Arb.GetProgramString(target, pname, @string); }
        internal override void tkglGetQuery(OpenTK.Graphics.OpenGL.ArbOcclusionQuery target, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQuery(target, pname, @params); }
        internal override void tkgl2GetQuery(OpenTK.Graphics.OpenGL.ArbOcclusionQuery target, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQuery(target, pname, out @params); }
        internal override unsafe void tkgl3GetQuery(OpenTK.Graphics.OpenGL.ArbOcclusionQuery target, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQuery(target, pname, @params); }
        internal override void tkglGetQueryObject(Int32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, @params); }
        internal override void tkgl2GetQueryObject(Int32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, out @params); }
        internal override unsafe void tkgl3GetQueryObject(Int32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, @params); }
        internal override void tkgl4GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, @params); }
        internal override void tkgl5GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, out @params); }
        internal override unsafe void tkgl6GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, @params); }
        internal override void tkgl7GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, @params); }
        internal override void tkgl8GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, out @params); }
        internal override unsafe void tkgl9GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.ArbOcclusionQuery pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetQueryObject(id, pname, @params); }
        internal override void tkglGetShaderSource(Int32 obj, Int32 maxLength, out Int32 length, StringBuilder source) { OpenTK.Graphics.OpenGL.GL.Arb.GetShaderSource(obj, maxLength, out length, source); }
        internal override unsafe void tkgl2GetShaderSource(Int32 obj, Int32 maxLength, Int32* length, StringBuilder source) { OpenTK.Graphics.OpenGL.GL.Arb.GetShaderSource(obj, maxLength, length, source); }
        internal override void tkgl3GetShaderSource(UInt32 obj, Int32 maxLength, out Int32 length, StringBuilder source) { OpenTK.Graphics.OpenGL.GL.Arb.GetShaderSource(obj, maxLength, out length, source); }
        internal override unsafe void tkgl4GetShaderSource(UInt32 obj, Int32 maxLength, Int32* length, StringBuilder source) { OpenTK.Graphics.OpenGL.GL.Arb.GetShaderSource(obj, maxLength, length, source); }
        internal override void tkglGetUniform(Int32 programObj, Int32 location, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, @params); }
        internal override void tkgl2GetUniform(Int32 programObj, Int32 location, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, out @params); }
        internal override unsafe void tkgl3GetUniform(Int32 programObj, Int32 location, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, @params); }
        internal override void tkgl4GetUniform(UInt32 programObj, Int32 location, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, @params); }
        internal override void tkgl5GetUniform(UInt32 programObj, Int32 location, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, out @params); }
        internal override unsafe void tkgl6GetUniform(UInt32 programObj, Int32 location, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, @params); }
        internal override void tkgl7GetUniform(Int32 programObj, Int32 location, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, @params); }
        internal override void tkgl8GetUniform(Int32 programObj, Int32 location, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, out @params); }
        internal override unsafe void tkgl9GetUniform(Int32 programObj, Int32 location, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, @params); }
        internal override void tkgl10GetUniform(UInt32 programObj, Int32 location, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, @params); }
        internal override void tkgl11GetUniform(UInt32 programObj, Int32 location, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, out @params); }
        internal override unsafe void tkgl12GetUniform(UInt32 programObj, Int32 location, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetUniform(programObj, location, @params); }
        internal override Int32 tkglGetUniformLocation(Int32 programObj, String name) { return OpenTK.Graphics.OpenGL.GL.Arb.GetUniformLocation(programObj, name); }
        internal override Int32 tkgl2GetUniformLocation(UInt32 programObj, String name) { return OpenTK.Graphics.OpenGL.GL.Arb.GetUniformLocation(programObj, name); }
        internal override void tkglGetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl2GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl3GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl4GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl5GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl6GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl7GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl8GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl9GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl10GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl11GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl12GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl13GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl14GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl15GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl16GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl17GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl18GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameterArb pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttrib(index, pname, @params); }
        internal override void tkglGetVertexAttribPointer(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribPointerParameterArb pname, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttribPointer(index, pname, pointer); }
        internal override void tkgl2GetVertexAttribPointer(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribPointerParameterArb pname, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Arb.GetVertexAttribPointer(index, pname, pointer); }
        internal override bool tkglIsBuffer(Int32 buffer) { return OpenTK.Graphics.OpenGL.GL.Arb.IsBuffer(buffer); }
        internal override bool tkgl2IsBuffer(UInt32 buffer) { return OpenTK.Graphics.OpenGL.GL.Arb.IsBuffer(buffer); }
        internal override bool tkglIsProgram(Int32 program) { return OpenTK.Graphics.OpenGL.GL.Arb.IsProgram(program); }
        internal override bool tkgl2IsProgram(UInt32 program) { return OpenTK.Graphics.OpenGL.GL.Arb.IsProgram(program); }
        internal override bool tkglIsQuery(Int32 id) { return OpenTK.Graphics.OpenGL.GL.Arb.IsQuery(id); }
        internal override bool tkgl2IsQuery(UInt32 id) { return OpenTK.Graphics.OpenGL.GL.Arb.IsQuery(id); }
        internal override void tkglLinkProgram(Int32 programObj) { OpenTK.Graphics.OpenGL.GL.Arb.LinkProgram(programObj); }
        internal override void tkgl2LinkProgram(UInt32 programObj) { OpenTK.Graphics.OpenGL.GL.Arb.LinkProgram(programObj); }
        internal override void tkglLoadTransposeMatrix(Double[] m) { OpenTK.Graphics.OpenGL.GL.Arb.LoadTransposeMatrix(m); }
        internal override void tkgl2LoadTransposeMatrix(ref Double m) { OpenTK.Graphics.OpenGL.GL.Arb.LoadTransposeMatrix(ref m); }
        internal override unsafe void tkgl3LoadTransposeMatrix(Double* m) { OpenTK.Graphics.OpenGL.GL.Arb.LoadTransposeMatrix(m); }
        internal override void tkgl4LoadTransposeMatrix(Single[] m) { OpenTK.Graphics.OpenGL.GL.Arb.LoadTransposeMatrix(m); }
        internal override void tkgl5LoadTransposeMatrix(ref Single m) { OpenTK.Graphics.OpenGL.GL.Arb.LoadTransposeMatrix(ref m); }
        internal override unsafe void tkgl6LoadTransposeMatrix(Single* m) { OpenTK.Graphics.OpenGL.GL.Arb.LoadTransposeMatrix(m); }
        internal override unsafe System.IntPtr tkglMapBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb target, OpenTK.Graphics.OpenGL.ArbVertexBufferObject access) { return OpenTK.Graphics.OpenGL.GL.Arb.MapBuffer(target, access); }
        internal override void tkglMatrixIndexPointer(Int32 size, OpenTK.Graphics.OpenGL.ArbMatrixPalette type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndexPointer(size, type, stride, pointer); }
        internal override void tkglMatrixIndex(Int32 size, Byte[] indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl2MatrixIndex(Int32 size, ref Byte indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, ref indices); }
        internal override unsafe void tkgl3MatrixIndex(Int32 size, Byte* indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl4MatrixIndex(Int32 size, Int32[] indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl5MatrixIndex(Int32 size, ref Int32 indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, ref indices); }
        internal override unsafe void tkgl6MatrixIndex(Int32 size, Int32* indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl7MatrixIndex(Int32 size, UInt32[] indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl8MatrixIndex(Int32 size, ref UInt32 indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, ref indices); }
        internal override unsafe void tkgl9MatrixIndex(Int32 size, UInt32* indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl10MatrixIndex(Int32 size, Int16[] indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl11MatrixIndex(Int32 size, ref Int16 indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, ref indices); }
        internal override unsafe void tkgl12MatrixIndex(Int32 size, Int16* indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl13MatrixIndex(Int32 size, UInt16[] indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkgl14MatrixIndex(Int32 size, ref UInt16 indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, ref indices); }
        internal override unsafe void tkgl15MatrixIndex(Int32 size, UInt16* indices) { OpenTK.Graphics.OpenGL.GL.Arb.MatrixIndex(size, indices); }
        internal override void tkglMultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Double s) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord1(target, s); }
        internal override unsafe void tkgl2MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord1(target, v); }
        internal override void tkgl3MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Single s) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord1(target, s); }
        internal override unsafe void tkgl4MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord1(target, v); }
        internal override void tkgl5MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Int32 s) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord1(target, s); }
        internal override unsafe void tkgl6MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord1(target, v); }
        internal override void tkgl7MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Int16 s) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord1(target, s); }
        internal override unsafe void tkgl8MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord1(target, v); }
        internal override void tkglMultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Double s, Double t) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, s, t); }
        internal override void tkgl2MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, v); }
        internal override void tkgl3MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, ref v); }
        internal override unsafe void tkgl4MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, v); }
        internal override void tkgl5MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Single s, Single t) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, s, t); }
        internal override void tkgl6MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, v); }
        internal override void tkgl7MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, ref v); }
        internal override unsafe void tkgl8MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, v); }
        internal override void tkgl9MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int32 s, Int32 t) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, s, t); }
        internal override void tkgl10MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, v); }
        internal override void tkgl11MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, ref v); }
        internal override unsafe void tkgl12MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, v); }
        internal override void tkgl13MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int16 s, Int16 t) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, s, t); }
        internal override void tkgl14MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, v); }
        internal override void tkgl15MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, ref v); }
        internal override unsafe void tkgl16MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord2(target, v); }
        internal override void tkglMultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Double s, Double t, Double r) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, s, t, r); }
        internal override void tkgl2MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, v); }
        internal override void tkgl3MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, ref v); }
        internal override unsafe void tkgl4MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, v); }
        internal override void tkgl5MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Single s, Single t, Single r) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, s, t, r); }
        internal override void tkgl6MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, v); }
        internal override void tkgl7MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, ref v); }
        internal override unsafe void tkgl8MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, v); }
        internal override void tkgl9MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int32 s, Int32 t, Int32 r) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, s, t, r); }
        internal override void tkgl10MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, v); }
        internal override void tkgl11MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, ref v); }
        internal override unsafe void tkgl12MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, v); }
        internal override void tkgl13MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int16 s, Int16 t, Int16 r) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, s, t, r); }
        internal override void tkgl14MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, v); }
        internal override void tkgl15MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, ref v); }
        internal override unsafe void tkgl16MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord3(target, v); }
        internal override void tkglMultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Double s, Double t, Double r, Double q) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, s, t, r, q); }
        internal override void tkgl2MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, v); }
        internal override void tkgl3MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, ref v); }
        internal override unsafe void tkgl4MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, v); }
        internal override void tkgl5MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Single s, Single t, Single r, Single q) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, s, t, r, q); }
        internal override void tkgl6MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, v); }
        internal override void tkgl7MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, ref v); }
        internal override unsafe void tkgl8MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, v); }
        internal override void tkgl9MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int32 s, Int32 t, Int32 r, Int32 q) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, s, t, r, q); }
        internal override void tkgl10MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, v); }
        internal override void tkgl11MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, ref v); }
        internal override unsafe void tkgl12MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, v); }
        internal override void tkgl13MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int16 s, Int16 t, Int16 r, Int16 q) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, s, t, r, q); }
        internal override void tkgl14MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, v); }
        internal override void tkgl15MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, ref v); }
        internal override unsafe void tkgl16MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.MultiTexCoord4(target, v); }
        internal override void tkglMultTransposeMatrix(Double[] m) { OpenTK.Graphics.OpenGL.GL.Arb.MultTransposeMatrix(m); }
        internal override void tkgl2MultTransposeMatrix(ref Double m) { OpenTK.Graphics.OpenGL.GL.Arb.MultTransposeMatrix(ref m); }
        internal override unsafe void tkgl3MultTransposeMatrix(Double* m) { OpenTK.Graphics.OpenGL.GL.Arb.MultTransposeMatrix(m); }
        internal override void tkgl4MultTransposeMatrix(Single[] m) { OpenTK.Graphics.OpenGL.GL.Arb.MultTransposeMatrix(m); }
        internal override void tkgl5MultTransposeMatrix(ref Single m) { OpenTK.Graphics.OpenGL.GL.Arb.MultTransposeMatrix(ref m); }
        internal override unsafe void tkgl6MultTransposeMatrix(Single* m) { OpenTK.Graphics.OpenGL.GL.Arb.MultTransposeMatrix(m); }
        internal override void tkglPointParameter(OpenTK.Graphics.OpenGL.ArbPointParameters pname, Single param) { OpenTK.Graphics.OpenGL.GL.Arb.PointParameter(pname, param); }
        internal override void tkgl2PointParameter(OpenTK.Graphics.OpenGL.ArbPointParameters pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.PointParameter(pname, @params); }
        internal override unsafe void tkgl3PointParameter(OpenTK.Graphics.OpenGL.ArbPointParameters pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.PointParameter(pname, @params); }
        internal override void tkglProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, x, y, z, w); }
        internal override void tkgl2ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, x, y, z, w); }
        internal override void tkgl3ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, @params); }
        internal override void tkgl4ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, ref Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, ref @params); }
        internal override unsafe void tkgl5ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, @params); }
        internal override void tkgl6ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, @params); }
        internal override void tkgl7ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, ref Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, ref @params); }
        internal override unsafe void tkgl8ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, @params); }
        internal override void tkgl9ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, x, y, z, w); }
        internal override void tkgl10ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, x, y, z, w); }
        internal override void tkgl11ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, @params); }
        internal override void tkgl12ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, ref @params); }
        internal override unsafe void tkgl13ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, @params); }
        internal override void tkgl14ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, @params); }
        internal override void tkgl15ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, ref @params); }
        internal override unsafe void tkgl16ProgramEnvParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramEnvParameter4(target, index, @params); }
        internal override void tkglProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, x, y, z, w); }
        internal override void tkgl2ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, x, y, z, w); }
        internal override void tkgl3ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, @params); }
        internal override void tkgl4ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, ref Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, ref @params); }
        internal override unsafe void tkgl5ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, @params); }
        internal override void tkgl6ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, @params); }
        internal override void tkgl7ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, ref Double @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, ref @params); }
        internal override unsafe void tkgl8ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, @params); }
        internal override void tkgl9ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, x, y, z, w); }
        internal override void tkgl10ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, x, y, z, w); }
        internal override void tkgl11ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, @params); }
        internal override void tkgl12ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, ref @params); }
        internal override unsafe void tkgl13ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, @params); }
        internal override void tkgl14ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, @params); }
        internal override void tkgl15ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, ref @params); }
        internal override unsafe void tkgl16ProgramLocalParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramLocalParameter4(target, index, @params); }
        internal override void tkglProgramParameter(Int32 program, OpenTK.Graphics.OpenGL.ArbGeometryShader4 pname, Int32 value) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramParameter(program, pname, value); }
        internal override void tkgl2ProgramParameter(UInt32 program, OpenTK.Graphics.OpenGL.ArbGeometryShader4 pname, Int32 value) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramParameter(program, pname, value); }
        internal override void tkglProgramString(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, OpenTK.Graphics.OpenGL.ArbVertexProgram format, Int32 len, IntPtr @string) { OpenTK.Graphics.OpenGL.GL.Arb.ProgramString(target, format, len, @string); }
        internal override void tkglSampleCoverage(Single value, bool invert) { OpenTK.Graphics.OpenGL.GL.Arb.SampleCoverage(value, invert); }
        internal override void tkglShaderSource(Int32 shaderObj, Int32 count, String[] @string, ref Int32 length) { OpenTK.Graphics.OpenGL.GL.Arb.ShaderSource(shaderObj, count, @string, ref length); }
        internal override unsafe void tkgl2ShaderSource(Int32 shaderObj, Int32 count, String[] @string, Int32* length) { OpenTK.Graphics.OpenGL.GL.Arb.ShaderSource(shaderObj, count, @string, length); }
        internal override void tkgl3ShaderSource(UInt32 shaderObj, Int32 count, String[] @string, ref Int32 length) { OpenTK.Graphics.OpenGL.GL.Arb.ShaderSource(shaderObj, count, @string, ref length); }
        internal override unsafe void tkgl4ShaderSource(UInt32 shaderObj, Int32 count, String[] @string, Int32* length) { OpenTK.Graphics.OpenGL.GL.Arb.ShaderSource(shaderObj, count, @string, length); }
        internal override void tkglTexBuffer(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.ArbTextureBufferObject internalformat, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Arb.TexBuffer(target, internalformat, buffer); }
        internal override void tkgl2TexBuffer(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.ArbTextureBufferObject internalformat, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Arb.TexBuffer(target, internalformat, buffer); }
        internal override void tkglUniform1(Int32 location, Single v0) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform1(location, v0); }
        internal override void tkgl2Uniform1(Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform1(location, count, value); }
        internal override void tkgl3Uniform1(Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform1(location, count, ref value); }
        internal override unsafe void tkgl4Uniform1(Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform1(location, count, value); }
        internal override void tkgl5Uniform1(Int32 location, Int32 v0) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform1(location, v0); }
        internal override void tkgl6Uniform1(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform1(location, count, value); }
        internal override void tkgl7Uniform1(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform1(location, count, ref value); }
        internal override unsafe void tkgl8Uniform1(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform1(location, count, value); }
        internal override void tkglUniform2(Int32 location, Single v0, Single v1) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform2(location, v0, v1); }
        internal override void tkgl2Uniform2(Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform2(location, count, value); }
        internal override void tkgl3Uniform2(Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform2(location, count, ref value); }
        internal override unsafe void tkgl4Uniform2(Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform2(location, count, value); }
        internal override void tkgl5Uniform2(Int32 location, Int32 v0, Int32 v1) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform2(location, v0, v1); }
        internal override void tkgl6Uniform2(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform2(location, count, value); }
        internal override unsafe void tkgl7Uniform2(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform2(location, count, value); }
        internal override void tkglUniform3(Int32 location, Single v0, Single v1, Single v2) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform3(location, v0, v1, v2); }
        internal override void tkgl2Uniform3(Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform3(location, count, value); }
        internal override void tkgl3Uniform3(Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform3(location, count, ref value); }
        internal override unsafe void tkgl4Uniform3(Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform3(location, count, value); }
        internal override void tkgl5Uniform3(Int32 location, Int32 v0, Int32 v1, Int32 v2) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform3(location, v0, v1, v2); }
        internal override void tkgl6Uniform3(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform3(location, count, value); }
        internal override void tkgl7Uniform3(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform3(location, count, ref value); }
        internal override unsafe void tkgl8Uniform3(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform3(location, count, value); }
        internal override void tkglUniform4(Int32 location, Single v0, Single v1, Single v2, Single v3) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform4(location, v0, v1, v2, v3); }
        internal override void tkgl2Uniform4(Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform4(location, count, value); }
        internal override void tkgl3Uniform4(Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform4(location, count, ref value); }
        internal override unsafe void tkgl4Uniform4(Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform4(location, count, value); }
        internal override void tkgl5Uniform4(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform4(location, v0, v1, v2, v3); }
        internal override void tkgl6Uniform4(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform4(location, count, value); }
        internal override void tkgl7Uniform4(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform4(location, count, ref value); }
        internal override unsafe void tkgl8Uniform4(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Arb.Uniform4(location, count, value); }
        internal override void tkglUniformMatrix2(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix2(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix2(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix2(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix2(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix2(location, count, transpose, value); }
        internal override void tkglUniformMatrix3(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix3(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix3(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix3(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix3(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix3(location, count, transpose, value); }
        internal override void tkglUniformMatrix4(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix4(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix4(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix4(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix4(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Arb.UniformMatrix4(location, count, transpose, value); }
        internal override bool tkglUnmapBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb target) { return OpenTK.Graphics.OpenGL.GL.Arb.UnmapBuffer(target); }
        internal override void tkglUseProgramObject(Int32 programObj) { OpenTK.Graphics.OpenGL.GL.Arb.UseProgramObject(programObj); }
        internal override void tkgl2UseProgramObject(UInt32 programObj) { OpenTK.Graphics.OpenGL.GL.Arb.UseProgramObject(programObj); }
        internal override void tkglValidateProgram(Int32 programObj) { OpenTK.Graphics.OpenGL.GL.Arb.ValidateProgram(programObj); }
        internal override void tkgl2ValidateProgram(UInt32 programObj) { OpenTK.Graphics.OpenGL.GL.Arb.ValidateProgram(programObj); }
        internal override void tkglVertexAttrib1(Int32 index, Double x) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, x); }
        internal override void tkgl2VertexAttrib1(UInt32 index, Double x) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, x); }
        internal override unsafe void tkgl3VertexAttrib1(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, v); }
        internal override unsafe void tkgl4VertexAttrib1(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, v); }
        internal override void tkgl5VertexAttrib1(Int32 index, Single x) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, x); }
        internal override void tkgl6VertexAttrib1(UInt32 index, Single x) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, x); }
        internal override unsafe void tkgl7VertexAttrib1(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, v); }
        internal override unsafe void tkgl8VertexAttrib1(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, v); }
        internal override void tkgl9VertexAttrib1(Int32 index, Int16 x) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, x); }
        internal override void tkgl10VertexAttrib1(UInt32 index, Int16 x) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, x); }
        internal override unsafe void tkgl11VertexAttrib1(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, v); }
        internal override unsafe void tkgl12VertexAttrib1(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib1(index, v); }
        internal override void tkglVertexAttrib2(Int32 index, Double x, Double y) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, x, y); }
        internal override void tkgl2VertexAttrib2(UInt32 index, Double x, Double y) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, x, y); }
        internal override void tkgl3VertexAttrib2(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl4VertexAttrib2(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl5VertexAttrib2(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl6VertexAttrib2(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl7VertexAttrib2(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl8VertexAttrib2(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl9VertexAttrib2(Int32 index, Single x, Single y) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, x, y); }
        internal override void tkgl10VertexAttrib2(UInt32 index, Single x, Single y) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, x, y); }
        internal override void tkgl11VertexAttrib2(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl12VertexAttrib2(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl13VertexAttrib2(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl14VertexAttrib2(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl15VertexAttrib2(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl16VertexAttrib2(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl17VertexAttrib2(Int32 index, Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, x, y); }
        internal override void tkgl18VertexAttrib2(UInt32 index, Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, x, y); }
        internal override void tkgl19VertexAttrib2(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl20VertexAttrib2(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl21VertexAttrib2(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl22VertexAttrib2(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkgl23VertexAttrib2(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl24VertexAttrib2(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib2(index, v); }
        internal override void tkglVertexAttrib3(Int32 index, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, x, y, z); }
        internal override void tkgl2VertexAttrib3(UInt32 index, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, x, y, z); }
        internal override void tkgl3VertexAttrib3(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl4VertexAttrib3(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl5VertexAttrib3(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl6VertexAttrib3(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl7VertexAttrib3(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl8VertexAttrib3(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl9VertexAttrib3(Int32 index, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, x, y, z); }
        internal override void tkgl10VertexAttrib3(UInt32 index, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, x, y, z); }
        internal override void tkgl11VertexAttrib3(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl12VertexAttrib3(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl13VertexAttrib3(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl14VertexAttrib3(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl15VertexAttrib3(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl16VertexAttrib3(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl17VertexAttrib3(Int32 index, Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, x, y, z); }
        internal override void tkgl18VertexAttrib3(UInt32 index, Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, x, y, z); }
        internal override void tkgl19VertexAttrib3(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl20VertexAttrib3(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl21VertexAttrib3(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl22VertexAttrib3(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkgl23VertexAttrib3(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl24VertexAttrib3(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib3(index, v); }
        internal override void tkglVertexAttrib4(UInt32 index, SByte[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl2VertexAttrib4(UInt32 index, ref SByte v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl3VertexAttrib4(UInt32 index, SByte* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl4VertexAttrib4(Int32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl5VertexAttrib4(UInt32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl6VertexAttrib4(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl7VertexAttrib4(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl8VertexAttrib4(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl9VertexAttrib4(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl10VertexAttrib4(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl11VertexAttrib4(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl12VertexAttrib4(Int32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl13VertexAttrib4(UInt32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl14VertexAttrib4(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl15VertexAttrib4(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl16VertexAttrib4(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl17VertexAttrib4(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl18VertexAttrib4(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl19VertexAttrib4(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl20VertexAttrib4(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl21VertexAttrib4(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl22VertexAttrib4(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl23VertexAttrib4(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl24VertexAttrib4(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl25VertexAttrib4(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkglVertexAttrib4N(UInt32 index, SByte[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl2VertexAttrib4N(UInt32 index, ref SByte v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl3VertexAttrib4N(UInt32 index, SByte* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl4VertexAttrib4N(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl5VertexAttrib4N(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl6VertexAttrib4N(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl7VertexAttrib4N(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl8VertexAttrib4N(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl9VertexAttrib4N(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl10VertexAttrib4N(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl11VertexAttrib4N(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl12VertexAttrib4N(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl13VertexAttrib4N(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl14VertexAttrib4N(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl15VertexAttrib4N(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl16VertexAttrib4N(Int32 index, Byte x, Byte y, Byte z, Byte w) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, x, y, z, w); }
        internal override void tkgl17VertexAttrib4N(UInt32 index, Byte x, Byte y, Byte z, Byte w) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, x, y, z, w); }
        internal override void tkgl18VertexAttrib4N(Int32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl19VertexAttrib4N(Int32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl20VertexAttrib4N(Int32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl21VertexAttrib4N(UInt32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl22VertexAttrib4N(UInt32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl23VertexAttrib4N(UInt32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl24VertexAttrib4N(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl25VertexAttrib4N(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl26VertexAttrib4N(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl27VertexAttrib4N(UInt32 index, UInt16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl28VertexAttrib4N(UInt32 index, ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl29VertexAttrib4N(UInt32 index, UInt16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4N(index, v); }
        internal override void tkgl26VertexAttrib4(Int32 index, Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl27VertexAttrib4(UInt32 index, Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl28VertexAttrib4(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl29VertexAttrib4(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl30VertexAttrib4(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl31VertexAttrib4(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl32VertexAttrib4(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl33VertexAttrib4(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl34VertexAttrib4(Int32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl35VertexAttrib4(Int32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl36VertexAttrib4(Int32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl37VertexAttrib4(UInt32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl38VertexAttrib4(UInt32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl39VertexAttrib4(UInt32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl40VertexAttrib4(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl41VertexAttrib4(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl42VertexAttrib4(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl43VertexAttrib4(UInt32 index, UInt16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkgl44VertexAttrib4(UInt32 index, ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl45VertexAttrib4(UInt32 index, UInt16* v) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttrib4(index, v); }
        internal override void tkglVertexAttribDivisor(Int32 index, Int32 divisor) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttribDivisor(index, divisor); }
        internal override void tkgl2VertexAttribDivisor(UInt32 index, UInt32 divisor) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttribDivisor(index, divisor); }
        internal override void tkglVertexAttribPointer(Int32 index, Int32 size, OpenTK.Graphics.OpenGL.VertexAttribPointerTypeArb type, bool normalized, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttribPointer(index, size, type, normalized, stride, pointer); }
        internal override void tkgl2VertexAttribPointer(UInt32 index, Int32 size, OpenTK.Graphics.OpenGL.VertexAttribPointerTypeArb type, bool normalized, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Arb.VertexAttribPointer(index, size, type, normalized, stride, pointer); }
        internal override void tkglVertexBlend(Int32 count) { OpenTK.Graphics.OpenGL.GL.Arb.VertexBlend(count); }
        internal override void tkglWeight(Int32 size, SByte[] weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl2Weight(Int32 size, ref SByte weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, ref weights); }
        internal override unsafe void tkgl3Weight(Int32 size, SByte* weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl4Weight(Int32 size, Double[] weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl5Weight(Int32 size, ref Double weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, ref weights); }
        internal override unsafe void tkgl6Weight(Int32 size, Double* weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl7Weight(Int32 size, Single[] weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl8Weight(Int32 size, ref Single weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, ref weights); }
        internal override unsafe void tkgl9Weight(Int32 size, Single* weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl10Weight(Int32 size, Int32[] weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl11Weight(Int32 size, ref Int32 weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, ref weights); }
        internal override unsafe void tkgl12Weight(Int32 size, Int32* weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkglWeightPointer(Int32 size, OpenTK.Graphics.OpenGL.ArbVertexBlend type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Arb.WeightPointer(size, type, stride, pointer); }
        internal override void tkgl13Weight(Int32 size, Int16[] weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl14Weight(Int32 size, ref Int16 weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, ref weights); }
        internal override unsafe void tkgl15Weight(Int32 size, Int16* weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl16Weight(Int32 size, Byte[] weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl17Weight(Int32 size, ref Byte weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, ref weights); }
        internal override unsafe void tkgl18Weight(Int32 size, Byte* weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl19Weight(Int32 size, UInt32[] weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl20Weight(Int32 size, ref UInt32 weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, ref weights); }
        internal override unsafe void tkgl21Weight(Int32 size, UInt32* weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl22Weight(Int32 size, UInt16[] weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkgl23Weight(Int32 size, ref UInt16 weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, ref weights); }
        internal override unsafe void tkgl24Weight(Int32 size, UInt16* weights) { OpenTK.Graphics.OpenGL.GL.Arb.Weight(size, weights); }
        internal override void tkglWindowPos2(Double x, Double y) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(x, y); }
        internal override void tkgl2WindowPos2(Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(v); }
        internal override void tkgl3WindowPos2(ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(ref v); }
        internal override unsafe void tkgl4WindowPos2(Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(v); }
        internal override void tkgl5WindowPos2(Single x, Single y) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(x, y); }
        internal override void tkgl6WindowPos2(Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(v); }
        internal override void tkgl7WindowPos2(ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(ref v); }
        internal override unsafe void tkgl8WindowPos2(Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(v); }
        internal override void tkgl9WindowPos2(Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(x, y); }
        internal override void tkgl10WindowPos2(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(v); }
        internal override void tkgl11WindowPos2(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(ref v); }
        internal override unsafe void tkgl12WindowPos2(Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(v); }
        internal override void tkgl13WindowPos2(Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(x, y); }
        internal override void tkgl14WindowPos2(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(v); }
        internal override void tkgl15WindowPos2(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(ref v); }
        internal override unsafe void tkgl16WindowPos2(Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos2(v); }
        internal override void tkglWindowPos3(Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(x, y, z); }
        internal override void tkgl2WindowPos3(Double[] v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(v); }
        internal override void tkgl3WindowPos3(ref Double v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(ref v); }
        internal override unsafe void tkgl4WindowPos3(Double* v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(v); }
        internal override void tkgl5WindowPos3(Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(x, y, z); }
        internal override void tkgl6WindowPos3(Single[] v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(v); }
        internal override void tkgl7WindowPos3(ref Single v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(ref v); }
        internal override unsafe void tkgl8WindowPos3(Single* v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(v); }
        internal override void tkgl9WindowPos3(Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(x, y, z); }
        internal override void tkgl10WindowPos3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(v); }
        internal override void tkgl11WindowPos3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(ref v); }
        internal override unsafe void tkgl12WindowPos3(Int32* v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(v); }
        internal override void tkgl13WindowPos3(Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(x, y, z); }
        internal override void tkgl14WindowPos3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(v); }
        internal override void tkgl15WindowPos3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(ref v); }
        internal override unsafe void tkgl16WindowPos3(Int16* v) { OpenTK.Graphics.OpenGL.GL.Arb.WindowPos3(v); }
        internal override void tkglAlphaFragmentOp1(OpenTK.Graphics.OpenGL.AtiFragmentShader op, Int32 dst, Int32 dstMod, Int32 arg1, Int32 arg1Rep, Int32 arg1Mod) { OpenTK.Graphics.OpenGL.GL.Ati.AlphaFragmentOp1(op, dst, dstMod, arg1, arg1Rep, arg1Mod); }
        internal override void tkgl2AlphaFragmentOp1(OpenTK.Graphics.OpenGL.AtiFragmentShader op, UInt32 dst, UInt32 dstMod, UInt32 arg1, UInt32 arg1Rep, UInt32 arg1Mod) { OpenTK.Graphics.OpenGL.GL.Ati.AlphaFragmentOp1(op, dst, dstMod, arg1, arg1Rep, arg1Mod); }
        internal override void tkglAlphaFragmentOp2(OpenTK.Graphics.OpenGL.AtiFragmentShader op, Int32 dst, Int32 dstMod, Int32 arg1, Int32 arg1Rep, Int32 arg1Mod, Int32 arg2, Int32 arg2Rep, Int32 arg2Mod) { OpenTK.Graphics.OpenGL.GL.Ati.AlphaFragmentOp2(op, dst, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod); }
        internal override void tkgl2AlphaFragmentOp2(OpenTK.Graphics.OpenGL.AtiFragmentShader op, UInt32 dst, UInt32 dstMod, UInt32 arg1, UInt32 arg1Rep, UInt32 arg1Mod, UInt32 arg2, UInt32 arg2Rep, UInt32 arg2Mod) { OpenTK.Graphics.OpenGL.GL.Ati.AlphaFragmentOp2(op, dst, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod); }
        internal override void tkglAlphaFragmentOp3(OpenTK.Graphics.OpenGL.AtiFragmentShader op, Int32 dst, Int32 dstMod, Int32 arg1, Int32 arg1Rep, Int32 arg1Mod, Int32 arg2, Int32 arg2Rep, Int32 arg2Mod, Int32 arg3, Int32 arg3Rep, Int32 arg3Mod) { OpenTK.Graphics.OpenGL.GL.Ati.AlphaFragmentOp3(op, dst, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod, arg3, arg3Rep, arg3Mod); }
        internal override void tkgl2AlphaFragmentOp3(OpenTK.Graphics.OpenGL.AtiFragmentShader op, UInt32 dst, UInt32 dstMod, UInt32 arg1, UInt32 arg1Rep, UInt32 arg1Mod, UInt32 arg2, UInt32 arg2Rep, UInt32 arg2Mod, UInt32 arg3, UInt32 arg3Rep, UInt32 arg3Mod) { OpenTK.Graphics.OpenGL.GL.Ati.AlphaFragmentOp3(op, dst, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod, arg3, arg3Rep, arg3Mod); }
        internal override void tkglArrayObject(OpenTK.Graphics.OpenGL.EnableCap array, Int32 size, OpenTK.Graphics.OpenGL.AtiVertexArrayObject type, Int32 stride, Int32 buffer, Int32 offset) { OpenTK.Graphics.OpenGL.GL.Ati.ArrayObject(array, size, type, stride, buffer, offset); }
        internal override void tkgl2ArrayObject(OpenTK.Graphics.OpenGL.EnableCap array, Int32 size, OpenTK.Graphics.OpenGL.AtiVertexArrayObject type, Int32 stride, UInt32 buffer, UInt32 offset) { OpenTK.Graphics.OpenGL.GL.Ati.ArrayObject(array, size, type, stride, buffer, offset); }
        internal override void tkglBeginFragmentShader() { OpenTK.Graphics.OpenGL.GL.Ati.BeginFragmentShader(); }
        internal override void tkglBindFragmentShader(Int32 id) { OpenTK.Graphics.OpenGL.GL.Ati.BindFragmentShader(id); }
        internal override void tkgl2BindFragmentShader(UInt32 id) { OpenTK.Graphics.OpenGL.GL.Ati.BindFragmentShader(id); }
        internal override void tkglClientActiveVertexStream(OpenTK.Graphics.OpenGL.AtiVertexStreams stream) { OpenTK.Graphics.OpenGL.GL.Ati.ClientActiveVertexStream(stream); }
        internal override void tkglColorFragmentOp1(OpenTK.Graphics.OpenGL.AtiFragmentShader op, Int32 dst, Int32 dstMask, Int32 dstMod, Int32 arg1, Int32 arg1Rep, Int32 arg1Mod) { OpenTK.Graphics.OpenGL.GL.Ati.ColorFragmentOp1(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod); }
        internal override void tkgl2ColorFragmentOp1(OpenTK.Graphics.OpenGL.AtiFragmentShader op, UInt32 dst, UInt32 dstMask, UInt32 dstMod, UInt32 arg1, UInt32 arg1Rep, UInt32 arg1Mod) { OpenTK.Graphics.OpenGL.GL.Ati.ColorFragmentOp1(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod); }
        internal override void tkglColorFragmentOp2(OpenTK.Graphics.OpenGL.AtiFragmentShader op, Int32 dst, Int32 dstMask, Int32 dstMod, Int32 arg1, Int32 arg1Rep, Int32 arg1Mod, Int32 arg2, Int32 arg2Rep, Int32 arg2Mod) { OpenTK.Graphics.OpenGL.GL.Ati.ColorFragmentOp2(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod); }
        internal override void tkgl2ColorFragmentOp2(OpenTK.Graphics.OpenGL.AtiFragmentShader op, UInt32 dst, UInt32 dstMask, UInt32 dstMod, UInt32 arg1, UInt32 arg1Rep, UInt32 arg1Mod, UInt32 arg2, UInt32 arg2Rep, UInt32 arg2Mod) { OpenTK.Graphics.OpenGL.GL.Ati.ColorFragmentOp2(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod); }
        internal override void tkglColorFragmentOp3(OpenTK.Graphics.OpenGL.AtiFragmentShader op, Int32 dst, Int32 dstMask, Int32 dstMod, Int32 arg1, Int32 arg1Rep, Int32 arg1Mod, Int32 arg2, Int32 arg2Rep, Int32 arg2Mod, Int32 arg3, Int32 arg3Rep, Int32 arg3Mod) { OpenTK.Graphics.OpenGL.GL.Ati.ColorFragmentOp3(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod, arg3, arg3Rep, arg3Mod); }
        internal override void tkgl2ColorFragmentOp3(OpenTK.Graphics.OpenGL.AtiFragmentShader op, UInt32 dst, UInt32 dstMask, UInt32 dstMod, UInt32 arg1, UInt32 arg1Rep, UInt32 arg1Mod, UInt32 arg2, UInt32 arg2Rep, UInt32 arg2Mod, UInt32 arg3, UInt32 arg3Rep, UInt32 arg3Mod) { OpenTK.Graphics.OpenGL.GL.Ati.ColorFragmentOp3(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod, arg3, arg3Rep, arg3Mod); }
        internal override void tkglDeleteFragmentShader(Int32 id) { OpenTK.Graphics.OpenGL.GL.Ati.DeleteFragmentShader(id); }
        internal override void tkgl2DeleteFragmentShader(UInt32 id) { OpenTK.Graphics.OpenGL.GL.Ati.DeleteFragmentShader(id); }
        internal override void tkgl4DrawBuffers(Int32 n, OpenTK.Graphics.OpenGL.AtiDrawBuffers[] bufs) { OpenTK.Graphics.OpenGL.GL.Ati.DrawBuffers(n, bufs); }
        internal override void tkgl5DrawBuffers(Int32 n, ref OpenTK.Graphics.OpenGL.AtiDrawBuffers bufs) { OpenTK.Graphics.OpenGL.GL.Ati.DrawBuffers(n, ref bufs); }
        internal override unsafe void tkgl6DrawBuffers(Int32 n, OpenTK.Graphics.OpenGL.AtiDrawBuffers* bufs) { OpenTK.Graphics.OpenGL.GL.Ati.DrawBuffers(n, bufs); }
        internal override void tkgl2DrawElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 count) { OpenTK.Graphics.OpenGL.GL.Ati.DrawElementArray(mode, count); }
        internal override void tkgl3DrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 end, Int32 count) { OpenTK.Graphics.OpenGL.GL.Ati.DrawRangeElementArray(mode, start, end, count); }
        internal override void tkgl4DrawRangeElementArray(OpenTK.Graphics.OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count) { OpenTK.Graphics.OpenGL.GL.Ati.DrawRangeElementArray(mode, start, end, count); }
        internal override void tkgl2ElementPointer(OpenTK.Graphics.OpenGL.AtiElementArray type, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ati.ElementPointer(type, pointer); }
        internal override void tkglEndFragmentShader() { OpenTK.Graphics.OpenGL.GL.Ati.EndFragmentShader(); }
        internal override void tkglFreeObjectBuffer(Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Ati.FreeObjectBuffer(buffer); }
        internal override void tkgl2FreeObjectBuffer(UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Ati.FreeObjectBuffer(buffer); }
        internal override Int32 tkglGenFragmentShaders(Int32 range) { return OpenTK.Graphics.OpenGL.GL.Ati.GenFragmentShaders(range); }
        internal override Int32 tkgl2GenFragmentShaders(UInt32 range) { return OpenTK.Graphics.OpenGL.GL.Ati.GenFragmentShaders(range); }
        internal override void tkglGetArrayObject(OpenTK.Graphics.OpenGL.EnableCap array, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetArrayObject(array, pname, out @params); }
        internal override unsafe void tkgl2GetArrayObject(OpenTK.Graphics.OpenGL.EnableCap array, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetArrayObject(array, pname, @params); }
        internal override void tkgl3GetArrayObject(OpenTK.Graphics.OpenGL.EnableCap array, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetArrayObject(array, pname, out @params); }
        internal override unsafe void tkgl4GetArrayObject(OpenTK.Graphics.OpenGL.EnableCap array, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetArrayObject(array, pname, @params); }
        internal override void tkglGetObjectBuffer(Int32 buffer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetObjectBuffer(buffer, pname, out @params); }
        internal override unsafe void tkgl2GetObjectBuffer(Int32 buffer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetObjectBuffer(buffer, pname, @params); }
        internal override void tkgl3GetObjectBuffer(UInt32 buffer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetObjectBuffer(buffer, pname, out @params); }
        internal override unsafe void tkgl4GetObjectBuffer(UInt32 buffer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetObjectBuffer(buffer, pname, @params); }
        internal override void tkgl5GetObjectBuffer(Int32 buffer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetObjectBuffer(buffer, pname, out @params); }
        internal override unsafe void tkgl6GetObjectBuffer(Int32 buffer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetObjectBuffer(buffer, pname, @params); }
        internal override void tkgl7GetObjectBuffer(UInt32 buffer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetObjectBuffer(buffer, pname, out @params); }
        internal override unsafe void tkgl8GetObjectBuffer(UInt32 buffer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetObjectBuffer(buffer, pname, @params); }
        internal override void tkglGetTexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, Single[] param) { OpenTK.Graphics.OpenGL.GL.Ati.GetTexBumpParameter(pname, param); }
        internal override void tkgl2GetTexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, out Single param) { OpenTK.Graphics.OpenGL.GL.Ati.GetTexBumpParameter(pname, out param); }
        internal override unsafe void tkgl3GetTexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, Single* param) { OpenTK.Graphics.OpenGL.GL.Ati.GetTexBumpParameter(pname, param); }
        internal override void tkgl4GetTexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, Int32[] param) { OpenTK.Graphics.OpenGL.GL.Ati.GetTexBumpParameter(pname, param); }
        internal override void tkgl5GetTexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, out Int32 param) { OpenTK.Graphics.OpenGL.GL.Ati.GetTexBumpParameter(pname, out param); }
        internal override unsafe void tkgl6GetTexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, Int32* param) { OpenTK.Graphics.OpenGL.GL.Ati.GetTexBumpParameter(pname, param); }
        internal override void tkglGetVariantArrayObject(Int32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVariantArrayObject(id, pname, out @params); }
        internal override unsafe void tkgl2GetVariantArrayObject(Int32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVariantArrayObject(id, pname, @params); }
        internal override void tkgl3GetVariantArrayObject(UInt32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVariantArrayObject(id, pname, out @params); }
        internal override unsafe void tkgl4GetVariantArrayObject(UInt32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVariantArrayObject(id, pname, @params); }
        internal override void tkgl5GetVariantArrayObject(Int32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVariantArrayObject(id, pname, out @params); }
        internal override unsafe void tkgl6GetVariantArrayObject(Int32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVariantArrayObject(id, pname, @params); }
        internal override void tkgl7GetVariantArrayObject(UInt32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVariantArrayObject(id, pname, out @params); }
        internal override unsafe void tkgl8GetVariantArrayObject(UInt32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVariantArrayObject(id, pname, @params); }
        internal override void tkglGetVertexAttribArrayObject(Int32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, @params); }
        internal override void tkgl2GetVertexAttribArrayObject(Int32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, out @params); }
        internal override unsafe void tkgl3GetVertexAttribArrayObject(Int32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, @params); }
        internal override void tkgl4GetVertexAttribArrayObject(UInt32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, @params); }
        internal override void tkgl5GetVertexAttribArrayObject(UInt32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, out @params); }
        internal override unsafe void tkgl6GetVertexAttribArrayObject(UInt32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, @params); }
        internal override void tkgl7GetVertexAttribArrayObject(Int32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, @params); }
        internal override void tkgl8GetVertexAttribArrayObject(Int32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, out @params); }
        internal override unsafe void tkgl9GetVertexAttribArrayObject(Int32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, @params); }
        internal override void tkgl10GetVertexAttribArrayObject(UInt32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, @params); }
        internal override void tkgl11GetVertexAttribArrayObject(UInt32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, out @params); }
        internal override unsafe void tkgl12GetVertexAttribArrayObject(UInt32 index, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ati.GetVertexAttribArrayObject(index, pname, @params); }
        internal override bool tkglIsObjectBuffer(Int32 buffer) { return OpenTK.Graphics.OpenGL.GL.Ati.IsObjectBuffer(buffer); }
        internal override bool tkgl2IsObjectBuffer(UInt32 buffer) { return OpenTK.Graphics.OpenGL.GL.Ati.IsObjectBuffer(buffer); }
        internal override unsafe System.IntPtr tkglMapObjectBuffer(Int32 buffer) { return OpenTK.Graphics.OpenGL.GL.Ati.MapObjectBuffer(buffer); }
        internal override unsafe System.IntPtr tkgl2MapObjectBuffer(UInt32 buffer) { return OpenTK.Graphics.OpenGL.GL.Ati.MapObjectBuffer(buffer); }
        internal override Int32 tkglNewObjectBuffer(Int32 size, IntPtr pointer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject usage) { return OpenTK.Graphics.OpenGL.GL.Ati.NewObjectBuffer(size, pointer, usage); }
        internal override void tkglNormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Byte nx, Byte ny, Byte nz) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, nx, ny, nz); }
        internal override void tkgl2NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, SByte nx, SByte ny, SByte nz) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, nx, ny, nz); }
        internal override void tkgl3NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Byte[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl4NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Byte coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, ref coords); }
        internal override unsafe void tkgl5NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Byte* coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl6NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, SByte[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl7NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref SByte coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, ref coords); }
        internal override unsafe void tkgl8NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, SByte* coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl9NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double nx, Double ny, Double nz) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, nx, ny, nz); }
        internal override void tkgl10NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl11NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Double coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, ref coords); }
        internal override unsafe void tkgl12NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double* coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl13NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single nx, Single ny, Single nz) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, nx, ny, nz); }
        internal override void tkgl14NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl15NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Single coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, ref coords); }
        internal override unsafe void tkgl16NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single* coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl17NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32 nx, Int32 ny, Int32 nz) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, nx, ny, nz); }
        internal override void tkgl18NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl19NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Int32 coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, ref coords); }
        internal override unsafe void tkgl20NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32* coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl21NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16 nx, Int16 ny, Int16 nz) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, nx, ny, nz); }
        internal override void tkgl22NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkgl23NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Int16 coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, ref coords); }
        internal override unsafe void tkgl24NormalStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16* coords) { OpenTK.Graphics.OpenGL.GL.Ati.NormalStream3(stream, coords); }
        internal override void tkglPassTexCoor(Int32 dst, Int32 coord, OpenTK.Graphics.OpenGL.AtiFragmentShader swizzle) { OpenTK.Graphics.OpenGL.GL.Ati.PassTexCoor(dst, coord, swizzle); }
        internal override void tkgl2PassTexCoor(UInt32 dst, UInt32 coord, OpenTK.Graphics.OpenGL.AtiFragmentShader swizzle) { OpenTK.Graphics.OpenGL.GL.Ati.PassTexCoor(dst, coord, swizzle); }
        internal override void tkglPNTriangles(OpenTK.Graphics.OpenGL.AtiPnTriangles pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ati.PNTriangles(pname, param); }
        internal override void tkgl2PNTriangles(OpenTK.Graphics.OpenGL.AtiPnTriangles pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Ati.PNTriangles(pname, param); }
        internal override void tkglSampleMap(Int32 dst, Int32 interp, OpenTK.Graphics.OpenGL.AtiFragmentShader swizzle) { OpenTK.Graphics.OpenGL.GL.Ati.SampleMap(dst, interp, swizzle); }
        internal override void tkgl2SampleMap(UInt32 dst, UInt32 interp, OpenTK.Graphics.OpenGL.AtiFragmentShader swizzle) { OpenTK.Graphics.OpenGL.GL.Ati.SampleMap(dst, interp, swizzle); }
        internal override void tkglSetFragmentShaderConstant(Int32 dst, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ati.SetFragmentShaderConstant(dst, value); }
        internal override void tkgl2SetFragmentShaderConstant(Int32 dst, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ati.SetFragmentShaderConstant(dst, ref value); }
        internal override unsafe void tkgl3SetFragmentShaderConstant(Int32 dst, Single* value) { OpenTK.Graphics.OpenGL.GL.Ati.SetFragmentShaderConstant(dst, value); }
        internal override void tkgl4SetFragmentShaderConstant(UInt32 dst, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ati.SetFragmentShaderConstant(dst, value); }
        internal override void tkgl5SetFragmentShaderConstant(UInt32 dst, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ati.SetFragmentShaderConstant(dst, ref value); }
        internal override unsafe void tkgl6SetFragmentShaderConstant(UInt32 dst, Single* value) { OpenTK.Graphics.OpenGL.GL.Ati.SetFragmentShaderConstant(dst, value); }
        internal override void tkglStencilFuncSeparate(OpenTK.Graphics.OpenGL.StencilFunction frontfunc, OpenTK.Graphics.OpenGL.StencilFunction backfunc, Int32 @ref, Int32 mask) { OpenTK.Graphics.OpenGL.GL.Ati.StencilFuncSeparate(frontfunc, backfunc, @ref, mask); }
        internal override void tkgl2StencilFuncSeparate(OpenTK.Graphics.OpenGL.StencilFunction frontfunc, OpenTK.Graphics.OpenGL.StencilFunction backfunc, Int32 @ref, UInt32 mask) { OpenTK.Graphics.OpenGL.GL.Ati.StencilFuncSeparate(frontfunc, backfunc, @ref, mask); }
        internal override void tkglStencilOpSeparate(OpenTK.Graphics.OpenGL.AtiSeparateStencil face, OpenTK.Graphics.OpenGL.StencilOp sfail, OpenTK.Graphics.OpenGL.StencilOp dpfail, OpenTK.Graphics.OpenGL.StencilOp dppass) { OpenTK.Graphics.OpenGL.GL.Ati.StencilOpSeparate(face, sfail, dpfail, dppass); }
        internal override void tkglTexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, Single[] param) { OpenTK.Graphics.OpenGL.GL.Ati.TexBumpParameter(pname, param); }
        internal override void tkgl2TexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, ref Single param) { OpenTK.Graphics.OpenGL.GL.Ati.TexBumpParameter(pname, ref param); }
        internal override unsafe void tkgl3TexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, Single* param) { OpenTK.Graphics.OpenGL.GL.Ati.TexBumpParameter(pname, param); }
        internal override void tkgl4TexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, Int32[] param) { OpenTK.Graphics.OpenGL.GL.Ati.TexBumpParameter(pname, param); }
        internal override void tkgl5TexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, ref Int32 param) { OpenTK.Graphics.OpenGL.GL.Ati.TexBumpParameter(pname, ref param); }
        internal override unsafe void tkgl6TexBumpParameter(OpenTK.Graphics.OpenGL.AtiEnvmapBumpmap pname, Int32* param) { OpenTK.Graphics.OpenGL.GL.Ati.TexBumpParameter(pname, param); }
        internal override void tkglUnmapObjectBuffer(Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Ati.UnmapObjectBuffer(buffer); }
        internal override void tkgl2UnmapObjectBuffer(UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Ati.UnmapObjectBuffer(buffer); }
        internal override void tkglUpdateObjectBuffer(Int32 buffer, Int32 offset, Int32 size, IntPtr pointer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject preserve) { OpenTK.Graphics.OpenGL.GL.Ati.UpdateObjectBuffer(buffer, offset, size, pointer, preserve); }
        internal override void tkgl2UpdateObjectBuffer(UInt32 buffer, UInt32 offset, Int32 size, IntPtr pointer, OpenTK.Graphics.OpenGL.AtiVertexArrayObject preserve) { OpenTK.Graphics.OpenGL.GL.Ati.UpdateObjectBuffer(buffer, offset, size, pointer, preserve); }
        internal override void tkglVariantArrayObject(Int32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject type, Int32 stride, Int32 buffer, Int32 offset) { OpenTK.Graphics.OpenGL.GL.Ati.VariantArrayObject(id, type, stride, buffer, offset); }
        internal override void tkgl2VariantArrayObject(UInt32 id, OpenTK.Graphics.OpenGL.AtiVertexArrayObject type, Int32 stride, UInt32 buffer, UInt32 offset) { OpenTK.Graphics.OpenGL.GL.Ati.VariantArrayObject(id, type, stride, buffer, offset); }
        internal override void tkglVertexAttribArrayObject(Int32 index, Int32 size, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject type, bool normalized, Int32 stride, Int32 buffer, Int32 offset) { OpenTK.Graphics.OpenGL.GL.Ati.VertexAttribArrayObject(index, size, type, normalized, stride, buffer, offset); }
        internal override void tkgl2VertexAttribArrayObject(UInt32 index, Int32 size, OpenTK.Graphics.OpenGL.AtiVertexAttribArrayObject type, bool normalized, Int32 stride, UInt32 buffer, UInt32 offset) { OpenTK.Graphics.OpenGL.GL.Ati.VertexAttribArrayObject(index, size, type, normalized, stride, buffer, offset); }
        internal override void tkglVertexBlendEnv(OpenTK.Graphics.OpenGL.AtiVertexStreams pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ati.VertexBlendEnv(pname, param); }
        internal override void tkgl2VertexBlendEnv(OpenTK.Graphics.OpenGL.AtiVertexStreams pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Ati.VertexBlendEnv(pname, param); }
        internal override void tkglVertexStream1(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double x) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream1(stream, x); }
        internal override unsafe void tkgl2VertexStream1(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream1(stream, coords); }
        internal override void tkgl3VertexStream1(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single x) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream1(stream, x); }
        internal override unsafe void tkgl4VertexStream1(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream1(stream, coords); }
        internal override void tkgl5VertexStream1(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32 x) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream1(stream, x); }
        internal override unsafe void tkgl6VertexStream1(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream1(stream, coords); }
        internal override void tkgl7VertexStream1(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16 x) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream1(stream, x); }
        internal override unsafe void tkgl8VertexStream1(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream1(stream, coords); }
        internal override void tkglVertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double x, Double y) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, x, y); }
        internal override void tkgl2VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, coords); }
        internal override void tkgl3VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Double coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, ref coords); }
        internal override unsafe void tkgl4VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, coords); }
        internal override void tkgl5VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single x, Single y) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, x, y); }
        internal override void tkgl6VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, coords); }
        internal override void tkgl7VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Single coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, ref coords); }
        internal override unsafe void tkgl8VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, coords); }
        internal override void tkgl9VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, x, y); }
        internal override void tkgl10VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, coords); }
        internal override void tkgl11VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Int32 coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, ref coords); }
        internal override unsafe void tkgl12VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, coords); }
        internal override void tkgl13VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, x, y); }
        internal override void tkgl14VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, coords); }
        internal override void tkgl15VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Int16 coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, ref coords); }
        internal override unsafe void tkgl16VertexStream2(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream2(stream, coords); }
        internal override void tkglVertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, x, y, z); }
        internal override void tkgl2VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, coords); }
        internal override void tkgl3VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Double coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, ref coords); }
        internal override unsafe void tkgl4VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, coords); }
        internal override void tkgl5VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, x, y, z); }
        internal override void tkgl6VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, coords); }
        internal override void tkgl7VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Single coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, ref coords); }
        internal override unsafe void tkgl8VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, coords); }
        internal override void tkgl9VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, x, y, z); }
        internal override void tkgl10VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, coords); }
        internal override void tkgl11VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Int32 coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, ref coords); }
        internal override unsafe void tkgl12VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, coords); }
        internal override void tkgl13VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, x, y, z); }
        internal override void tkgl14VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, coords); }
        internal override void tkgl15VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Int16 coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, ref coords); }
        internal override unsafe void tkgl16VertexStream3(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream3(stream, coords); }
        internal override void tkglVertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, x, y, z, w); }
        internal override void tkgl2VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, coords); }
        internal override void tkgl3VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Double coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, ref coords); }
        internal override unsafe void tkgl4VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Double* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, coords); }
        internal override void tkgl5VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, x, y, z, w); }
        internal override void tkgl6VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, coords); }
        internal override void tkgl7VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Single coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, ref coords); }
        internal override unsafe void tkgl8VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Single* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, coords); }
        internal override void tkgl9VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, x, y, z, w); }
        internal override void tkgl10VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, coords); }
        internal override void tkgl11VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Int32 coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, ref coords); }
        internal override unsafe void tkgl12VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int32* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, coords); }
        internal override void tkgl13VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, x, y, z, w); }
        internal override void tkgl14VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16[] coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, coords); }
        internal override void tkgl15VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, ref Int16 coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, ref coords); }
        internal override unsafe void tkgl16VertexStream4(OpenTK.Graphics.OpenGL.AtiVertexStreams stream, Int16* coords) { OpenTK.Graphics.OpenGL.GL.Ati.VertexStream4(stream, coords); }
        internal override void tkglAccum(OpenTK.Graphics.OpenGL.AccumOp op, Single value) { OpenTK.Graphics.OpenGL.GL.Accum(op, value); }
        internal override void tkgl2ActiveTexture(OpenTK.Graphics.OpenGL.TextureUnit texture) { OpenTK.Graphics.OpenGL.GL.ActiveTexture(texture); }
        internal override void tkglAlphaFunc(OpenTK.Graphics.OpenGL.AlphaFunction func, Single @ref) { OpenTK.Graphics.OpenGL.GL.AlphaFunc(func, @ref); }
        internal override bool tkglAreTexturesResident(Int32 n, Int32[] textures, bool[] residences) { return OpenTK.Graphics.OpenGL.GL.AreTexturesResident(n, textures, residences); }
        internal override bool tkgl2AreTexturesResident(Int32 n, ref Int32 textures, out bool residences) { return OpenTK.Graphics.OpenGL.GL.AreTexturesResident(n, ref textures, out residences); }
        internal override unsafe bool tkgl3AreTexturesResident(Int32 n, Int32* textures, bool* residences) { return OpenTK.Graphics.OpenGL.GL.AreTexturesResident(n, textures, residences); }
        internal override bool tkgl4AreTexturesResident(Int32 n, UInt32[] textures, bool[] residences) { return OpenTK.Graphics.OpenGL.GL.AreTexturesResident(n, textures, residences); }
        internal override bool tkgl5AreTexturesResident(Int32 n, ref UInt32 textures, out bool residences) { return OpenTK.Graphics.OpenGL.GL.AreTexturesResident(n, ref textures, out residences); }
        internal override unsafe bool tkgl6AreTexturesResident(Int32 n, UInt32* textures, bool* residences) { return OpenTK.Graphics.OpenGL.GL.AreTexturesResident(n, textures, residences); }
        internal override void tkglArrayElement(Int32 i) { OpenTK.Graphics.OpenGL.GL.ArrayElement(i); }
        internal override void tkglAttachShader(Int32 program, Int32 shader) { OpenTK.Graphics.OpenGL.GL.AttachShader(program, shader); }
        internal override void tkgl2AttachShader(UInt32 program, UInt32 shader) { OpenTK.Graphics.OpenGL.GL.AttachShader(program, shader); }
        internal override void tkglBegin(OpenTK.Graphics.OpenGL.BeginMode mode) { OpenTK.Graphics.OpenGL.GL.Begin(mode); }
        internal override void tkglBeginConditionalRender(Int32 id, OpenTK.Graphics.OpenGL.ConditionalRenderType mode) { OpenTK.Graphics.OpenGL.GL.BeginConditionalRender(id, mode); }
        internal override void tkgl2BeginConditionalRender(UInt32 id, OpenTK.Graphics.OpenGL.ConditionalRenderType mode) { OpenTK.Graphics.OpenGL.GL.BeginConditionalRender(id, mode); }
        internal override void tkgl3BeginQuery(OpenTK.Graphics.OpenGL.QueryTarget target, Int32 id) { OpenTK.Graphics.OpenGL.GL.BeginQuery(target, id); }
        internal override void tkgl4BeginQuery(OpenTK.Graphics.OpenGL.QueryTarget target, UInt32 id) { OpenTK.Graphics.OpenGL.GL.BeginQuery(target, id); }
        internal override void tkglBeginTransformFeedback(OpenTK.Graphics.OpenGL.BeginFeedbackMode primitiveMode) { OpenTK.Graphics.OpenGL.GL.BeginTransformFeedback(primitiveMode); }
        internal override void tkgl3BindAttribLocation(Int32 program, Int32 index, String name) { OpenTK.Graphics.OpenGL.GL.BindAttribLocation(program, index, name); }
        internal override void tkgl4BindAttribLocation(UInt32 program, UInt32 index, String name) { OpenTK.Graphics.OpenGL.GL.BindAttribLocation(program, index, name); }
        internal override void tkgl3BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget target, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.BindBuffer(target, buffer); }
        internal override void tkgl4BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget target, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.BindBuffer(target, buffer); }
        internal override void tkglBindBufferBase(OpenTK.Graphics.OpenGL.BufferTarget target, Int32 index, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.BindBufferBase(target, index, buffer); }
        internal override void tkgl2BindBufferBase(OpenTK.Graphics.OpenGL.BufferTarget target, UInt32 index, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.BindBufferBase(target, index, buffer); }
        internal override void tkglBindBufferRange(OpenTK.Graphics.OpenGL.BufferTarget target, Int32 index, Int32 buffer, IntPtr offset, IntPtr size) { OpenTK.Graphics.OpenGL.GL.BindBufferRange(target, index, buffer, offset, size); }
        internal override void tkgl2BindBufferRange(OpenTK.Graphics.OpenGL.BufferTarget target, UInt32 index, UInt32 buffer, IntPtr offset, IntPtr size) { OpenTK.Graphics.OpenGL.GL.BindBufferRange(target, index, buffer, offset, size); }
        internal override void tkglBindFragDataLocation(Int32 program, Int32 color, String name) { OpenTK.Graphics.OpenGL.GL.BindFragDataLocation(program, color, name); }
        internal override void tkgl2BindFragDataLocation(UInt32 program, UInt32 color, String name) { OpenTK.Graphics.OpenGL.GL.BindFragDataLocation(program, color, name); }
        internal override void tkglBindFramebuffer(OpenTK.Graphics.OpenGL.FramebufferTarget target, Int32 framebuffer) { OpenTK.Graphics.OpenGL.GL.BindFramebuffer(target, framebuffer); }
        internal override void tkgl2BindFramebuffer(OpenTK.Graphics.OpenGL.FramebufferTarget target, UInt32 framebuffer) { OpenTK.Graphics.OpenGL.GL.BindFramebuffer(target, framebuffer); }
        internal override void tkglBindRenderbuffer(OpenTK.Graphics.OpenGL.RenderbufferTarget target, Int32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.BindRenderbuffer(target, renderbuffer); }
        internal override void tkgl2BindRenderbuffer(OpenTK.Graphics.OpenGL.RenderbufferTarget target, UInt32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.BindRenderbuffer(target, renderbuffer); }
        internal override void tkglBindTexture(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 texture) { OpenTK.Graphics.OpenGL.GL.BindTexture(target, texture); }
        internal override void tkgl2BindTexture(OpenTK.Graphics.OpenGL.TextureTarget target, UInt32 texture) { OpenTK.Graphics.OpenGL.GL.BindTexture(target, texture); }
        internal override void tkgl3BindVertexArray(Int32 array) { OpenTK.Graphics.OpenGL.GL.BindVertexArray(array); }
        internal override void tkgl4BindVertexArray(UInt32 array) { OpenTK.Graphics.OpenGL.GL.BindVertexArray(array); }
        internal override void tkglBitmap(Int32 width, Int32 height, Single xorig, Single yorig, Single xmove, Single ymove, Byte[] bitmap) { OpenTK.Graphics.OpenGL.GL.Bitmap(width, height, xorig, yorig, xmove, ymove, bitmap); }
        internal override void tkgl2Bitmap(Int32 width, Int32 height, Single xorig, Single yorig, Single xmove, Single ymove, ref Byte bitmap) { OpenTK.Graphics.OpenGL.GL.Bitmap(width, height, xorig, yorig, xmove, ymove, ref bitmap); }
        internal override unsafe void tkgl3Bitmap(Int32 width, Int32 height, Single xorig, Single yorig, Single xmove, Single ymove, Byte* bitmap) { OpenTK.Graphics.OpenGL.GL.Bitmap(width, height, xorig, yorig, xmove, ymove, bitmap); }
        internal override void tkglBlendColor(Single red, Single green, Single blue, Single alpha) { OpenTK.Graphics.OpenGL.GL.BlendColor(red, green, blue, alpha); }
        internal override void tkglBlendEquation(OpenTK.Graphics.OpenGL.BlendEquationMode mode) { OpenTK.Graphics.OpenGL.GL.BlendEquation(mode); }
        internal override void tkgl2BlendEquation(Int32 buf, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend mode) { OpenTK.Graphics.OpenGL.GL.BlendEquation(buf, mode); }
        internal override void tkgl3BlendEquation(UInt32 buf, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend mode) { OpenTK.Graphics.OpenGL.GL.BlendEquation(buf, mode); }
        internal override void tkglBlendEquationSeparate(OpenTK.Graphics.OpenGL.BlendEquationMode modeRGB, OpenTK.Graphics.OpenGL.BlendEquationMode modeAlpha) { OpenTK.Graphics.OpenGL.GL.BlendEquationSeparate(modeRGB, modeAlpha); }
        internal override void tkgl2BlendEquationSeparate(Int32 buf, OpenTK.Graphics.OpenGL.BlendEquationMode modeRGB, OpenTK.Graphics.OpenGL.BlendEquationMode modeAlpha) { OpenTK.Graphics.OpenGL.GL.BlendEquationSeparate(buf, modeRGB, modeAlpha); }
        internal override void tkgl3BlendEquationSeparate(UInt32 buf, OpenTK.Graphics.OpenGL.BlendEquationMode modeRGB, OpenTK.Graphics.OpenGL.BlendEquationMode modeAlpha) { OpenTK.Graphics.OpenGL.GL.BlendEquationSeparate(buf, modeRGB, modeAlpha); }
        internal override void tkglBlendFunc(OpenTK.Graphics.OpenGL.BlendingFactorSrc sfactor, OpenTK.Graphics.OpenGL.BlendingFactorDest dfactor) { OpenTK.Graphics.OpenGL.GL.BlendFunc(sfactor, dfactor); }
        internal override void tkgl2BlendFunc(Int32 buf, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend src, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend dst) { OpenTK.Graphics.OpenGL.GL.BlendFunc(buf, src, dst); }
        internal override void tkgl3BlendFunc(UInt32 buf, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend src, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend dst) { OpenTK.Graphics.OpenGL.GL.BlendFunc(buf, src, dst); }
        internal override void tkglBlendFuncSeparate(OpenTK.Graphics.OpenGL.BlendingFactorSrc sfactorRGB, OpenTK.Graphics.OpenGL.BlendingFactorDest dfactorRGB, OpenTK.Graphics.OpenGL.BlendingFactorSrc sfactorAlpha, OpenTK.Graphics.OpenGL.BlendingFactorDest dfactorAlpha) { OpenTK.Graphics.OpenGL.GL.BlendFuncSeparate(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha); }
        internal override void tkgl2BlendFuncSeparate(Int32 buf, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend srcRGB, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend dstRGB, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend srcAlpha, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend dstAlpha) { OpenTK.Graphics.OpenGL.GL.BlendFuncSeparate(buf, srcRGB, dstRGB, srcAlpha, dstAlpha); }
        internal override void tkgl3BlendFuncSeparate(UInt32 buf, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend srcRGB, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend dstRGB, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend srcAlpha, OpenTK.Graphics.OpenGL.ArbDrawBuffersBlend dstAlpha) { OpenTK.Graphics.OpenGL.GL.BlendFuncSeparate(buf, srcRGB, dstRGB, srcAlpha, dstAlpha); }
        internal override void tkglBlitFramebuffer(Int32 srcX0, Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0, Int32 dstY0, Int32 dstX1, Int32 dstY1, OpenTK.Graphics.OpenGL.ClearBufferMask mask, OpenTK.Graphics.OpenGL.BlitFramebufferFilter filter) { OpenTK.Graphics.OpenGL.GL.BlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter); }
        internal override void tkgl2BufferData(OpenTK.Graphics.OpenGL.BufferTarget target, IntPtr size, IntPtr data, OpenTK.Graphics.OpenGL.BufferUsageHint usage) { OpenTK.Graphics.OpenGL.GL.BufferData(target, size, data, usage); }
        internal override void tkgl2BufferSubData(OpenTK.Graphics.OpenGL.BufferTarget target, IntPtr offset, IntPtr size, IntPtr data) { OpenTK.Graphics.OpenGL.GL.BufferSubData(target, offset, size, data); }
        internal override void tkglCallList(Int32 list) { OpenTK.Graphics.OpenGL.GL.CallList(list); }
        internal override void tkgl2CallList(UInt32 list) { OpenTK.Graphics.OpenGL.GL.CallList(list); }
        internal override void tkglCallLists(Int32 n, OpenTK.Graphics.OpenGL.ListNameType type, IntPtr lists) { OpenTK.Graphics.OpenGL.GL.CallLists(n, type, lists); }
        internal override OpenTK.Graphics.OpenGL.FramebufferErrorCode tkglCheckFramebufferStatus(OpenTK.Graphics.OpenGL.FramebufferTarget target) { return OpenTK.Graphics.OpenGL.GL.CheckFramebufferStatus(target); }
        internal override void tkgl2ClampColor(OpenTK.Graphics.OpenGL.ClampColorTarget target, OpenTK.Graphics.OpenGL.ClampColorMode clamp) { OpenTK.Graphics.OpenGL.GL.ClampColor(target, clamp); }
        internal override void tkglClear(OpenTK.Graphics.OpenGL.ClearBufferMask mask) { OpenTK.Graphics.OpenGL.GL.Clear(mask); }
        internal override void tkglClearAccum(Single red, Single green, Single blue, Single alpha) { OpenTK.Graphics.OpenGL.GL.ClearAccum(red, green, blue, alpha); }
        internal override void tkglClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, Single depth, Int32 stencil) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, depth, stencil); }
        internal override void tkgl2ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, Single[] value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, value); }
        internal override void tkgl3ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, ref Single value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, ref value); }
        internal override unsafe void tkgl4ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, Single* value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, value); }
        internal override void tkgl5ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, Int32[] value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, value); }
        internal override void tkgl6ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, ref value); }
        internal override unsafe void tkgl7ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, Int32* value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, value); }
        internal override void tkgl8ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, value); }
        internal override void tkgl9ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, ref value); }
        internal override unsafe void tkgl10ClearBuffer(OpenTK.Graphics.OpenGL.ClearBuffer buffer, Int32 drawbuffer, UInt32* value) { OpenTK.Graphics.OpenGL.GL.ClearBuffer(buffer, drawbuffer, value); }
        internal override void tkglClearColor(Single red, Single green, Single blue, Single alpha) { OpenTK.Graphics.OpenGL.GL.ClearColor(red, green, blue, alpha); }
        internal override void tkglClearDepth(Double depth) { OpenTK.Graphics.OpenGL.GL.ClearDepth(depth); }
        internal override void tkglClearIndex(Single c) { OpenTK.Graphics.OpenGL.GL.ClearIndex(c); }
        internal override void tkglClearStencil(Int32 s) { OpenTK.Graphics.OpenGL.GL.ClearStencil(s); }
        internal override void tkgl2ClientActiveTexture(OpenTK.Graphics.OpenGL.TextureUnit texture) { OpenTK.Graphics.OpenGL.GL.ClientActiveTexture(texture); }
        internal override OpenTK.Graphics.OpenGL.ArbSync tkglClientWaitSync(IntPtr sync, Int32 flags, Int64 timeout) { return OpenTK.Graphics.OpenGL.GL.ClientWaitSync(sync, flags, timeout); }
        internal override OpenTK.Graphics.OpenGL.ArbSync tkgl2ClientWaitSync(IntPtr sync, UInt32 flags, UInt64 timeout) { return OpenTK.Graphics.OpenGL.GL.ClientWaitSync(sync, flags, timeout); }
        internal override void tkglClipPlane(OpenTK.Graphics.OpenGL.ClipPlaneName plane, Double[] equation) { OpenTK.Graphics.OpenGL.GL.ClipPlane(plane, equation); }
        internal override void tkgl2ClipPlane(OpenTK.Graphics.OpenGL.ClipPlaneName plane, ref Double equation) { OpenTK.Graphics.OpenGL.GL.ClipPlane(plane, ref equation); }
        internal override unsafe void tkgl3ClipPlane(OpenTK.Graphics.OpenGL.ClipPlaneName plane, Double* equation) { OpenTK.Graphics.OpenGL.GL.ClipPlane(plane, equation); }
        internal override void tkglColor3(SByte red, SByte green, SByte blue) { OpenTK.Graphics.OpenGL.GL.Color3(red, green, blue); }
        internal override void tkgl2Color3(SByte[] v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl3Color3(ref SByte v) { OpenTK.Graphics.OpenGL.GL.Color3(ref v); }
        internal override unsafe void tkgl4Color3(SByte* v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl5Color3(Double red, Double green, Double blue) { OpenTK.Graphics.OpenGL.GL.Color3(red, green, blue); }
        internal override void tkgl6Color3(Double[] v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl7Color3(ref Double v) { OpenTK.Graphics.OpenGL.GL.Color3(ref v); }
        internal override unsafe void tkgl8Color3(Double* v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl9Color3(Single red, Single green, Single blue) { OpenTK.Graphics.OpenGL.GL.Color3(red, green, blue); }
        internal override void tkgl10Color3(Single[] v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl11Color3(ref Single v) { OpenTK.Graphics.OpenGL.GL.Color3(ref v); }
        internal override unsafe void tkgl12Color3(Single* v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl13Color3(Int32 red, Int32 green, Int32 blue) { OpenTK.Graphics.OpenGL.GL.Color3(red, green, blue); }
        internal override void tkgl14Color3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl15Color3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Color3(ref v); }
        internal override unsafe void tkgl16Color3(Int32* v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl17Color3(Int16 red, Int16 green, Int16 blue) { OpenTK.Graphics.OpenGL.GL.Color3(red, green, blue); }
        internal override void tkgl18Color3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl19Color3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Color3(ref v); }
        internal override unsafe void tkgl20Color3(Int16* v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl21Color3(Byte red, Byte green, Byte blue) { OpenTK.Graphics.OpenGL.GL.Color3(red, green, blue); }
        internal override void tkgl22Color3(Byte[] v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl23Color3(ref Byte v) { OpenTK.Graphics.OpenGL.GL.Color3(ref v); }
        internal override unsafe void tkgl24Color3(Byte* v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl25Color3(UInt32 red, UInt32 green, UInt32 blue) { OpenTK.Graphics.OpenGL.GL.Color3(red, green, blue); }
        internal override void tkgl26Color3(UInt32[] v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl27Color3(ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.Color3(ref v); }
        internal override unsafe void tkgl28Color3(UInt32* v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl29Color3(UInt16 red, UInt16 green, UInt16 blue) { OpenTK.Graphics.OpenGL.GL.Color3(red, green, blue); }
        internal override void tkgl30Color3(UInt16[] v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkgl31Color3(ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.Color3(ref v); }
        internal override unsafe void tkgl32Color3(UInt16* v) { OpenTK.Graphics.OpenGL.GL.Color3(v); }
        internal override void tkglColor4(SByte red, SByte green, SByte blue, SByte alpha) { OpenTK.Graphics.OpenGL.GL.Color4(red, green, blue, alpha); }
        internal override void tkgl2Color4(SByte[] v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl3Color4(ref SByte v) { OpenTK.Graphics.OpenGL.GL.Color4(ref v); }
        internal override unsafe void tkgl4Color4(SByte* v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl5Color4(Double red, Double green, Double blue, Double alpha) { OpenTK.Graphics.OpenGL.GL.Color4(red, green, blue, alpha); }
        internal override void tkgl6Color4(Double[] v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl7Color4(ref Double v) { OpenTK.Graphics.OpenGL.GL.Color4(ref v); }
        internal override unsafe void tkgl8Color4(Double* v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl9Color4(Single red, Single green, Single blue, Single alpha) { OpenTK.Graphics.OpenGL.GL.Color4(red, green, blue, alpha); }
        internal override void tkgl10Color4(Single[] v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl11Color4(ref Single v) { OpenTK.Graphics.OpenGL.GL.Color4(ref v); }
        internal override unsafe void tkgl12Color4(Single* v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl13Color4(Int32 red, Int32 green, Int32 blue, Int32 alpha) { OpenTK.Graphics.OpenGL.GL.Color4(red, green, blue, alpha); }
        internal override void tkgl14Color4(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl15Color4(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Color4(ref v); }
        internal override unsafe void tkgl16Color4(Int32* v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl17Color4(Int16 red, Int16 green, Int16 blue, Int16 alpha) { OpenTK.Graphics.OpenGL.GL.Color4(red, green, blue, alpha); }
        internal override void tkgl18Color4(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl19Color4(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Color4(ref v); }
        internal override unsafe void tkgl20Color4(Int16* v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl21Color4(Byte red, Byte green, Byte blue, Byte alpha) { OpenTK.Graphics.OpenGL.GL.Color4(red, green, blue, alpha); }
        internal override void tkgl22Color4(Byte[] v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl23Color4(ref Byte v) { OpenTK.Graphics.OpenGL.GL.Color4(ref v); }
        internal override unsafe void tkgl24Color4(Byte* v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl25Color4(UInt32 red, UInt32 green, UInt32 blue, UInt32 alpha) { OpenTK.Graphics.OpenGL.GL.Color4(red, green, blue, alpha); }
        internal override void tkgl26Color4(UInt32[] v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl27Color4(ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.Color4(ref v); }
        internal override unsafe void tkgl28Color4(UInt32* v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl29Color4(UInt16 red, UInt16 green, UInt16 blue, UInt16 alpha) { OpenTK.Graphics.OpenGL.GL.Color4(red, green, blue, alpha); }
        internal override void tkgl30Color4(UInt16[] v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkgl31Color4(ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.Color4(ref v); }
        internal override unsafe void tkgl32Color4(UInt16* v) { OpenTK.Graphics.OpenGL.GL.Color4(v); }
        internal override void tkglColorMask(bool red, bool green, bool blue, bool alpha) { OpenTK.Graphics.OpenGL.GL.ColorMask(red, green, blue, alpha); }
        internal override void tkgl2ColorMask(Int32 index, bool r, bool g, bool b, bool a) { OpenTK.Graphics.OpenGL.GL.ColorMask(index, r, g, b, a); }
        internal override void tkgl3ColorMask(UInt32 index, bool r, bool g, bool b, bool a) { OpenTK.Graphics.OpenGL.GL.ColorMask(index, r, g, b, a); }
        internal override void tkglColorMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.ColorMaterialParameter mode) { OpenTK.Graphics.OpenGL.GL.ColorMaterial(face, mode); }
        internal override void tkglColorPointer(Int32 size, OpenTK.Graphics.OpenGL.ColorPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.ColorPointer(size, type, stride, pointer); }
        internal override void tkglColorSubTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, Int32 start, Int32 count, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr data) { OpenTK.Graphics.OpenGL.GL.ColorSubTable(target, start, count, format, type, data); }
        internal override void tkglColorTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr table) { OpenTK.Graphics.OpenGL.GL.ColorTable(target, internalformat, width, format, type, table); }
        internal override void tkglColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.ColorTableParameterPName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.ColorTableParameter(target, pname, @params); }
        internal override void tkgl2ColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.ColorTableParameterPName pname, ref Single @params) { OpenTK.Graphics.OpenGL.GL.ColorTableParameter(target, pname, ref @params); }
        internal override unsafe void tkgl3ColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.ColorTableParameterPName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.ColorTableParameter(target, pname, @params); }
        internal override void tkgl4ColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.ColorTableParameterPName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.ColorTableParameter(target, pname, @params); }
        internal override void tkgl5ColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.ColorTableParameterPName pname, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.ColorTableParameter(target, pname, ref @params); }
        internal override unsafe void tkgl6ColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.ColorTableParameterPName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.ColorTableParameter(target, pname, @params); }
        internal override void tkgl3CompileShader(Int32 shader) { OpenTK.Graphics.OpenGL.GL.CompileShader(shader); }
        internal override void tkgl4CompileShader(UInt32 shader) { OpenTK.Graphics.OpenGL.GL.CompileShader(shader); }
        internal override void tkgl2CompressedTexImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 border, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.CompressedTexImage1D(target, level, internalformat, width, border, imageSize, data); }
        internal override void tkgl2CompressedTexImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.CompressedTexImage2D(target, level, internalformat, width, height, border, imageSize, data); }
        internal override void tkgl2CompressedTexImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.CompressedTexImage3D(target, level, internalformat, width, height, depth, border, imageSize, data); }
        internal override void tkgl2CompressedTexSubImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.CompressedTexSubImage1D(target, level, xoffset, width, format, imageSize, data); }
        internal override void tkgl2CompressedTexSubImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.CompressedTexSubImage2D(target, level, xoffset, yoffset, width, height, format, imageSize, data); }
        internal override void tkgl2CompressedTexSubImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr data) { OpenTK.Graphics.OpenGL.GL.CompressedTexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data); }
        internal override void tkglConvolutionFilter1D(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr image) { OpenTK.Graphics.OpenGL.GL.ConvolutionFilter1D(target, internalformat, width, format, type, image); }
        internal override void tkglConvolutionFilter2D(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr image) { OpenTK.Graphics.OpenGL.GL.ConvolutionFilter2D(target, internalformat, width, height, format, type, image); }
        internal override void tkglConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.ConvolutionParameter pname, Single @params) { OpenTK.Graphics.OpenGL.GL.ConvolutionParameter(target, pname, @params); }
        internal override void tkgl2ConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.ConvolutionParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.ConvolutionParameter(target, pname, @params); }
        internal override unsafe void tkgl3ConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.ConvolutionParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.ConvolutionParameter(target, pname, @params); }
        internal override void tkgl4ConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.ConvolutionParameter pname, Int32 @params) { OpenTK.Graphics.OpenGL.GL.ConvolutionParameter(target, pname, @params); }
        internal override void tkgl5ConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.ConvolutionParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.ConvolutionParameter(target, pname, @params); }
        internal override unsafe void tkgl6ConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.ConvolutionParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.ConvolutionParameter(target, pname, @params); }
        internal override void tkglCopyBufferSubData(OpenTK.Graphics.OpenGL.BufferTarget readTarget, OpenTK.Graphics.OpenGL.BufferTarget writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size) { OpenTK.Graphics.OpenGL.GL.CopyBufferSubData(readTarget, writeTarget, readOffset, writeOffset, size); }
        internal override void tkglCopyColorSubTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, Int32 start, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.CopyColorSubTable(target, start, x, y, width); }
        internal override void tkglCopyColorTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.CopyColorTable(target, internalformat, x, y, width); }
        internal override void tkglCopyConvolutionFilter1D(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.CopyConvolutionFilter1D(target, internalformat, x, y, width); }
        internal override void tkglCopyConvolutionFilter2D(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.CopyConvolutionFilter2D(target, internalformat, x, y, width, height); }
        internal override void tkglCopyPixels(Int32 x, Int32 y, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelCopyType type) { OpenTK.Graphics.OpenGL.GL.CopyPixels(x, y, width, height, type); }
        internal override void tkglCopyTexImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 border) { OpenTK.Graphics.OpenGL.GL.CopyTexImage1D(target, level, internalformat, x, y, width, border); }
        internal override void tkglCopyTexImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border) { OpenTK.Graphics.OpenGL.GL.CopyTexImage2D(target, level, internalformat, x, y, width, height, border); }
        internal override void tkglCopyTexSubImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.CopyTexSubImage1D(target, level, xoffset, x, y, width); }
        internal override void tkglCopyTexSubImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.CopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height); }
        internal override void tkglCopyTexSubImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.CopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height); }
        internal override Int32 tkglCreateProgram() { return OpenTK.Graphics.OpenGL.GL.CreateProgram(); }
        internal override Int32 tkglCreateShader(OpenTK.Graphics.OpenGL.ShaderType type) { return OpenTK.Graphics.OpenGL.GL.CreateShader(type); }
        internal override void tkglCullFace(OpenTK.Graphics.OpenGL.CullFaceMode mode) { OpenTK.Graphics.OpenGL.GL.CullFace(mode); }
        internal override void tkgl7DeleteBuffers(Int32 n, Int32[] buffers) { OpenTK.Graphics.OpenGL.GL.DeleteBuffers(n, buffers); }
        internal override void tkgl8DeleteBuffers(Int32 n, ref Int32 buffers) { OpenTK.Graphics.OpenGL.GL.DeleteBuffers(n, ref buffers); }
        internal override unsafe void tkgl9DeleteBuffers(Int32 n, Int32* buffers) { OpenTK.Graphics.OpenGL.GL.DeleteBuffers(n, buffers); }
        internal override void tkgl10DeleteBuffers(Int32 n, UInt32[] buffers) { OpenTK.Graphics.OpenGL.GL.DeleteBuffers(n, buffers); }
        internal override void tkgl11DeleteBuffers(Int32 n, ref UInt32 buffers) { OpenTK.Graphics.OpenGL.GL.DeleteBuffers(n, ref buffers); }
        internal override unsafe void tkgl12DeleteBuffers(Int32 n, UInt32* buffers) { OpenTK.Graphics.OpenGL.GL.DeleteBuffers(n, buffers); }
        internal override void tkglDeleteFramebuffers(Int32 n, Int32[] framebuffers) { OpenTK.Graphics.OpenGL.GL.DeleteFramebuffers(n, framebuffers); }
        internal override void tkgl2DeleteFramebuffers(Int32 n, ref Int32 framebuffers) { OpenTK.Graphics.OpenGL.GL.DeleteFramebuffers(n, ref framebuffers); }
        internal override unsafe void tkgl3DeleteFramebuffers(Int32 n, Int32* framebuffers) { OpenTK.Graphics.OpenGL.GL.DeleteFramebuffers(n, framebuffers); }
        internal override void tkgl4DeleteFramebuffers(Int32 n, UInt32[] framebuffers) { OpenTK.Graphics.OpenGL.GL.DeleteFramebuffers(n, framebuffers); }
        internal override void tkgl5DeleteFramebuffers(Int32 n, ref UInt32 framebuffers) { OpenTK.Graphics.OpenGL.GL.DeleteFramebuffers(n, ref framebuffers); }
        internal override unsafe void tkgl6DeleteFramebuffers(Int32 n, UInt32* framebuffers) { OpenTK.Graphics.OpenGL.GL.DeleteFramebuffers(n, framebuffers); }
        internal override void tkglDeleteLists(Int32 list, Int32 range) { OpenTK.Graphics.OpenGL.GL.DeleteLists(list, range); }
        internal override void tkgl2DeleteLists(UInt32 list, Int32 range) { OpenTK.Graphics.OpenGL.GL.DeleteLists(list, range); }
        internal override void tkgl7DeleteProgram(Int32 program) { OpenTK.Graphics.OpenGL.GL.DeleteProgram(program); }
        internal override void tkgl8DeleteProgram(UInt32 program) { OpenTK.Graphics.OpenGL.GL.DeleteProgram(program); }
        internal override void tkgl7DeleteQueries(Int32 n, Int32[] ids) { OpenTK.Graphics.OpenGL.GL.DeleteQueries(n, ids); }
        internal override void tkgl8DeleteQueries(Int32 n, ref Int32 ids) { OpenTK.Graphics.OpenGL.GL.DeleteQueries(n, ref ids); }
        internal override unsafe void tkgl9DeleteQueries(Int32 n, Int32* ids) { OpenTK.Graphics.OpenGL.GL.DeleteQueries(n, ids); }
        internal override void tkgl10DeleteQueries(Int32 n, UInt32[] ids) { OpenTK.Graphics.OpenGL.GL.DeleteQueries(n, ids); }
        internal override void tkgl11DeleteQueries(Int32 n, ref UInt32 ids) { OpenTK.Graphics.OpenGL.GL.DeleteQueries(n, ref ids); }
        internal override unsafe void tkgl12DeleteQueries(Int32 n, UInt32* ids) { OpenTK.Graphics.OpenGL.GL.DeleteQueries(n, ids); }
        internal override void tkglDeleteRenderbuffers(Int32 n, Int32[] renderbuffers) { OpenTK.Graphics.OpenGL.GL.DeleteRenderbuffers(n, renderbuffers); }
        internal override void tkgl2DeleteRenderbuffers(Int32 n, ref Int32 renderbuffers) { OpenTK.Graphics.OpenGL.GL.DeleteRenderbuffers(n, ref renderbuffers); }
        internal override unsafe void tkgl3DeleteRenderbuffers(Int32 n, Int32* renderbuffers) { OpenTK.Graphics.OpenGL.GL.DeleteRenderbuffers(n, renderbuffers); }
        internal override void tkgl4DeleteRenderbuffers(Int32 n, UInt32[] renderbuffers) { OpenTK.Graphics.OpenGL.GL.DeleteRenderbuffers(n, renderbuffers); }
        internal override void tkgl5DeleteRenderbuffers(Int32 n, ref UInt32 renderbuffers) { OpenTK.Graphics.OpenGL.GL.DeleteRenderbuffers(n, ref renderbuffers); }
        internal override unsafe void tkgl6DeleteRenderbuffers(Int32 n, UInt32* renderbuffers) { OpenTK.Graphics.OpenGL.GL.DeleteRenderbuffers(n, renderbuffers); }
        internal override void tkglDeleteShader(Int32 shader) { OpenTK.Graphics.OpenGL.GL.DeleteShader(shader); }
        internal override void tkgl2DeleteShader(UInt32 shader) { OpenTK.Graphics.OpenGL.GL.DeleteShader(shader); }
        internal override void tkglDeleteSync(IntPtr sync) { OpenTK.Graphics.OpenGL.GL.DeleteSync(sync); }
        internal override void tkglDeleteTextures(Int32 n, Int32[] textures) { OpenTK.Graphics.OpenGL.GL.DeleteTextures(n, textures); }
        internal override void tkgl2DeleteTextures(Int32 n, ref Int32 textures) { OpenTK.Graphics.OpenGL.GL.DeleteTextures(n, ref textures); }
        internal override unsafe void tkgl3DeleteTextures(Int32 n, Int32* textures) { OpenTK.Graphics.OpenGL.GL.DeleteTextures(n, textures); }
        internal override void tkgl4DeleteTextures(Int32 n, UInt32[] textures) { OpenTK.Graphics.OpenGL.GL.DeleteTextures(n, textures); }
        internal override void tkgl5DeleteTextures(Int32 n, ref UInt32 textures) { OpenTK.Graphics.OpenGL.GL.DeleteTextures(n, ref textures); }
        internal override unsafe void tkgl6DeleteTextures(Int32 n, UInt32* textures) { OpenTK.Graphics.OpenGL.GL.DeleteTextures(n, textures); }
        internal override void tkgl7DeleteVertexArrays(Int32 n, Int32[] arrays) { OpenTK.Graphics.OpenGL.GL.DeleteVertexArrays(n, arrays); }
        internal override void tkgl8DeleteVertexArrays(Int32 n, ref Int32 arrays) { OpenTK.Graphics.OpenGL.GL.DeleteVertexArrays(n, ref arrays); }
        internal override unsafe void tkgl9DeleteVertexArrays(Int32 n, Int32* arrays) { OpenTK.Graphics.OpenGL.GL.DeleteVertexArrays(n, arrays); }
        internal override void tkgl10DeleteVertexArrays(Int32 n, UInt32[] arrays) { OpenTK.Graphics.OpenGL.GL.DeleteVertexArrays(n, arrays); }
        internal override void tkgl11DeleteVertexArrays(Int32 n, ref UInt32 arrays) { OpenTK.Graphics.OpenGL.GL.DeleteVertexArrays(n, ref arrays); }
        internal override unsafe void tkgl12DeleteVertexArrays(Int32 n, UInt32* arrays) { OpenTK.Graphics.OpenGL.GL.DeleteVertexArrays(n, arrays); }
        internal override void tkglDepthFunc(OpenTK.Graphics.OpenGL.DepthFunction func) { OpenTK.Graphics.OpenGL.GL.DepthFunc(func); }
        internal override void tkglDepthMask(bool flag) { OpenTK.Graphics.OpenGL.GL.DepthMask(flag); }
        internal override void tkglDepthRange(Double near, Double far) { OpenTK.Graphics.OpenGL.GL.DepthRange(near, far); }
        internal override void tkglDetachShader(Int32 program, Int32 shader) { OpenTK.Graphics.OpenGL.GL.DetachShader(program, shader); }
        internal override void tkgl2DetachShader(UInt32 program, UInt32 shader) { OpenTK.Graphics.OpenGL.GL.DetachShader(program, shader); }
        internal override void tkglDisable(OpenTK.Graphics.OpenGL.EnableCap cap) { OpenTK.Graphics.OpenGL.GL.Disable(cap); }
        internal override void tkglDisableClientState(OpenTK.Graphics.OpenGL.ArrayCap array) { OpenTK.Graphics.OpenGL.GL.DisableClientState(array); }
        internal override void tkgl2Disable(OpenTK.Graphics.OpenGL.IndexedEnableCap target, Int32 index) { OpenTK.Graphics.OpenGL.GL.Disable(target, index); }
        internal override void tkgl3Disable(OpenTK.Graphics.OpenGL.IndexedEnableCap target, UInt32 index) { OpenTK.Graphics.OpenGL.GL.Disable(target, index); }
        internal override void tkgl3DisableVertexAttribArray(Int32 index) { OpenTK.Graphics.OpenGL.GL.DisableVertexAttribArray(index); }
        internal override void tkgl4DisableVertexAttribArray(UInt32 index) { OpenTK.Graphics.OpenGL.GL.DisableVertexAttribArray(index); }
        internal override void tkglDrawArrays(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 first, Int32 count) { OpenTK.Graphics.OpenGL.GL.DrawArrays(mode, first, count); }
        internal override void tkgl2DrawArraysInstanced(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 first, Int32 count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.DrawArraysInstanced(mode, first, count, primcount); }
        internal override void tkglDrawBuffer(OpenTK.Graphics.OpenGL.DrawBufferMode mode) { OpenTK.Graphics.OpenGL.GL.DrawBuffer(mode); }
        internal override void tkgl7DrawBuffers(Int32 n, OpenTK.Graphics.OpenGL.DrawBuffersEnum[] bufs) { OpenTK.Graphics.OpenGL.GL.DrawBuffers(n, bufs); }
        internal override void tkgl8DrawBuffers(Int32 n, ref OpenTK.Graphics.OpenGL.DrawBuffersEnum bufs) { OpenTK.Graphics.OpenGL.GL.DrawBuffers(n, ref bufs); }
        internal override unsafe void tkgl9DrawBuffers(Int32 n, OpenTK.Graphics.OpenGL.DrawBuffersEnum* bufs) { OpenTK.Graphics.OpenGL.GL.DrawBuffers(n, bufs); }
        internal override void tkglDrawElements(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices) { OpenTK.Graphics.OpenGL.GL.DrawElements(mode, count, type, indices); }
        internal override void tkglDrawElementsBaseVertex(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex) { OpenTK.Graphics.OpenGL.GL.DrawElementsBaseVertex(mode, count, type, indices, basevertex); }
        internal override void tkgl2DrawElementsInstanced(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.DrawElementsInstanced(mode, count, type, indices, primcount); }
        internal override void tkglDrawElementsInstancedBaseVertex(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32 basevertex) { OpenTK.Graphics.OpenGL.GL.DrawElementsInstancedBaseVertex(mode, count, type, indices, primcount, basevertex); }
        internal override void tkglDrawPixels(Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.DrawPixels(width, height, format, type, pixels); }
        internal override void tkglDrawRangeElements(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 end, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices) { OpenTK.Graphics.OpenGL.GL.DrawRangeElements(mode, start, end, count, type, indices); }
        internal override void tkgl2DrawRangeElements(OpenTK.Graphics.OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices) { OpenTK.Graphics.OpenGL.GL.DrawRangeElements(mode, start, end, count, type, indices); }
        internal override void tkglDrawRangeElementsBaseVertex(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 end, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex) { OpenTK.Graphics.OpenGL.GL.DrawRangeElementsBaseVertex(mode, start, end, count, type, indices, basevertex); }
        internal override void tkgl2DrawRangeElementsBaseVertex(OpenTK.Graphics.OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 basevertex) { OpenTK.Graphics.OpenGL.GL.DrawRangeElementsBaseVertex(mode, start, end, count, type, indices, basevertex); }
        internal override void tkglEdgeFlag(bool flag) { OpenTK.Graphics.OpenGL.GL.EdgeFlag(flag); }
        internal override void tkglEdgeFlagPointer(Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.EdgeFlagPointer(stride, pointer); }
        internal override unsafe void tkgl2EdgeFlag(bool* flag) { OpenTK.Graphics.OpenGL.GL.EdgeFlag(flag); }
        internal override void tkglEnable(OpenTK.Graphics.OpenGL.EnableCap cap) { OpenTK.Graphics.OpenGL.GL.Enable(cap); }
        internal override void tkglEnableClientState(OpenTK.Graphics.OpenGL.ArrayCap array) { OpenTK.Graphics.OpenGL.GL.EnableClientState(array); }
        internal override void tkgl2Enable(OpenTK.Graphics.OpenGL.IndexedEnableCap target, Int32 index) { OpenTK.Graphics.OpenGL.GL.Enable(target, index); }
        internal override void tkgl3Enable(OpenTK.Graphics.OpenGL.IndexedEnableCap target, UInt32 index) { OpenTK.Graphics.OpenGL.GL.Enable(target, index); }
        internal override void tkgl3EnableVertexAttribArray(Int32 index) { OpenTK.Graphics.OpenGL.GL.EnableVertexAttribArray(index); }
        internal override void tkgl4EnableVertexAttribArray(UInt32 index) { OpenTK.Graphics.OpenGL.GL.EnableVertexAttribArray(index); }
        internal override void tkglEnd() { OpenTK.Graphics.OpenGL.GL.End(); }
        internal override void tkglEndConditionalRender() { OpenTK.Graphics.OpenGL.GL.EndConditionalRender(); }
        internal override void tkglEndList() { OpenTK.Graphics.OpenGL.GL.EndList(); }
        internal override void tkgl2EndQuery(OpenTK.Graphics.OpenGL.QueryTarget target) { OpenTK.Graphics.OpenGL.GL.EndQuery(target); }
        internal override void tkglEndTransformFeedback() { OpenTK.Graphics.OpenGL.GL.EndTransformFeedback(); }
        internal override void tkglEvalCoord1(Double u) { OpenTK.Graphics.OpenGL.GL.EvalCoord1(u); }
        internal override unsafe void tkgl2EvalCoord1(Double* u) { OpenTK.Graphics.OpenGL.GL.EvalCoord1(u); }
        internal override void tkgl3EvalCoord1(Single u) { OpenTK.Graphics.OpenGL.GL.EvalCoord1(u); }
        internal override unsafe void tkgl4EvalCoord1(Single* u) { OpenTK.Graphics.OpenGL.GL.EvalCoord1(u); }
        internal override void tkglEvalCoord2(Double u, Double v) { OpenTK.Graphics.OpenGL.GL.EvalCoord2(u, v); }
        internal override void tkgl2EvalCoord2(Double[] u) { OpenTK.Graphics.OpenGL.GL.EvalCoord2(u); }
        internal override void tkgl3EvalCoord2(ref Double u) { OpenTK.Graphics.OpenGL.GL.EvalCoord2(ref u); }
        internal override unsafe void tkgl4EvalCoord2(Double* u) { OpenTK.Graphics.OpenGL.GL.EvalCoord2(u); }
        internal override void tkgl5EvalCoord2(Single u, Single v) { OpenTK.Graphics.OpenGL.GL.EvalCoord2(u, v); }
        internal override void tkgl6EvalCoord2(Single[] u) { OpenTK.Graphics.OpenGL.GL.EvalCoord2(u); }
        internal override void tkgl7EvalCoord2(ref Single u) { OpenTK.Graphics.OpenGL.GL.EvalCoord2(ref u); }
        internal override unsafe void tkgl8EvalCoord2(Single* u) { OpenTK.Graphics.OpenGL.GL.EvalCoord2(u); }
        internal override void tkglEvalMesh1(OpenTK.Graphics.OpenGL.MeshMode1 mode, Int32 i1, Int32 i2) { OpenTK.Graphics.OpenGL.GL.EvalMesh1(mode, i1, i2); }
        internal override void tkglEvalMesh2(OpenTK.Graphics.OpenGL.MeshMode2 mode, Int32 i1, Int32 i2, Int32 j1, Int32 j2) { OpenTK.Graphics.OpenGL.GL.EvalMesh2(mode, i1, i2, j1, j2); }
        internal override void tkglEvalPoint1(Int32 i) { OpenTK.Graphics.OpenGL.GL.EvalPoint1(i); }
        internal override void tkglEvalPoint2(Int32 i, Int32 j) { OpenTK.Graphics.OpenGL.GL.EvalPoint2(i, j); }
        internal override void tkglFeedbackBuffer(Int32 size, OpenTK.Graphics.OpenGL.FeedbackType type, Single[] buffer) { OpenTK.Graphics.OpenGL.GL.FeedbackBuffer(size, type, buffer); }
        internal override void tkgl2FeedbackBuffer(Int32 size, OpenTK.Graphics.OpenGL.FeedbackType type, out Single buffer) { OpenTK.Graphics.OpenGL.GL.FeedbackBuffer(size, type, out buffer); }
        internal override unsafe void tkgl3FeedbackBuffer(Int32 size, OpenTK.Graphics.OpenGL.FeedbackType type, Single* buffer) { OpenTK.Graphics.OpenGL.GL.FeedbackBuffer(size, type, buffer); }
        internal override IntPtr tkglFenceSync(OpenTK.Graphics.OpenGL.ArbSync condition, Int32 flags) { return OpenTK.Graphics.OpenGL.GL.FenceSync(condition, flags); }
        internal override IntPtr tkgl2FenceSync(OpenTK.Graphics.OpenGL.ArbSync condition, UInt32 flags) { return OpenTK.Graphics.OpenGL.GL.FenceSync(condition, flags); }
        internal override void tkglFinish() { OpenTK.Graphics.OpenGL.GL.Finish(); }
        internal override void tkglFlush() { OpenTK.Graphics.OpenGL.GL.Flush(); }
        internal override void tkgl2FlushMappedBufferRange(OpenTK.Graphics.OpenGL.BufferTarget target, IntPtr offset, IntPtr length) { OpenTK.Graphics.OpenGL.GL.FlushMappedBufferRange(target, offset, length); }
        internal override void tkglFogCoord(Double coord) { OpenTK.Graphics.OpenGL.GL.FogCoord(coord); }
        internal override unsafe void tkgl2FogCoord(Double* coord) { OpenTK.Graphics.OpenGL.GL.FogCoord(coord); }
        internal override void tkgl3FogCoord(Single coord) { OpenTK.Graphics.OpenGL.GL.FogCoord(coord); }
        internal override unsafe void tkgl4FogCoord(Single* coord) { OpenTK.Graphics.OpenGL.GL.FogCoord(coord); }
        internal override void tkglFogCoordPointer(OpenTK.Graphics.OpenGL.FogPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.FogCoordPointer(type, stride, pointer); }
        internal override void tkglFog(OpenTK.Graphics.OpenGL.FogParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.Fog(pname, param); }
        internal override void tkgl2Fog(OpenTK.Graphics.OpenGL.FogParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Fog(pname, @params); }
        internal override unsafe void tkgl3Fog(OpenTK.Graphics.OpenGL.FogParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Fog(pname, @params); }
        internal override void tkgl4Fog(OpenTK.Graphics.OpenGL.FogParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Fog(pname, param); }
        internal override void tkgl5Fog(OpenTK.Graphics.OpenGL.FogParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Fog(pname, @params); }
        internal override unsafe void tkgl6Fog(OpenTK.Graphics.OpenGL.FogParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Fog(pname, @params); }
        internal override void tkglFramebufferRenderbuffer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.RenderbufferTarget renderbuffertarget, Int32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.FramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer); }
        internal override void tkgl2FramebufferRenderbuffer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.RenderbufferTarget renderbuffertarget, UInt32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.FramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer); }
        internal override void tkgl3FramebufferTexture(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.FramebufferTexture(target, attachment, texture, level); }
        internal override void tkgl4FramebufferTexture(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.FramebufferTexture(target, attachment, texture, level); }
        internal override void tkglFramebufferTexture1D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.FramebufferTexture1D(target, attachment, textarget, texture, level); }
        internal override void tkgl2FramebufferTexture1D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.FramebufferTexture1D(target, attachment, textarget, texture, level); }
        internal override void tkglFramebufferTexture2D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.FramebufferTexture2D(target, attachment, textarget, texture, level); }
        internal override void tkgl2FramebufferTexture2D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.FramebufferTexture2D(target, attachment, textarget, texture, level); }
        internal override void tkglFramebufferTexture3D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level, Int32 zoffset) { OpenTK.Graphics.OpenGL.GL.FramebufferTexture3D(target, attachment, textarget, texture, level, zoffset); }
        internal override void tkgl2FramebufferTexture3D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level, Int32 zoffset) { OpenTK.Graphics.OpenGL.GL.FramebufferTexture3D(target, attachment, textarget, texture, level, zoffset); }
        internal override void tkgl3FramebufferTextureFace(OpenTK.Graphics.OpenGL.Version32 target, OpenTK.Graphics.OpenGL.Version32 attachment, Int32 texture, Int32 level, OpenTK.Graphics.OpenGL.Version32 face) { OpenTK.Graphics.OpenGL.GL.FramebufferTextureFace(target, attachment, texture, level, face); }
        internal override void tkgl4FramebufferTextureFace(OpenTK.Graphics.OpenGL.Version32 target, OpenTK.Graphics.OpenGL.Version32 attachment, UInt32 texture, Int32 level, OpenTK.Graphics.OpenGL.Version32 face) { OpenTK.Graphics.OpenGL.GL.FramebufferTextureFace(target, attachment, texture, level, face); }
        internal override void tkgl3FramebufferTextureLayer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level, Int32 layer) { OpenTK.Graphics.OpenGL.GL.FramebufferTextureLayer(target, attachment, texture, level, layer); }
        internal override void tkgl4FramebufferTextureLayer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, Int32 layer) { OpenTK.Graphics.OpenGL.GL.FramebufferTextureLayer(target, attachment, texture, level, layer); }
        internal override void tkglFrontFace(OpenTK.Graphics.OpenGL.FrontFaceDirection mode) { OpenTK.Graphics.OpenGL.GL.FrontFace(mode); }
        internal override void tkglFrustum(Double left, Double right, Double bottom, Double top, Double zNear, Double zFar) { OpenTK.Graphics.OpenGL.GL.Frustum(left, right, bottom, top, zNear, zFar); }
        internal override void tkgl7GenBuffers(Int32 n, Int32[] buffers) { OpenTK.Graphics.OpenGL.GL.GenBuffers(n, buffers); }
        internal override void tkgl8GenBuffers(Int32 n, out Int32 buffers) { OpenTK.Graphics.OpenGL.GL.GenBuffers(n, out buffers); }
        internal override unsafe void tkgl9GenBuffers(Int32 n, Int32* buffers) { OpenTK.Graphics.OpenGL.GL.GenBuffers(n, buffers); }
        internal override void tkgl10GenBuffers(Int32 n, UInt32[] buffers) { OpenTK.Graphics.OpenGL.GL.GenBuffers(n, buffers); }
        internal override void tkgl11GenBuffers(Int32 n, out UInt32 buffers) { OpenTK.Graphics.OpenGL.GL.GenBuffers(n, out buffers); }
        internal override unsafe void tkgl12GenBuffers(Int32 n, UInt32* buffers) { OpenTK.Graphics.OpenGL.GL.GenBuffers(n, buffers); }
        internal override void tkglGenerateMipmap(OpenTK.Graphics.OpenGL.GenerateMipmapTarget target) { OpenTK.Graphics.OpenGL.GL.GenerateMipmap(target); }
        internal override void tkglGenFramebuffers(Int32 n, Int32[] framebuffers) { OpenTK.Graphics.OpenGL.GL.GenFramebuffers(n, framebuffers); }
        internal override void tkgl2GenFramebuffers(Int32 n, out Int32 framebuffers) { OpenTK.Graphics.OpenGL.GL.GenFramebuffers(n, out framebuffers); }
        internal override unsafe void tkgl3GenFramebuffers(Int32 n, Int32* framebuffers) { OpenTK.Graphics.OpenGL.GL.GenFramebuffers(n, framebuffers); }
        internal override void tkgl4GenFramebuffers(Int32 n, UInt32[] framebuffers) { OpenTK.Graphics.OpenGL.GL.GenFramebuffers(n, framebuffers); }
        internal override void tkgl5GenFramebuffers(Int32 n, out UInt32 framebuffers) { OpenTK.Graphics.OpenGL.GL.GenFramebuffers(n, out framebuffers); }
        internal override unsafe void tkgl6GenFramebuffers(Int32 n, UInt32* framebuffers) { OpenTK.Graphics.OpenGL.GL.GenFramebuffers(n, framebuffers); }
        internal override Int32 tkglGenLists(Int32 range) { return OpenTK.Graphics.OpenGL.GL.GenLists(range); }
        internal override void tkgl7GenQueries(Int32 n, Int32[] ids) { OpenTK.Graphics.OpenGL.GL.GenQueries(n, ids); }
        internal override void tkgl8GenQueries(Int32 n, out Int32 ids) { OpenTK.Graphics.OpenGL.GL.GenQueries(n, out ids); }
        internal override unsafe void tkgl9GenQueries(Int32 n, Int32* ids) { OpenTK.Graphics.OpenGL.GL.GenQueries(n, ids); }
        internal override void tkgl10GenQueries(Int32 n, UInt32[] ids) { OpenTK.Graphics.OpenGL.GL.GenQueries(n, ids); }
        internal override void tkgl11GenQueries(Int32 n, out UInt32 ids) { OpenTK.Graphics.OpenGL.GL.GenQueries(n, out ids); }
        internal override unsafe void tkgl12GenQueries(Int32 n, UInt32* ids) { OpenTK.Graphics.OpenGL.GL.GenQueries(n, ids); }
        internal override void tkglGenRenderbuffers(Int32 n, Int32[] renderbuffers) { OpenTK.Graphics.OpenGL.GL.GenRenderbuffers(n, renderbuffers); }
        internal override void tkgl2GenRenderbuffers(Int32 n, out Int32 renderbuffers) { OpenTK.Graphics.OpenGL.GL.GenRenderbuffers(n, out renderbuffers); }
        internal override unsafe void tkgl3GenRenderbuffers(Int32 n, Int32* renderbuffers) { OpenTK.Graphics.OpenGL.GL.GenRenderbuffers(n, renderbuffers); }
        internal override void tkgl4GenRenderbuffers(Int32 n, UInt32[] renderbuffers) { OpenTK.Graphics.OpenGL.GL.GenRenderbuffers(n, renderbuffers); }
        internal override void tkgl5GenRenderbuffers(Int32 n, out UInt32 renderbuffers) { OpenTK.Graphics.OpenGL.GL.GenRenderbuffers(n, out renderbuffers); }
        internal override unsafe void tkgl6GenRenderbuffers(Int32 n, UInt32* renderbuffers) { OpenTK.Graphics.OpenGL.GL.GenRenderbuffers(n, renderbuffers); }
        internal override void tkglGenTextures(Int32 n, Int32[] textures) { OpenTK.Graphics.OpenGL.GL.GenTextures(n, textures); }
        internal override void tkgl2GenTextures(Int32 n, out Int32 textures) { OpenTK.Graphics.OpenGL.GL.GenTextures(n, out textures); }
        internal override unsafe void tkgl3GenTextures(Int32 n, Int32* textures) { OpenTK.Graphics.OpenGL.GL.GenTextures(n, textures); }
        internal override void tkgl4GenTextures(Int32 n, UInt32[] textures) { OpenTK.Graphics.OpenGL.GL.GenTextures(n, textures); }
        internal override void tkgl5GenTextures(Int32 n, out UInt32 textures) { OpenTK.Graphics.OpenGL.GL.GenTextures(n, out textures); }
        internal override unsafe void tkgl6GenTextures(Int32 n, UInt32* textures) { OpenTK.Graphics.OpenGL.GL.GenTextures(n, textures); }
        internal override void tkgl7GenVertexArrays(Int32 n, Int32[] arrays) { OpenTK.Graphics.OpenGL.GL.GenVertexArrays(n, arrays); }
        internal override void tkgl8GenVertexArrays(Int32 n, out Int32 arrays) { OpenTK.Graphics.OpenGL.GL.GenVertexArrays(n, out arrays); }
        internal override unsafe void tkgl9GenVertexArrays(Int32 n, Int32* arrays) { OpenTK.Graphics.OpenGL.GL.GenVertexArrays(n, arrays); }
        internal override void tkgl10GenVertexArrays(Int32 n, UInt32[] arrays) { OpenTK.Graphics.OpenGL.GL.GenVertexArrays(n, arrays); }
        internal override void tkgl11GenVertexArrays(Int32 n, out UInt32 arrays) { OpenTK.Graphics.OpenGL.GL.GenVertexArrays(n, out arrays); }
        internal override unsafe void tkgl12GenVertexArrays(Int32 n, UInt32* arrays) { OpenTK.Graphics.OpenGL.GL.GenVertexArrays(n, arrays); }
        internal override void tkgl5GetActiveAttrib(Int32 program, Int32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ActiveAttribType type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetActiveAttrib(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl6GetActiveAttrib(Int32 program, Int32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ActiveAttribType* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetActiveAttrib(program, index, bufSize, length, size, type, name); }
        internal override void tkgl7GetActiveAttrib(UInt32 program, UInt32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ActiveAttribType type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetActiveAttrib(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl8GetActiveAttrib(UInt32 program, UInt32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ActiveAttribType* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetActiveAttrib(program, index, bufSize, length, size, type, name); }
        internal override void tkgl5GetActiveUniform(Int32 program, Int32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ActiveUniformType type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetActiveUniform(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl6GetActiveUniform(Int32 program, Int32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ActiveUniformType* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetActiveUniform(program, index, bufSize, length, size, type, name); }
        internal override void tkgl7GetActiveUniform(UInt32 program, UInt32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ActiveUniformType type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetActiveUniform(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl8GetActiveUniform(UInt32 program, UInt32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ActiveUniformType* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetActiveUniform(program, index, bufSize, length, size, type, name); }
        internal override void tkglGetActiveUniformBlock(Int32 program, Int32 uniformBlockIndex, OpenTK.Graphics.OpenGL.ActiveUniformBlockParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlock(program, uniformBlockIndex, pname, @params); }
        internal override void tkgl2GetActiveUniformBlock(Int32 program, Int32 uniformBlockIndex, OpenTK.Graphics.OpenGL.ActiveUniformBlockParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlock(program, uniformBlockIndex, pname, out @params); }
        internal override unsafe void tkgl3GetActiveUniformBlock(Int32 program, Int32 uniformBlockIndex, OpenTK.Graphics.OpenGL.ActiveUniformBlockParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlock(program, uniformBlockIndex, pname, @params); }
        internal override void tkgl4GetActiveUniformBlock(UInt32 program, UInt32 uniformBlockIndex, OpenTK.Graphics.OpenGL.ActiveUniformBlockParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlock(program, uniformBlockIndex, pname, @params); }
        internal override void tkgl5GetActiveUniformBlock(UInt32 program, UInt32 uniformBlockIndex, OpenTK.Graphics.OpenGL.ActiveUniformBlockParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlock(program, uniformBlockIndex, pname, out @params); }
        internal override unsafe void tkgl6GetActiveUniformBlock(UInt32 program, UInt32 uniformBlockIndex, OpenTK.Graphics.OpenGL.ActiveUniformBlockParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlock(program, uniformBlockIndex, pname, @params); }
        internal override void tkglGetActiveUniformBlockName(Int32 program, Int32 uniformBlockIndex, Int32 bufSize, out Int32 length, StringBuilder uniformBlockName) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlockName(program, uniformBlockIndex, bufSize, out length, uniformBlockName); }
        internal override unsafe void tkgl2GetActiveUniformBlockName(Int32 program, Int32 uniformBlockIndex, Int32 bufSize, Int32* length, StringBuilder uniformBlockName) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length, uniformBlockName); }
        internal override void tkgl3GetActiveUniformBlockName(UInt32 program, UInt32 uniformBlockIndex, Int32 bufSize, out Int32 length, StringBuilder uniformBlockName) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlockName(program, uniformBlockIndex, bufSize, out length, uniformBlockName); }
        internal override unsafe void tkgl4GetActiveUniformBlockName(UInt32 program, UInt32 uniformBlockIndex, Int32 bufSize, Int32* length, StringBuilder uniformBlockName) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformBlockName(program, uniformBlockIndex, bufSize, length, uniformBlockName); }
        internal override void tkglGetActiveUniformName(Int32 program, Int32 uniformIndex, Int32 bufSize, out Int32 length, StringBuilder uniformName) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformName(program, uniformIndex, bufSize, out length, uniformName); }
        internal override unsafe void tkgl2GetActiveUniformName(Int32 program, Int32 uniformIndex, Int32 bufSize, Int32* length, StringBuilder uniformName) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformName(program, uniformIndex, bufSize, length, uniformName); }
        internal override void tkgl3GetActiveUniformName(UInt32 program, UInt32 uniformIndex, Int32 bufSize, out Int32 length, StringBuilder uniformName) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformName(program, uniformIndex, bufSize, out length, uniformName); }
        internal override unsafe void tkgl4GetActiveUniformName(UInt32 program, UInt32 uniformIndex, Int32 bufSize, Int32* length, StringBuilder uniformName) { OpenTK.Graphics.OpenGL.GL.GetActiveUniformName(program, uniformIndex, bufSize, length, uniformName); }
        internal override void tkglGetActiveUniforms(Int32 program, Int32 uniformCount, Int32[] uniformIndices, OpenTK.Graphics.OpenGL.ActiveUniformParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniforms(program, uniformCount, uniformIndices, pname, @params); }
        internal override void tkgl2GetActiveUniforms(Int32 program, Int32 uniformCount, ref Int32 uniformIndices, OpenTK.Graphics.OpenGL.ActiveUniformParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniforms(program, uniformCount, ref uniformIndices, pname, out @params); }
        internal override unsafe void tkgl3GetActiveUniforms(Int32 program, Int32 uniformCount, Int32* uniformIndices, OpenTK.Graphics.OpenGL.ActiveUniformParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniforms(program, uniformCount, uniformIndices, pname, @params); }
        internal override void tkgl4GetActiveUniforms(UInt32 program, Int32 uniformCount, UInt32[] uniformIndices, OpenTK.Graphics.OpenGL.ActiveUniformParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniforms(program, uniformCount, uniformIndices, pname, @params); }
        internal override void tkgl5GetActiveUniforms(UInt32 program, Int32 uniformCount, ref UInt32 uniformIndices, OpenTK.Graphics.OpenGL.ActiveUniformParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniforms(program, uniformCount, ref uniformIndices, pname, out @params); }
        internal override unsafe void tkgl6GetActiveUniforms(UInt32 program, Int32 uniformCount, UInt32* uniformIndices, OpenTK.Graphics.OpenGL.ActiveUniformParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetActiveUniforms(program, uniformCount, uniformIndices, pname, @params); }
        internal override void tkglGetAttachedShaders(Int32 program, Int32 maxCount, out Int32 count, out Int32 obj) { OpenTK.Graphics.OpenGL.GL.GetAttachedShaders(program, maxCount, out count, out obj); }
        internal override unsafe void tkgl2GetAttachedShaders(Int32 program, Int32 maxCount, Int32* count, Int32[] obj) { OpenTK.Graphics.OpenGL.GL.GetAttachedShaders(program, maxCount, count, obj); }
        internal override unsafe void tkgl3GetAttachedShaders(Int32 program, Int32 maxCount, Int32* count, Int32* obj) { OpenTK.Graphics.OpenGL.GL.GetAttachedShaders(program, maxCount, count, obj); }
        internal override void tkgl4GetAttachedShaders(UInt32 program, Int32 maxCount, out Int32 count, out UInt32 obj) { OpenTK.Graphics.OpenGL.GL.GetAttachedShaders(program, maxCount, out count, out obj); }
        internal override unsafe void tkgl5GetAttachedShaders(UInt32 program, Int32 maxCount, Int32* count, UInt32[] obj) { OpenTK.Graphics.OpenGL.GL.GetAttachedShaders(program, maxCount, count, obj); }
        internal override unsafe void tkgl6GetAttachedShaders(UInt32 program, Int32 maxCount, Int32* count, UInt32* obj) { OpenTK.Graphics.OpenGL.GL.GetAttachedShaders(program, maxCount, count, obj); }
        internal override Int32 tkgl3GetAttribLocation(Int32 program, String name) { return OpenTK.Graphics.OpenGL.GL.GetAttribLocation(program, name); }
        internal override Int32 tkgl4GetAttribLocation(UInt32 program, String name) { return OpenTK.Graphics.OpenGL.GL.GetAttribLocation(program, name); }
        internal override void tkglGetBoolean(OpenTK.Graphics.OpenGL.GetIndexedPName target, Int32 index, bool[] data) { OpenTK.Graphics.OpenGL.GL.GetBoolean(target, index, data); }
        internal override void tkgl2GetBoolean(OpenTK.Graphics.OpenGL.GetIndexedPName target, Int32 index, out bool data) { OpenTK.Graphics.OpenGL.GL.GetBoolean(target, index, out data); }
        internal override unsafe void tkgl3GetBoolean(OpenTK.Graphics.OpenGL.GetIndexedPName target, Int32 index, bool* data) { OpenTK.Graphics.OpenGL.GL.GetBoolean(target, index, data); }
        internal override void tkgl4GetBoolean(OpenTK.Graphics.OpenGL.GetIndexedPName target, UInt32 index, bool[] data) { OpenTK.Graphics.OpenGL.GL.GetBoolean(target, index, data); }
        internal override void tkgl5GetBoolean(OpenTK.Graphics.OpenGL.GetIndexedPName target, UInt32 index, out bool data) { OpenTK.Graphics.OpenGL.GL.GetBoolean(target, index, out data); }
        internal override unsafe void tkgl6GetBoolean(OpenTK.Graphics.OpenGL.GetIndexedPName target, UInt32 index, bool* data) { OpenTK.Graphics.OpenGL.GL.GetBoolean(target, index, data); }
        internal override void tkgl7GetBoolean(OpenTK.Graphics.OpenGL.GetPName pname, bool[] @params) { OpenTK.Graphics.OpenGL.GL.GetBoolean(pname, @params); }
        internal override void tkgl8GetBoolean(OpenTK.Graphics.OpenGL.GetPName pname, out bool @params) { OpenTK.Graphics.OpenGL.GL.GetBoolean(pname, out @params); }
        internal override unsafe void tkgl9GetBoolean(OpenTK.Graphics.OpenGL.GetPName pname, bool* @params) { OpenTK.Graphics.OpenGL.GL.GetBoolean(pname, @params); }
        internal override void tkglGetBufferParameteri64(OpenTK.Graphics.OpenGL.Version32 target, OpenTK.Graphics.OpenGL.Version32 pname, Int64[] @params) { OpenTK.Graphics.OpenGL.GL.GetBufferParameteri64(target, pname, @params); }
        internal override void tkgl2GetBufferParameteri64(OpenTK.Graphics.OpenGL.Version32 target, OpenTK.Graphics.OpenGL.Version32 pname, out Int64 @params) { OpenTK.Graphics.OpenGL.GL.GetBufferParameteri64(target, pname, out @params); }
        internal override unsafe void tkgl3GetBufferParameteri64(OpenTK.Graphics.OpenGL.Version32 target, OpenTK.Graphics.OpenGL.Version32 pname, Int64* @params) { OpenTK.Graphics.OpenGL.GL.GetBufferParameteri64(target, pname, @params); }
        internal override void tkgl4GetBufferParameter(OpenTK.Graphics.OpenGL.BufferTarget target, OpenTK.Graphics.OpenGL.BufferParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetBufferParameter(target, pname, @params); }
        internal override void tkgl5GetBufferParameter(OpenTK.Graphics.OpenGL.BufferTarget target, OpenTK.Graphics.OpenGL.BufferParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetBufferParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetBufferParameter(OpenTK.Graphics.OpenGL.BufferTarget target, OpenTK.Graphics.OpenGL.BufferParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetBufferParameter(target, pname, @params); }
        internal override void tkgl2GetBufferPointer(OpenTK.Graphics.OpenGL.BufferTarget target, OpenTK.Graphics.OpenGL.BufferPointer pname, IntPtr @params) { OpenTK.Graphics.OpenGL.GL.GetBufferPointer(target, pname, @params); }
        internal override void tkgl2GetBufferSubData(OpenTK.Graphics.OpenGL.BufferTarget target, IntPtr offset, IntPtr size, IntPtr data) { OpenTK.Graphics.OpenGL.GL.GetBufferSubData(target, offset, size, data); }
        internal override void tkglGetClipPlane(OpenTK.Graphics.OpenGL.ClipPlaneName plane, Double[] equation) { OpenTK.Graphics.OpenGL.GL.GetClipPlane(plane, equation); }
        internal override void tkgl2GetClipPlane(OpenTK.Graphics.OpenGL.ClipPlaneName plane, out Double equation) { OpenTK.Graphics.OpenGL.GL.GetClipPlane(plane, out equation); }
        internal override unsafe void tkgl3GetClipPlane(OpenTK.Graphics.OpenGL.ClipPlaneName plane, Double* equation) { OpenTK.Graphics.OpenGL.GL.GetClipPlane(plane, equation); }
        internal override void tkglGetColorTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr table) { OpenTK.Graphics.OpenGL.GL.GetColorTable(target, format, type, table); }
        internal override void tkglGetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl2GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetColorTableParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl4GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl5GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetColorTableParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl2GetCompressedTexImage(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, IntPtr img) { OpenTK.Graphics.OpenGL.GL.GetCompressedTexImage(target, level, img); }
        internal override void tkglGetConvolutionFilter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr image) { OpenTK.Graphics.OpenGL.GL.GetConvolutionFilter(target, format, type, image); }
        internal override void tkglGetConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.GetConvolutionParameterPName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetConvolutionParameter(target, pname, @params); }
        internal override void tkgl2GetConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.GetConvolutionParameterPName pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetConvolutionParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.GetConvolutionParameterPName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetConvolutionParameter(target, pname, @params); }
        internal override void tkgl4GetConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.GetConvolutionParameterPName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetConvolutionParameter(target, pname, @params); }
        internal override void tkgl5GetConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.GetConvolutionParameterPName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetConvolutionParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetConvolutionParameter(OpenTK.Graphics.OpenGL.ConvolutionTarget target, OpenTK.Graphics.OpenGL.GetConvolutionParameterPName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetConvolutionParameter(target, pname, @params); }
        internal override void tkglGetDouble(OpenTK.Graphics.OpenGL.GetPName pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.GetDouble(pname, @params); }
        internal override void tkgl2GetDouble(OpenTK.Graphics.OpenGL.GetPName pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.GetDouble(pname, out @params); }
        internal override unsafe void tkgl3GetDouble(OpenTK.Graphics.OpenGL.GetPName pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.GetDouble(pname, @params); }
        internal override OpenTK.Graphics.OpenGL.ErrorCode tkglGetError() { return OpenTK.Graphics.OpenGL.GL.GetError(); }
        internal override void tkglGetFloat(OpenTK.Graphics.OpenGL.GetPName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetFloat(pname, @params); }
        internal override void tkgl2GetFloat(OpenTK.Graphics.OpenGL.GetPName pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetFloat(pname, out @params); }
        internal override unsafe void tkgl3GetFloat(OpenTK.Graphics.OpenGL.GetPName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetFloat(pname, @params); }
        internal override Int32 tkglGetFragDataLocation(Int32 program, String name) { return OpenTK.Graphics.OpenGL.GL.GetFragDataLocation(program, name); }
        internal override Int32 tkgl2GetFragDataLocation(UInt32 program, String name) { return OpenTK.Graphics.OpenGL.GL.GetFragDataLocation(program, name); }
        internal override void tkglGetFramebufferAttachmentParameter(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.FramebufferParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetFramebufferAttachmentParameter(target, attachment, pname, @params); }
        internal override void tkgl2GetFramebufferAttachmentParameter(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.FramebufferParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetFramebufferAttachmentParameter(target, attachment, pname, out @params); }
        internal override unsafe void tkgl3GetFramebufferAttachmentParameter(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.FramebufferParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetFramebufferAttachmentParameter(target, attachment, pname, @params); }
        internal override void tkglGetHistogram(OpenTK.Graphics.OpenGL.HistogramTarget target, bool reset, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr values) { OpenTK.Graphics.OpenGL.GL.GetHistogram(target, reset, format, type, values); }
        internal override void tkglGetHistogramParameter(OpenTK.Graphics.OpenGL.HistogramTarget target, OpenTK.Graphics.OpenGL.GetHistogramParameterPName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetHistogramParameter(target, pname, @params); }
        internal override void tkgl2GetHistogramParameter(OpenTK.Graphics.OpenGL.HistogramTarget target, OpenTK.Graphics.OpenGL.GetHistogramParameterPName pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetHistogramParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetHistogramParameter(OpenTK.Graphics.OpenGL.HistogramTarget target, OpenTK.Graphics.OpenGL.GetHistogramParameterPName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetHistogramParameter(target, pname, @params); }
        internal override void tkgl4GetHistogramParameter(OpenTK.Graphics.OpenGL.HistogramTarget target, OpenTK.Graphics.OpenGL.GetHistogramParameterPName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetHistogramParameter(target, pname, @params); }
        internal override void tkgl5GetHistogramParameter(OpenTK.Graphics.OpenGL.HistogramTarget target, OpenTK.Graphics.OpenGL.GetHistogramParameterPName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetHistogramParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetHistogramParameter(OpenTK.Graphics.OpenGL.HistogramTarget target, OpenTK.Graphics.OpenGL.GetHistogramParameterPName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetHistogramParameter(target, pname, @params); }
        internal override void tkglGetInteger64(OpenTK.Graphics.OpenGL.Version32 target, Int32 index, Int64[] data) { OpenTK.Graphics.OpenGL.GL.GetInteger64(target, index, data); }
        internal override void tkgl2GetInteger64(OpenTK.Graphics.OpenGL.Version32 target, Int32 index, out Int64 data) { OpenTK.Graphics.OpenGL.GL.GetInteger64(target, index, out data); }
        internal override unsafe void tkgl3GetInteger64(OpenTK.Graphics.OpenGL.Version32 target, Int32 index, Int64* data) { OpenTK.Graphics.OpenGL.GL.GetInteger64(target, index, data); }
        internal override void tkgl4GetInteger64(OpenTK.Graphics.OpenGL.Version32 target, UInt32 index, Int64[] data) { OpenTK.Graphics.OpenGL.GL.GetInteger64(target, index, data); }
        internal override void tkgl5GetInteger64(OpenTK.Graphics.OpenGL.Version32 target, UInt32 index, out Int64 data) { OpenTK.Graphics.OpenGL.GL.GetInteger64(target, index, out data); }
        internal override unsafe void tkgl6GetInteger64(OpenTK.Graphics.OpenGL.Version32 target, UInt32 index, Int64* data) { OpenTK.Graphics.OpenGL.GL.GetInteger64(target, index, data); }
        internal override void tkgl7GetInteger64(OpenTK.Graphics.OpenGL.ArbSync pname, Int64[] @params) { OpenTK.Graphics.OpenGL.GL.GetInteger64(pname, @params); }
        internal override void tkgl8GetInteger64(OpenTK.Graphics.OpenGL.ArbSync pname, out Int64 @params) { OpenTK.Graphics.OpenGL.GL.GetInteger64(pname, out @params); }
        internal override unsafe void tkgl9GetInteger64(OpenTK.Graphics.OpenGL.ArbSync pname, Int64* @params) { OpenTK.Graphics.OpenGL.GL.GetInteger64(pname, @params); }
        internal override void tkglGetInteger(OpenTK.Graphics.OpenGL.GetIndexedPName target, Int32 index, Int32[] data) { OpenTK.Graphics.OpenGL.GL.GetInteger(target, index, data); }
        internal override void tkgl2GetInteger(OpenTK.Graphics.OpenGL.GetIndexedPName target, Int32 index, out Int32 data) { OpenTK.Graphics.OpenGL.GL.GetInteger(target, index, out data); }
        internal override unsafe void tkgl3GetInteger(OpenTK.Graphics.OpenGL.GetIndexedPName target, Int32 index, Int32* data) { OpenTK.Graphics.OpenGL.GL.GetInteger(target, index, data); }
        internal override void tkgl4GetInteger(OpenTK.Graphics.OpenGL.GetIndexedPName target, UInt32 index, Int32[] data) { OpenTK.Graphics.OpenGL.GL.GetInteger(target, index, data); }
        internal override void tkgl5GetInteger(OpenTK.Graphics.OpenGL.GetIndexedPName target, UInt32 index, out Int32 data) { OpenTK.Graphics.OpenGL.GL.GetInteger(target, index, out data); }
        internal override unsafe void tkgl6GetInteger(OpenTK.Graphics.OpenGL.GetIndexedPName target, UInt32 index, Int32* data) { OpenTK.Graphics.OpenGL.GL.GetInteger(target, index, data); }
        internal override void tkgl7GetInteger(OpenTK.Graphics.OpenGL.GetPName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetInteger(pname, @params); }
        internal override void tkgl8GetInteger(OpenTK.Graphics.OpenGL.GetPName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetInteger(pname, out @params); }
        internal override unsafe void tkgl9GetInteger(OpenTK.Graphics.OpenGL.GetPName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetInteger(pname, @params); }
        internal override void tkglGetLight(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetLight(light, pname, @params); }
        internal override void tkgl2GetLight(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetLight(light, pname, out @params); }
        internal override unsafe void tkgl3GetLight(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetLight(light, pname, @params); }
        internal override void tkgl4GetLight(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetLight(light, pname, @params); }
        internal override void tkgl5GetLight(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetLight(light, pname, out @params); }
        internal override unsafe void tkgl6GetLight(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetLight(light, pname, @params); }
        internal override void tkglGetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, Double[] v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, v); }
        internal override void tkgl2GetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, out Double v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, out v); }
        internal override unsafe void tkgl3GetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, Double* v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, v); }
        internal override void tkgl4GetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, Single[] v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, v); }
        internal override void tkgl5GetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, out Single v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, out v); }
        internal override unsafe void tkgl6GetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, Single* v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, v); }
        internal override void tkgl7GetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, Int32[] v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, v); }
        internal override void tkgl8GetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, out Int32 v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, out v); }
        internal override unsafe void tkgl9GetMap(OpenTK.Graphics.OpenGL.MapTarget target, OpenTK.Graphics.OpenGL.GetMapQuery query, Int32* v) { OpenTK.Graphics.OpenGL.GL.GetMap(target, query, v); }
        internal override void tkglGetMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetMaterial(face, pname, @params); }
        internal override void tkgl2GetMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetMaterial(face, pname, out @params); }
        internal override unsafe void tkgl3GetMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetMaterial(face, pname, @params); }
        internal override void tkgl4GetMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetMaterial(face, pname, @params); }
        internal override void tkgl5GetMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetMaterial(face, pname, out @params); }
        internal override unsafe void tkgl6GetMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetMaterial(face, pname, @params); }
        internal override void tkglGetMinmax(OpenTK.Graphics.OpenGL.MinmaxTarget target, bool reset, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr values) { OpenTK.Graphics.OpenGL.GL.GetMinmax(target, reset, format, type, values); }
        internal override void tkglGetMinmaxParameter(OpenTK.Graphics.OpenGL.MinmaxTarget target, OpenTK.Graphics.OpenGL.GetMinmaxParameterPName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetMinmaxParameter(target, pname, @params); }
        internal override void tkgl2GetMinmaxParameter(OpenTK.Graphics.OpenGL.MinmaxTarget target, OpenTK.Graphics.OpenGL.GetMinmaxParameterPName pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetMinmaxParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetMinmaxParameter(OpenTK.Graphics.OpenGL.MinmaxTarget target, OpenTK.Graphics.OpenGL.GetMinmaxParameterPName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetMinmaxParameter(target, pname, @params); }
        internal override void tkgl4GetMinmaxParameter(OpenTK.Graphics.OpenGL.MinmaxTarget target, OpenTK.Graphics.OpenGL.GetMinmaxParameterPName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetMinmaxParameter(target, pname, @params); }
        internal override void tkgl5GetMinmaxParameter(OpenTK.Graphics.OpenGL.MinmaxTarget target, OpenTK.Graphics.OpenGL.GetMinmaxParameterPName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetMinmaxParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetMinmaxParameter(OpenTK.Graphics.OpenGL.MinmaxTarget target, OpenTK.Graphics.OpenGL.GetMinmaxParameterPName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetMinmaxParameter(target, pname, @params); }
        internal override void tkglGetMultisample(OpenTK.Graphics.OpenGL.GetMultisamplePName pname, Int32 index, Single[] val) { OpenTK.Graphics.OpenGL.GL.GetMultisample(pname, index, val); }
        internal override void tkgl2GetMultisample(OpenTK.Graphics.OpenGL.GetMultisamplePName pname, Int32 index, out Single val) { OpenTK.Graphics.OpenGL.GL.GetMultisample(pname, index, out val); }
        internal override unsafe void tkgl3GetMultisample(OpenTK.Graphics.OpenGL.GetMultisamplePName pname, Int32 index, Single* val) { OpenTK.Graphics.OpenGL.GL.GetMultisample(pname, index, val); }
        internal override void tkgl4GetMultisample(OpenTK.Graphics.OpenGL.GetMultisamplePName pname, UInt32 index, Single[] val) { OpenTK.Graphics.OpenGL.GL.GetMultisample(pname, index, val); }
        internal override void tkgl5GetMultisample(OpenTK.Graphics.OpenGL.GetMultisamplePName pname, UInt32 index, out Single val) { OpenTK.Graphics.OpenGL.GL.GetMultisample(pname, index, out val); }
        internal override unsafe void tkgl6GetMultisample(OpenTK.Graphics.OpenGL.GetMultisamplePName pname, UInt32 index, Single* val) { OpenTK.Graphics.OpenGL.GL.GetMultisample(pname, index, val); }
        internal override void tkglGetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Single[] values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl2GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, out Single values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, out values); }
        internal override unsafe void tkgl3GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Single* values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl4GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32[] values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl5GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, out Int32 values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, out values); }
        internal override unsafe void tkgl6GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32* values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl7GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, UInt32[] values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl8GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, out UInt32 values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, out values); }
        internal override unsafe void tkgl9GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, UInt32* values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl10GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int16[] values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl11GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, out Int16 values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, out values); }
        internal override unsafe void tkgl12GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int16* values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl13GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, UInt16[] values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkgl14GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, out UInt16 values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, out values); }
        internal override unsafe void tkgl15GetPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, UInt16* values) { OpenTK.Graphics.OpenGL.GL.GetPixelMap(map, values); }
        internal override void tkglGetPointer(OpenTK.Graphics.OpenGL.GetPointervPName pname, IntPtr @params) { OpenTK.Graphics.OpenGL.GL.GetPointer(pname, @params); }
        internal override void tkglGetPolygonStipple(Byte[] mask) { OpenTK.Graphics.OpenGL.GL.GetPolygonStipple(mask); }
        internal override void tkgl2GetPolygonStipple(out Byte mask) { OpenTK.Graphics.OpenGL.GL.GetPolygonStipple(out mask); }
        internal override unsafe void tkgl3GetPolygonStipple(Byte* mask) { OpenTK.Graphics.OpenGL.GL.GetPolygonStipple(mask); }
        internal override void tkglGetProgramInfoLog(Int32 program, Int32 bufSize, out Int32 length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.GetProgramInfoLog(program, bufSize, out length, infoLog); }
        internal override unsafe void tkgl2GetProgramInfoLog(Int32 program, Int32 bufSize, Int32* length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.GetProgramInfoLog(program, bufSize, length, infoLog); }
        internal override void tkgl3GetProgramInfoLog(UInt32 program, Int32 bufSize, out Int32 length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.GetProgramInfoLog(program, bufSize, out length, infoLog); }
        internal override unsafe void tkgl4GetProgramInfoLog(UInt32 program, Int32 bufSize, Int32* length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.GetProgramInfoLog(program, bufSize, length, infoLog); }
        internal override void tkgl3GetProgram(Int32 program, OpenTK.Graphics.OpenGL.ProgramParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetProgram(program, pname, @params); }
        internal override void tkgl4GetProgram(Int32 program, OpenTK.Graphics.OpenGL.ProgramParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetProgram(program, pname, out @params); }
        internal override unsafe void tkgl5GetProgram(Int32 program, OpenTK.Graphics.OpenGL.ProgramParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetProgram(program, pname, @params); }
        internal override void tkgl6GetProgram(UInt32 program, OpenTK.Graphics.OpenGL.ProgramParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetProgram(program, pname, @params); }
        internal override void tkgl7GetProgram(UInt32 program, OpenTK.Graphics.OpenGL.ProgramParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetProgram(program, pname, out @params); }
        internal override unsafe void tkgl8GetProgram(UInt32 program, OpenTK.Graphics.OpenGL.ProgramParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetProgram(program, pname, @params); }
        internal override void tkgl4GetQuery(OpenTK.Graphics.OpenGL.QueryTarget target, OpenTK.Graphics.OpenGL.GetQueryParam pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetQuery(target, pname, @params); }
        internal override void tkgl5GetQuery(OpenTK.Graphics.OpenGL.QueryTarget target, OpenTK.Graphics.OpenGL.GetQueryParam pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetQuery(target, pname, out @params); }
        internal override unsafe void tkgl6GetQuery(OpenTK.Graphics.OpenGL.QueryTarget target, OpenTK.Graphics.OpenGL.GetQueryParam pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetQuery(target, pname, @params); }
        internal override void tkgl10GetQueryObject(Int32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, @params); }
        internal override void tkgl11GetQueryObject(Int32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, out @params); }
        internal override unsafe void tkgl12GetQueryObject(Int32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, @params); }
        internal override void tkgl13GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, @params); }
        internal override void tkgl14GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, out @params); }
        internal override unsafe void tkgl15GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, @params); }
        internal override void tkgl16GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, @params); }
        internal override void tkgl17GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, out @params); }
        internal override unsafe void tkgl18GetQueryObject(UInt32 id, OpenTK.Graphics.OpenGL.GetQueryObjectParam pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.GetQueryObject(id, pname, @params); }
        internal override void tkglGetRenderbufferParameter(OpenTK.Graphics.OpenGL.RenderbufferTarget target, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetRenderbufferParameter(target, pname, @params); }
        internal override void tkgl2GetRenderbufferParameter(OpenTK.Graphics.OpenGL.RenderbufferTarget target, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetRenderbufferParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetRenderbufferParameter(OpenTK.Graphics.OpenGL.RenderbufferTarget target, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetRenderbufferParameter(target, pname, @params); }
        internal override void tkglGetSeparableFilter(OpenTK.Graphics.OpenGL.SeparableTarget target, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr row, IntPtr column, IntPtr span) { OpenTK.Graphics.OpenGL.GL.GetSeparableFilter(target, format, type, row, column, span); }
        internal override void tkglGetShaderInfoLog(Int32 shader, Int32 bufSize, out Int32 length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.GetShaderInfoLog(shader, bufSize, out length, infoLog); }
        internal override unsafe void tkgl2GetShaderInfoLog(Int32 shader, Int32 bufSize, Int32* length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.GetShaderInfoLog(shader, bufSize, length, infoLog); }
        internal override void tkgl3GetShaderInfoLog(UInt32 shader, Int32 bufSize, out Int32 length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.GetShaderInfoLog(shader, bufSize, out length, infoLog); }
        internal override unsafe void tkgl4GetShaderInfoLog(UInt32 shader, Int32 bufSize, Int32* length, StringBuilder infoLog) { OpenTK.Graphics.OpenGL.GL.GetShaderInfoLog(shader, bufSize, length, infoLog); }
        internal override void tkglGetShader(Int32 shader, OpenTK.Graphics.OpenGL.ShaderParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetShader(shader, pname, @params); }
        internal override void tkgl2GetShader(Int32 shader, OpenTK.Graphics.OpenGL.ShaderParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetShader(shader, pname, out @params); }
        internal override unsafe void tkgl3GetShader(Int32 shader, OpenTK.Graphics.OpenGL.ShaderParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetShader(shader, pname, @params); }
        internal override void tkgl4GetShader(UInt32 shader, OpenTK.Graphics.OpenGL.ShaderParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetShader(shader, pname, @params); }
        internal override void tkgl5GetShader(UInt32 shader, OpenTK.Graphics.OpenGL.ShaderParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetShader(shader, pname, out @params); }
        internal override unsafe void tkgl6GetShader(UInt32 shader, OpenTK.Graphics.OpenGL.ShaderParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetShader(shader, pname, @params); }
        internal override void tkgl5GetShaderSource(Int32 shader, Int32 bufSize, out Int32 length, StringBuilder source) { OpenTK.Graphics.OpenGL.GL.GetShaderSource(shader, bufSize, out length, source); }
        internal override unsafe void tkgl6GetShaderSource(Int32 shader, Int32 bufSize, Int32* length, StringBuilder source) { OpenTK.Graphics.OpenGL.GL.GetShaderSource(shader, bufSize, length, source); }
        internal override void tkgl7GetShaderSource(UInt32 shader, Int32 bufSize, out Int32 length, StringBuilder source) { OpenTK.Graphics.OpenGL.GL.GetShaderSource(shader, bufSize, out length, source); }
        internal override unsafe void tkgl8GetShaderSource(UInt32 shader, Int32 bufSize, Int32* length, StringBuilder source) { OpenTK.Graphics.OpenGL.GL.GetShaderSource(shader, bufSize, length, source); }
        internal override System.String tkglGetString(OpenTK.Graphics.OpenGL.StringName name) { return OpenTK.Graphics.OpenGL.GL.GetString(name); }
        internal override System.String tkgl2GetString(OpenTK.Graphics.OpenGL.StringName name, Int32 index) { return OpenTK.Graphics.OpenGL.GL.GetString(name, index); }
        internal override System.String tkgl3GetString(OpenTK.Graphics.OpenGL.StringName name, UInt32 index) { return OpenTK.Graphics.OpenGL.GL.GetString(name, index); }
        internal override void tkglGetSync(IntPtr sync, OpenTK.Graphics.OpenGL.ArbSync pname, Int32 bufSize, out Int32 length, out Int32 values) { OpenTK.Graphics.OpenGL.GL.GetSync(sync, pname, bufSize, out length, out values); }
        internal override unsafe void tkgl2GetSync(IntPtr sync, OpenTK.Graphics.OpenGL.ArbSync pname, Int32 bufSize, Int32* length, Int32[] values) { OpenTK.Graphics.OpenGL.GL.GetSync(sync, pname, bufSize, length, values); }
        internal override unsafe void tkgl3GetSync(IntPtr sync, OpenTK.Graphics.OpenGL.ArbSync pname, Int32 bufSize, Int32* length, Int32* values) { OpenTK.Graphics.OpenGL.GL.GetSync(sync, pname, bufSize, length, values); }
        internal override void tkglGetTexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexEnv(target, pname, @params); }
        internal override void tkgl2GetTexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetTexEnv(target, pname, out @params); }
        internal override unsafe void tkgl3GetTexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetTexEnv(target, pname, @params); }
        internal override void tkgl4GetTexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexEnv(target, pname, @params); }
        internal override void tkgl5GetTexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetTexEnv(target, pname, out @params); }
        internal override unsafe void tkgl6GetTexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetTexEnv(target, pname, @params); }
        internal override void tkglGetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, @params); }
        internal override void tkgl2GetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, out @params); }
        internal override unsafe void tkgl3GetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, @params); }
        internal override void tkgl4GetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, @params); }
        internal override void tkgl5GetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, out @params); }
        internal override unsafe void tkgl6GetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, @params); }
        internal override void tkgl7GetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, @params); }
        internal override void tkgl8GetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, out @params); }
        internal override unsafe void tkgl9GetTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetTexGen(coord, pname, @params); }
        internal override void tkglGetTexImage(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.GetTexImage(target, level, format, type, pixels); }
        internal override void tkglGetTexLevelParameter(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexLevelParameter(target, level, pname, @params); }
        internal override void tkgl2GetTexLevelParameter(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetTexLevelParameter(target, level, pname, out @params); }
        internal override unsafe void tkgl3GetTexLevelParameter(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetTexLevelParameter(target, level, pname, @params); }
        internal override void tkgl4GetTexLevelParameter(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexLevelParameter(target, level, pname, @params); }
        internal override void tkgl5GetTexLevelParameter(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetTexLevelParameter(target, level, pname, out @params); }
        internal override unsafe void tkgl6GetTexLevelParameter(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetTexLevelParameter(target, level, pname, @params); }
        internal override void tkglGetTexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameter(target, pname, @params); }
        internal override void tkgl2GetTexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetTexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameter(target, pname, @params); }
        internal override void tkglGetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameterI(target, pname, @params); }
        internal override void tkgl2GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameterI(target, pname, out @params); }
        internal override unsafe void tkgl3GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameterI(target, pname, @params); }
        internal override void tkgl4GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameterI(target, pname, @params); }
        internal override void tkgl5GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameterI(target, pname, out @params); }
        internal override unsafe void tkgl6GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameterI(target, pname, @params); }
        internal override void tkgl4GetTexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameter(target, pname, @params); }
        internal override void tkgl5GetTexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetTexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetTexParameter(target, pname, @params); }
        internal override void tkglGetTransformFeedbackVarying(Int32 program, Int32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ActiveAttribType type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetTransformFeedbackVarying(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl2GetTransformFeedbackVarying(Int32 program, Int32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ActiveAttribType* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetTransformFeedbackVarying(program, index, bufSize, length, size, type, name); }
        internal override void tkgl3GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ActiveAttribType type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetTransformFeedbackVarying(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl4GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ActiveAttribType* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.GetTransformFeedbackVarying(program, index, bufSize, length, size, type, name); }
        internal override Int32 tkglGetUniformBlockIndex(Int32 program, String uniformBlockName) { return OpenTK.Graphics.OpenGL.GL.GetUniformBlockIndex(program, uniformBlockName); }
        internal override Int32 tkgl2GetUniformBlockIndex(UInt32 program, String uniformBlockName) { return OpenTK.Graphics.OpenGL.GL.GetUniformBlockIndex(program, uniformBlockName); }
        internal override void tkgl13GetUniform(Int32 program, Int32 location, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkgl14GetUniform(Int32 program, Int32 location, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, out @params); }
        internal override unsafe void tkgl15GetUniform(Int32 program, Int32 location, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkgl16GetUniform(UInt32 program, Int32 location, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkgl17GetUniform(UInt32 program, Int32 location, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, out @params); }
        internal override unsafe void tkgl18GetUniform(UInt32 program, Int32 location, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkglGetUniformIndices(Int32 program, Int32 uniformCount, String[] uniformNames, Int32[] uniformIndices) { OpenTK.Graphics.OpenGL.GL.GetUniformIndices(program, uniformCount, uniformNames, uniformIndices); }
        internal override void tkgl2GetUniformIndices(Int32 program, Int32 uniformCount, String[] uniformNames, out Int32 uniformIndices) { OpenTK.Graphics.OpenGL.GL.GetUniformIndices(program, uniformCount, uniformNames, out uniformIndices); }
        internal override unsafe void tkgl3GetUniformIndices(Int32 program, Int32 uniformCount, String[] uniformNames, Int32* uniformIndices) { OpenTK.Graphics.OpenGL.GL.GetUniformIndices(program, uniformCount, uniformNames, uniformIndices); }
        internal override void tkgl4GetUniformIndices(UInt32 program, Int32 uniformCount, String[] uniformNames, UInt32[] uniformIndices) { OpenTK.Graphics.OpenGL.GL.GetUniformIndices(program, uniformCount, uniformNames, uniformIndices); }
        internal override void tkgl5GetUniformIndices(UInt32 program, Int32 uniformCount, String[] uniformNames, out UInt32 uniformIndices) { OpenTK.Graphics.OpenGL.GL.GetUniformIndices(program, uniformCount, uniformNames, out uniformIndices); }
        internal override unsafe void tkgl6GetUniformIndices(UInt32 program, Int32 uniformCount, String[] uniformNames, UInt32* uniformIndices) { OpenTK.Graphics.OpenGL.GL.GetUniformIndices(program, uniformCount, uniformNames, uniformIndices); }
        internal override void tkgl19GetUniform(Int32 program, Int32 location, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkgl20GetUniform(Int32 program, Int32 location, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, out @params); }
        internal override unsafe void tkgl21GetUniform(Int32 program, Int32 location, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkgl22GetUniform(UInt32 program, Int32 location, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkgl23GetUniform(UInt32 program, Int32 location, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, out @params); }
        internal override unsafe void tkgl24GetUniform(UInt32 program, Int32 location, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override Int32 tkgl3GetUniformLocation(Int32 program, String name) { return OpenTK.Graphics.OpenGL.GL.GetUniformLocation(program, name); }
        internal override Int32 tkgl4GetUniformLocation(UInt32 program, String name) { return OpenTK.Graphics.OpenGL.GL.GetUniformLocation(program, name); }
        internal override void tkgl25GetUniform(UInt32 program, Int32 location, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkgl26GetUniform(UInt32 program, Int32 location, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, out @params); }
        internal override unsafe void tkgl27GetUniform(UInt32 program, Int32 location, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.GetUniform(program, location, @params); }
        internal override void tkgl19GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl20GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl21GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl22GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl23GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl24GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl25GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl26GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl27GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl28GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl29GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl30GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkglGetVertexAttribI(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttribI(index, pname, out @params); }
        internal override unsafe void tkgl2GetVertexAttribI(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttribI(index, pname, @params); }
        internal override void tkgl3GetVertexAttribI(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttribI(index, pname, out @params); }
        internal override unsafe void tkgl4GetVertexAttribI(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttribI(index, pname, @params); }
        internal override void tkgl5GetVertexAttribI(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttribI(index, pname, out @params); }
        internal override unsafe void tkgl6GetVertexAttribI(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttribI(index, pname, @params); }
        internal override void tkgl31GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl32GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl33GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl34GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl35GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl36GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl3GetVertexAttribPointer(Int32 index, OpenTK.Graphics.OpenGL.VertexAttribPointerParameter pname, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.GetVertexAttribPointer(index, pname, pointer); }
        internal override void tkgl4GetVertexAttribPointer(UInt32 index, OpenTK.Graphics.OpenGL.VertexAttribPointerParameter pname, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.GetVertexAttribPointer(index, pname, pointer); }
        internal override void tkglHint(OpenTK.Graphics.OpenGL.HintTarget target, OpenTK.Graphics.OpenGL.HintMode mode) { OpenTK.Graphics.OpenGL.GL.Hint(target, mode); }
        internal override void tkglHistogram(OpenTK.Graphics.OpenGL.HistogramTarget target, Int32 width, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, bool sink) { OpenTK.Graphics.OpenGL.GL.Histogram(target, width, internalformat, sink); }
        internal override void tkglIndex(Double c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override unsafe void tkgl2Index(Double* c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override void tkgl3Index(Single c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override unsafe void tkgl4Index(Single* c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override void tkgl5Index(Int32 c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override unsafe void tkgl6Index(Int32* c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override void tkglIndexMask(Int32 mask) { OpenTK.Graphics.OpenGL.GL.IndexMask(mask); }
        internal override void tkgl2IndexMask(UInt32 mask) { OpenTK.Graphics.OpenGL.GL.IndexMask(mask); }
        internal override void tkglIndexPointer(OpenTK.Graphics.OpenGL.IndexPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.IndexPointer(type, stride, pointer); }
        internal override void tkgl7Index(Int16 c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override unsafe void tkgl8Index(Int16* c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override void tkgl9Index(Byte c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override unsafe void tkgl10Index(Byte* c) { OpenTK.Graphics.OpenGL.GL.Index(c); }
        internal override void tkglInitNames() { OpenTK.Graphics.OpenGL.GL.InitNames(); }
        internal override void tkglInterleavedArrays(OpenTK.Graphics.OpenGL.InterleavedArrayFormat format, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.InterleavedArrays(format, stride, pointer); }
        internal override bool tkgl3IsBuffer(Int32 buffer) { return OpenTK.Graphics.OpenGL.GL.IsBuffer(buffer); }
        internal override bool tkgl4IsBuffer(UInt32 buffer) { return OpenTK.Graphics.OpenGL.GL.IsBuffer(buffer); }
        internal override bool tkglIsEnabled(OpenTK.Graphics.OpenGL.EnableCap cap) { return OpenTK.Graphics.OpenGL.GL.IsEnabled(cap); }
        internal override bool tkgl2IsEnabled(OpenTK.Graphics.OpenGL.IndexedEnableCap target, Int32 index) { return OpenTK.Graphics.OpenGL.GL.IsEnabled(target, index); }
        internal override bool tkgl3IsEnabled(OpenTK.Graphics.OpenGL.IndexedEnableCap target, UInt32 index) { return OpenTK.Graphics.OpenGL.GL.IsEnabled(target, index); }
        internal override bool tkglIsFramebuffer(Int32 framebuffer) { return OpenTK.Graphics.OpenGL.GL.IsFramebuffer(framebuffer); }
        internal override bool tkgl2IsFramebuffer(UInt32 framebuffer) { return OpenTK.Graphics.OpenGL.GL.IsFramebuffer(framebuffer); }
        internal override bool tkglIsList(Int32 list) { return OpenTK.Graphics.OpenGL.GL.IsList(list); }
        internal override bool tkgl2IsList(UInt32 list) { return OpenTK.Graphics.OpenGL.GL.IsList(list); }
        internal override bool tkgl3IsProgram(Int32 program) { return OpenTK.Graphics.OpenGL.GL.IsProgram(program); }
        internal override bool tkgl4IsProgram(UInt32 program) { return OpenTK.Graphics.OpenGL.GL.IsProgram(program); }
        internal override bool tkgl3IsQuery(Int32 id) { return OpenTK.Graphics.OpenGL.GL.IsQuery(id); }
        internal override bool tkgl4IsQuery(UInt32 id) { return OpenTK.Graphics.OpenGL.GL.IsQuery(id); }
        internal override bool tkglIsRenderbuffer(Int32 renderbuffer) { return OpenTK.Graphics.OpenGL.GL.IsRenderbuffer(renderbuffer); }
        internal override bool tkgl2IsRenderbuffer(UInt32 renderbuffer) { return OpenTK.Graphics.OpenGL.GL.IsRenderbuffer(renderbuffer); }
        internal override bool tkglIsShader(Int32 shader) { return OpenTK.Graphics.OpenGL.GL.IsShader(shader); }
        internal override bool tkgl2IsShader(UInt32 shader) { return OpenTK.Graphics.OpenGL.GL.IsShader(shader); }
        internal override bool tkglIsSync(IntPtr sync) { return OpenTK.Graphics.OpenGL.GL.IsSync(sync); }
        internal override bool tkglIsTexture(Int32 texture) { return OpenTK.Graphics.OpenGL.GL.IsTexture(texture); }
        internal override bool tkgl2IsTexture(UInt32 texture) { return OpenTK.Graphics.OpenGL.GL.IsTexture(texture); }
        internal override bool tkgl3IsVertexArray(Int32 array) { return OpenTK.Graphics.OpenGL.GL.IsVertexArray(array); }
        internal override bool tkgl4IsVertexArray(UInt32 array) { return OpenTK.Graphics.OpenGL.GL.IsVertexArray(array); }
        internal override void tkglLight(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.Light(light, pname, param); }
        internal override void tkgl2Light(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Light(light, pname, @params); }
        internal override unsafe void tkgl3Light(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Light(light, pname, @params); }
        internal override void tkgl4Light(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Light(light, pname, param); }
        internal override void tkgl5Light(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Light(light, pname, @params); }
        internal override unsafe void tkgl6Light(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Light(light, pname, @params); }
        internal override void tkglLightModel(OpenTK.Graphics.OpenGL.LightModelParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.LightModel(pname, param); }
        internal override void tkgl2LightModel(OpenTK.Graphics.OpenGL.LightModelParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.LightModel(pname, @params); }
        internal override unsafe void tkgl3LightModel(OpenTK.Graphics.OpenGL.LightModelParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.LightModel(pname, @params); }
        internal override void tkgl4LightModel(OpenTK.Graphics.OpenGL.LightModelParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.LightModel(pname, param); }
        internal override void tkgl5LightModel(OpenTK.Graphics.OpenGL.LightModelParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.LightModel(pname, @params); }
        internal override unsafe void tkgl6LightModel(OpenTK.Graphics.OpenGL.LightModelParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.LightModel(pname, @params); }
        internal override void tkglLineStipple(Int32 factor, Int16 pattern) { OpenTK.Graphics.OpenGL.GL.LineStipple(factor, pattern); }
        internal override void tkgl2LineStipple(Int32 factor, UInt16 pattern) { OpenTK.Graphics.OpenGL.GL.LineStipple(factor, pattern); }
        internal override void tkglLineWidth(Single width) { OpenTK.Graphics.OpenGL.GL.LineWidth(width); }
        internal override void tkgl3LinkProgram(Int32 program) { OpenTK.Graphics.OpenGL.GL.LinkProgram(program); }
        internal override void tkgl4LinkProgram(UInt32 program) { OpenTK.Graphics.OpenGL.GL.LinkProgram(program); }
        internal override void tkglListBase(Int32 @base) { OpenTK.Graphics.OpenGL.GL.ListBase(@base); }
        internal override void tkgl2ListBase(UInt32 @base) { OpenTK.Graphics.OpenGL.GL.ListBase(@base); }
        internal override void tkglLoadIdentity() { OpenTK.Graphics.OpenGL.GL.LoadIdentity(); }
        internal override void tkglLoadMatrix(Double[] m) { OpenTK.Graphics.OpenGL.GL.LoadMatrix(m); }
        internal override void tkgl2LoadMatrix(ref Double m) { OpenTK.Graphics.OpenGL.GL.LoadMatrix(ref m); }
        internal override unsafe void tkgl3LoadMatrix(Double* m) { OpenTK.Graphics.OpenGL.GL.LoadMatrix(m); }
        internal override void tkgl4LoadMatrix(Single[] m) { OpenTK.Graphics.OpenGL.GL.LoadMatrix(m); }
        internal override void tkgl5LoadMatrix(ref Single m) { OpenTK.Graphics.OpenGL.GL.LoadMatrix(ref m); }
        internal override unsafe void tkgl6LoadMatrix(Single* m) { OpenTK.Graphics.OpenGL.GL.LoadMatrix(m); }
        internal override void tkglLoadName(Int32 name) { OpenTK.Graphics.OpenGL.GL.LoadName(name); }
        internal override void tkgl2LoadName(UInt32 name) { OpenTK.Graphics.OpenGL.GL.LoadName(name); }
        internal override void tkgl7LoadTransposeMatrix(Double[] m) { OpenTK.Graphics.OpenGL.GL.LoadTransposeMatrix(m); }
        internal override void tkgl8LoadTransposeMatrix(ref Double m) { OpenTK.Graphics.OpenGL.GL.LoadTransposeMatrix(ref m); }
        internal override unsafe void tkgl9LoadTransposeMatrix(Double* m) { OpenTK.Graphics.OpenGL.GL.LoadTransposeMatrix(m); }
        internal override void tkgl10LoadTransposeMatrix(Single[] m) { OpenTK.Graphics.OpenGL.GL.LoadTransposeMatrix(m); }
        internal override void tkgl11LoadTransposeMatrix(ref Single m) { OpenTK.Graphics.OpenGL.GL.LoadTransposeMatrix(ref m); }
        internal override unsafe void tkgl12LoadTransposeMatrix(Single* m) { OpenTK.Graphics.OpenGL.GL.LoadTransposeMatrix(m); }
        internal override void tkglLogicOp(OpenTK.Graphics.OpenGL.LogicOp opcode) { OpenTK.Graphics.OpenGL.GL.LogicOp(opcode); }
        internal override void tkglMap1(OpenTK.Graphics.OpenGL.MapTarget target, Double u1, Double u2, Int32 stride, Int32 order, Double[] points) { OpenTK.Graphics.OpenGL.GL.Map1(target, u1, u2, stride, order, points); }
        internal override void tkgl2Map1(OpenTK.Graphics.OpenGL.MapTarget target, Double u1, Double u2, Int32 stride, Int32 order, ref Double points) { OpenTK.Graphics.OpenGL.GL.Map1(target, u1, u2, stride, order, ref points); }
        internal override unsafe void tkgl3Map1(OpenTK.Graphics.OpenGL.MapTarget target, Double u1, Double u2, Int32 stride, Int32 order, Double* points) { OpenTK.Graphics.OpenGL.GL.Map1(target, u1, u2, stride, order, points); }
        internal override void tkgl4Map1(OpenTK.Graphics.OpenGL.MapTarget target, Single u1, Single u2, Int32 stride, Int32 order, Single[] points) { OpenTK.Graphics.OpenGL.GL.Map1(target, u1, u2, stride, order, points); }
        internal override void tkgl5Map1(OpenTK.Graphics.OpenGL.MapTarget target, Single u1, Single u2, Int32 stride, Int32 order, ref Single points) { OpenTK.Graphics.OpenGL.GL.Map1(target, u1, u2, stride, order, ref points); }
        internal override unsafe void tkgl6Map1(OpenTK.Graphics.OpenGL.MapTarget target, Single u1, Single u2, Int32 stride, Int32 order, Single* points) { OpenTK.Graphics.OpenGL.GL.Map1(target, u1, u2, stride, order, points); }
        internal override void tkglMap2(OpenTK.Graphics.OpenGL.MapTarget target, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double[] points) { OpenTK.Graphics.OpenGL.GL.Map2(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl2Map2(OpenTK.Graphics.OpenGL.MapTarget target, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, ref Double points) { OpenTK.Graphics.OpenGL.GL.Map2(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, ref points); }
        internal override unsafe void tkgl3Map2(OpenTK.Graphics.OpenGL.MapTarget target, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double* points) { OpenTK.Graphics.OpenGL.GL.Map2(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl4Map2(OpenTK.Graphics.OpenGL.MapTarget target, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single[] points) { OpenTK.Graphics.OpenGL.GL.Map2(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override void tkgl5Map2(OpenTK.Graphics.OpenGL.MapTarget target, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, ref Single points) { OpenTK.Graphics.OpenGL.GL.Map2(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, ref points); }
        internal override unsafe void tkgl6Map2(OpenTK.Graphics.OpenGL.MapTarget target, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single* points) { OpenTK.Graphics.OpenGL.GL.Map2(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points); }
        internal override unsafe System.IntPtr tkgl2MapBuffer(OpenTK.Graphics.OpenGL.BufferTarget target, OpenTK.Graphics.OpenGL.BufferAccess access) { return OpenTK.Graphics.OpenGL.GL.MapBuffer(target, access); }
        internal override unsafe System.IntPtr tkglMapBufferRange(OpenTK.Graphics.OpenGL.BufferTarget target, IntPtr offset, IntPtr length, OpenTK.Graphics.OpenGL.BufferAccessMask access) { return OpenTK.Graphics.OpenGL.GL.MapBufferRange(target, offset, length, access); }
        internal override void tkglMapGrid1(Int32 un, Double u1, Double u2) { OpenTK.Graphics.OpenGL.GL.MapGrid1(un, u1, u2); }
        internal override void tkgl2MapGrid1(Int32 un, Single u1, Single u2) { OpenTK.Graphics.OpenGL.GL.MapGrid1(un, u1, u2); }
        internal override void tkglMapGrid2(Int32 un, Double u1, Double u2, Int32 vn, Double v1, Double v2) { OpenTK.Graphics.OpenGL.GL.MapGrid2(un, u1, u2, vn, v1, v2); }
        internal override void tkgl2MapGrid2(Int32 un, Single u1, Single u2, Int32 vn, Single v1, Single v2) { OpenTK.Graphics.OpenGL.GL.MapGrid2(un, u1, u2, vn, v1, v2); }
        internal override void tkglMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.Material(face, pname, param); }
        internal override void tkgl2Material(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Material(face, pname, @params); }
        internal override unsafe void tkgl3Material(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Material(face, pname, @params); }
        internal override void tkgl4Material(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Material(face, pname, param); }
        internal override void tkgl5Material(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Material(face, pname, @params); }
        internal override unsafe void tkgl6Material(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Material(face, pname, @params); }
        internal override void tkglMatrixMode(OpenTK.Graphics.OpenGL.MatrixMode mode) { OpenTK.Graphics.OpenGL.GL.MatrixMode(mode); }
        internal override void tkglMinmax(OpenTK.Graphics.OpenGL.MinmaxTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, bool sink) { OpenTK.Graphics.OpenGL.GL.Minmax(target, internalformat, sink); }
        internal override void tkglMinSampleShading(Single value) { OpenTK.Graphics.OpenGL.GL.MinSampleShading(value); }
        internal override void tkglMultiDrawArrays(OpenTK.Graphics.OpenGL.BeginMode mode, Int32[] first, Int32[] count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.MultiDrawArrays(mode, first, count, primcount); }
        internal override void tkgl2MultiDrawArrays(OpenTK.Graphics.OpenGL.BeginMode mode, out Int32 first, out Int32 count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.MultiDrawArrays(mode, out first, out count, primcount); }
        internal override unsafe void tkgl3MultiDrawArrays(OpenTK.Graphics.OpenGL.BeginMode mode, Int32* first, Int32* count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.MultiDrawArrays(mode, first, count, primcount); }
        internal override void tkglMultiDrawElements(OpenTK.Graphics.OpenGL.BeginMode mode, Int32[] count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.MultiDrawElements(mode, count, type, indices, primcount); }
        internal override void tkgl2MultiDrawElements(OpenTK.Graphics.OpenGL.BeginMode mode, ref Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.MultiDrawElements(mode, ref count, type, indices, primcount); }
        internal override unsafe void tkgl3MultiDrawElements(OpenTK.Graphics.OpenGL.BeginMode mode, Int32* count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.MultiDrawElements(mode, count, type, indices, primcount); }
        internal override void tkglMultiDrawElementsBaseVertex(OpenTK.Graphics.OpenGL.BeginMode mode, Int32[] count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32[] basevertex) { OpenTK.Graphics.OpenGL.GL.MultiDrawElementsBaseVertex(mode, count, type, indices, primcount, basevertex); }
        internal override void tkgl2MultiDrawElementsBaseVertex(OpenTK.Graphics.OpenGL.BeginMode mode, ref Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, ref Int32 basevertex) { OpenTK.Graphics.OpenGL.GL.MultiDrawElementsBaseVertex(mode, ref count, type, indices, primcount, ref basevertex); }
        internal override unsafe void tkgl3MultiDrawElementsBaseVertex(OpenTK.Graphics.OpenGL.BeginMode mode, Int32* count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32* basevertex) { OpenTK.Graphics.OpenGL.GL.MultiDrawElementsBaseVertex(mode, count, type, indices, primcount, basevertex); }
        internal override void tkgl9MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Double s) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord1(target, s); }
        internal override unsafe void tkgl10MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Double* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord1(target, v); }
        internal override void tkgl11MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Single s) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord1(target, s); }
        internal override unsafe void tkgl12MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Single* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord1(target, v); }
        internal override void tkgl13MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Int32 s) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord1(target, s); }
        internal override unsafe void tkgl14MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Int32* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord1(target, v); }
        internal override void tkgl15MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Int16 s) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord1(target, s); }
        internal override unsafe void tkgl16MultiTexCoord1(OpenTK.Graphics.OpenGL.TextureUnit target, Int16* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord1(target, v); }
        internal override void tkgl17MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Double s, Double t) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, s, t); }
        internal override void tkgl18MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Double[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, v); }
        internal override void tkgl19MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, ref Double v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, ref v); }
        internal override unsafe void tkgl20MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Double* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, v); }
        internal override void tkgl21MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Single s, Single t) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, s, t); }
        internal override void tkgl22MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Single[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, v); }
        internal override void tkgl23MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, ref Single v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, ref v); }
        internal override unsafe void tkgl24MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Single* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, v); }
        internal override void tkgl25MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int32 s, Int32 t) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, s, t); }
        internal override void tkgl26MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int32[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, v); }
        internal override void tkgl27MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, ref v); }
        internal override unsafe void tkgl28MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int32* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, v); }
        internal override void tkgl29MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int16 s, Int16 t) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, s, t); }
        internal override void tkgl30MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int16[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, v); }
        internal override void tkgl31MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, ref v); }
        internal override unsafe void tkgl32MultiTexCoord2(OpenTK.Graphics.OpenGL.TextureUnit target, Int16* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord2(target, v); }
        internal override void tkgl17MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Double s, Double t, Double r) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, s, t, r); }
        internal override void tkgl18MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Double[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, v); }
        internal override void tkgl19MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, ref Double v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, ref v); }
        internal override unsafe void tkgl20MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Double* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, v); }
        internal override void tkgl21MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Single s, Single t, Single r) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, s, t, r); }
        internal override void tkgl22MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Single[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, v); }
        internal override void tkgl23MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, ref Single v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, ref v); }
        internal override unsafe void tkgl24MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Single* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, v); }
        internal override void tkgl25MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int32 s, Int32 t, Int32 r) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, s, t, r); }
        internal override void tkgl26MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int32[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, v); }
        internal override void tkgl27MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, ref v); }
        internal override unsafe void tkgl28MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int32* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, v); }
        internal override void tkgl29MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int16 s, Int16 t, Int16 r) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, s, t, r); }
        internal override void tkgl30MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int16[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, v); }
        internal override void tkgl31MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, ref v); }
        internal override unsafe void tkgl32MultiTexCoord3(OpenTK.Graphics.OpenGL.TextureUnit target, Int16* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord3(target, v); }
        internal override void tkgl17MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Double s, Double t, Double r, Double q) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, s, t, r, q); }
        internal override void tkgl18MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Double[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, v); }
        internal override void tkgl19MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, ref Double v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, ref v); }
        internal override unsafe void tkgl20MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Double* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, v); }
        internal override void tkgl21MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Single s, Single t, Single r, Single q) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, s, t, r, q); }
        internal override void tkgl22MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Single[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, v); }
        internal override void tkgl23MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, ref Single v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, ref v); }
        internal override unsafe void tkgl24MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Single* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, v); }
        internal override void tkgl25MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int32 s, Int32 t, Int32 r, Int32 q) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, s, t, r, q); }
        internal override void tkgl26MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int32[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, v); }
        internal override void tkgl27MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, ref v); }
        internal override unsafe void tkgl28MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int32* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, v); }
        internal override void tkgl29MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int16 s, Int16 t, Int16 r, Int16 q) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, s, t, r, q); }
        internal override void tkgl30MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int16[] v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, v); }
        internal override void tkgl31MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, ref v); }
        internal override unsafe void tkgl32MultiTexCoord4(OpenTK.Graphics.OpenGL.TextureUnit target, Int16* v) { OpenTK.Graphics.OpenGL.GL.MultiTexCoord4(target, v); }
        internal override void tkglMultMatrix(Double[] m) { OpenTK.Graphics.OpenGL.GL.MultMatrix(m); }
        internal override void tkgl2MultMatrix(ref Double m) { OpenTK.Graphics.OpenGL.GL.MultMatrix(ref m); }
        internal override unsafe void tkgl3MultMatrix(Double* m) { OpenTK.Graphics.OpenGL.GL.MultMatrix(m); }
        internal override void tkgl4MultMatrix(Single[] m) { OpenTK.Graphics.OpenGL.GL.MultMatrix(m); }
        internal override void tkgl5MultMatrix(ref Single m) { OpenTK.Graphics.OpenGL.GL.MultMatrix(ref m); }
        internal override unsafe void tkgl6MultMatrix(Single* m) { OpenTK.Graphics.OpenGL.GL.MultMatrix(m); }
        internal override void tkgl7MultTransposeMatrix(Double[] m) { OpenTK.Graphics.OpenGL.GL.MultTransposeMatrix(m); }
        internal override void tkgl8MultTransposeMatrix(ref Double m) { OpenTK.Graphics.OpenGL.GL.MultTransposeMatrix(ref m); }
        internal override unsafe void tkgl9MultTransposeMatrix(Double* m) { OpenTK.Graphics.OpenGL.GL.MultTransposeMatrix(m); }
        internal override void tkgl10MultTransposeMatrix(Single[] m) { OpenTK.Graphics.OpenGL.GL.MultTransposeMatrix(m); }
        internal override void tkgl11MultTransposeMatrix(ref Single m) { OpenTK.Graphics.OpenGL.GL.MultTransposeMatrix(ref m); }
        internal override unsafe void tkgl12MultTransposeMatrix(Single* m) { OpenTK.Graphics.OpenGL.GL.MultTransposeMatrix(m); }
        internal override void tkglNewList(Int32 list, OpenTK.Graphics.OpenGL.ListMode mode) { OpenTK.Graphics.OpenGL.GL.NewList(list, mode); }
        internal override void tkgl2NewList(UInt32 list, OpenTK.Graphics.OpenGL.ListMode mode) { OpenTK.Graphics.OpenGL.GL.NewList(list, mode); }
        internal override void tkglNormal3(Byte nx, Byte ny, Byte nz) { OpenTK.Graphics.OpenGL.GL.Normal3(nx, ny, nz); }
        internal override void tkgl2Normal3(SByte nx, SByte ny, SByte nz) { OpenTK.Graphics.OpenGL.GL.Normal3(nx, ny, nz); }
        internal override void tkgl3Normal3(Byte[] v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl4Normal3(ref Byte v) { OpenTK.Graphics.OpenGL.GL.Normal3(ref v); }
        internal override unsafe void tkgl5Normal3(Byte* v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl6Normal3(SByte[] v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl7Normal3(ref SByte v) { OpenTK.Graphics.OpenGL.GL.Normal3(ref v); }
        internal override unsafe void tkgl8Normal3(SByte* v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl9Normal3(Double nx, Double ny, Double nz) { OpenTK.Graphics.OpenGL.GL.Normal3(nx, ny, nz); }
        internal override void tkgl10Normal3(Double[] v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl11Normal3(ref Double v) { OpenTK.Graphics.OpenGL.GL.Normal3(ref v); }
        internal override unsafe void tkgl12Normal3(Double* v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl13Normal3(Single nx, Single ny, Single nz) { OpenTK.Graphics.OpenGL.GL.Normal3(nx, ny, nz); }
        internal override void tkgl14Normal3(Single[] v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl15Normal3(ref Single v) { OpenTK.Graphics.OpenGL.GL.Normal3(ref v); }
        internal override unsafe void tkgl16Normal3(Single* v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl17Normal3(Int32 nx, Int32 ny, Int32 nz) { OpenTK.Graphics.OpenGL.GL.Normal3(nx, ny, nz); }
        internal override void tkgl18Normal3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl19Normal3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Normal3(ref v); }
        internal override unsafe void tkgl20Normal3(Int32* v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl21Normal3(Int16 nx, Int16 ny, Int16 nz) { OpenTK.Graphics.OpenGL.GL.Normal3(nx, ny, nz); }
        internal override void tkgl22Normal3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkgl23Normal3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Normal3(ref v); }
        internal override unsafe void tkgl24Normal3(Int16* v) { OpenTK.Graphics.OpenGL.GL.Normal3(v); }
        internal override void tkglNormalPointer(OpenTK.Graphics.OpenGL.NormalPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.NormalPointer(type, stride, pointer); }
        internal override void tkglOrtho(Double left, Double right, Double bottom, Double top, Double zNear, Double zFar) { OpenTK.Graphics.OpenGL.GL.Ortho(left, right, bottom, top, zNear, zFar); }
        internal override void tkglPassThrough(Single token) { OpenTK.Graphics.OpenGL.GL.PassThrough(token); }
        internal override void tkglPixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, Single[] values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl2PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, ref Single values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, ref values); }
        internal override unsafe void tkgl3PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, Single* values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl4PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, Int32[] values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl5PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, ref Int32 values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, ref values); }
        internal override unsafe void tkgl6PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, Int32* values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl7PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, UInt32[] values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl8PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, ref UInt32 values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, ref values); }
        internal override unsafe void tkgl9PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, UInt32* values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl10PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, Int16[] values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl11PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, ref Int16 values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, ref values); }
        internal override unsafe void tkgl12PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, Int16* values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl13PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, UInt16[] values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkgl14PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, ref UInt16 values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, ref values); }
        internal override unsafe void tkgl15PixelMap(OpenTK.Graphics.OpenGL.PixelMap map, Int32 mapsize, UInt16* values) { OpenTK.Graphics.OpenGL.GL.PixelMap(map, mapsize, values); }
        internal override void tkglPixelStore(OpenTK.Graphics.OpenGL.PixelStoreParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.PixelStore(pname, param); }
        internal override void tkgl2PixelStore(OpenTK.Graphics.OpenGL.PixelStoreParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.PixelStore(pname, param); }
        internal override void tkglPixelTransfer(OpenTK.Graphics.OpenGL.PixelTransferParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.PixelTransfer(pname, param); }
        internal override void tkgl2PixelTransfer(OpenTK.Graphics.OpenGL.PixelTransferParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.PixelTransfer(pname, param); }
        internal override void tkglPixelZoom(Single xfactor, Single yfactor) { OpenTK.Graphics.OpenGL.GL.PixelZoom(xfactor, yfactor); }
        internal override void tkgl4PointParameter(OpenTK.Graphics.OpenGL.PointParameterName pname, Single param) { OpenTK.Graphics.OpenGL.GL.PointParameter(pname, param); }
        internal override void tkgl5PointParameter(OpenTK.Graphics.OpenGL.PointParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.PointParameter(pname, @params); }
        internal override unsafe void tkgl6PointParameter(OpenTK.Graphics.OpenGL.PointParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.PointParameter(pname, @params); }
        internal override void tkgl7PointParameter(OpenTK.Graphics.OpenGL.PointParameterName pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.PointParameter(pname, param); }
        internal override void tkgl8PointParameter(OpenTK.Graphics.OpenGL.PointParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.PointParameter(pname, @params); }
        internal override unsafe void tkgl9PointParameter(OpenTK.Graphics.OpenGL.PointParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.PointParameter(pname, @params); }
        internal override void tkglPointSize(Single size) { OpenTK.Graphics.OpenGL.GL.PointSize(size); }
        internal override void tkglPolygonMode(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.PolygonMode mode) { OpenTK.Graphics.OpenGL.GL.PolygonMode(face, mode); }
        internal override void tkglPolygonOffset(Single factor, Single units) { OpenTK.Graphics.OpenGL.GL.PolygonOffset(factor, units); }
        internal override void tkglPolygonStipple(Byte[] mask) { OpenTK.Graphics.OpenGL.GL.PolygonStipple(mask); }
        internal override void tkgl2PolygonStipple(ref Byte mask) { OpenTK.Graphics.OpenGL.GL.PolygonStipple(ref mask); }
        internal override unsafe void tkgl3PolygonStipple(Byte* mask) { OpenTK.Graphics.OpenGL.GL.PolygonStipple(mask); }
        internal override void tkglPopAttrib() { OpenTK.Graphics.OpenGL.GL.PopAttrib(); }
        internal override void tkglPopClientAttrib() { OpenTK.Graphics.OpenGL.GL.PopClientAttrib(); }
        internal override void tkglPopMatrix() { OpenTK.Graphics.OpenGL.GL.PopMatrix(); }
        internal override void tkglPopName() { OpenTK.Graphics.OpenGL.GL.PopName(); }
        internal override void tkglPrimitiveRestartIndex(Int32 index) { OpenTK.Graphics.OpenGL.GL.PrimitiveRestartIndex(index); }
        internal override void tkgl2PrimitiveRestartIndex(UInt32 index) { OpenTK.Graphics.OpenGL.GL.PrimitiveRestartIndex(index); }
        internal override void tkglPrioritizeTextures(Int32 n, Int32[] textures, Single[] priorities) { OpenTK.Graphics.OpenGL.GL.PrioritizeTextures(n, textures, priorities); }
        internal override void tkgl2PrioritizeTextures(Int32 n, ref Int32 textures, ref Single priorities) { OpenTK.Graphics.OpenGL.GL.PrioritizeTextures(n, ref textures, ref priorities); }
        internal override unsafe void tkgl3PrioritizeTextures(Int32 n, Int32* textures, Single* priorities) { OpenTK.Graphics.OpenGL.GL.PrioritizeTextures(n, textures, priorities); }
        internal override void tkgl4PrioritizeTextures(Int32 n, UInt32[] textures, Single[] priorities) { OpenTK.Graphics.OpenGL.GL.PrioritizeTextures(n, textures, priorities); }
        internal override void tkgl5PrioritizeTextures(Int32 n, ref UInt32 textures, ref Single priorities) { OpenTK.Graphics.OpenGL.GL.PrioritizeTextures(n, ref textures, ref priorities); }
        internal override unsafe void tkgl6PrioritizeTextures(Int32 n, UInt32* textures, Single* priorities) { OpenTK.Graphics.OpenGL.GL.PrioritizeTextures(n, textures, priorities); }
        internal override void tkgl3ProgramParameter(Int32 program, OpenTK.Graphics.OpenGL.Version32 pname, Int32 value) { OpenTK.Graphics.OpenGL.GL.ProgramParameter(program, pname, value); }
        internal override void tkgl4ProgramParameter(UInt32 program, OpenTK.Graphics.OpenGL.Version32 pname, Int32 value) { OpenTK.Graphics.OpenGL.GL.ProgramParameter(program, pname, value); }
        internal override void tkglProvokingVertex(OpenTK.Graphics.OpenGL.ProvokingVertexMode mode) { OpenTK.Graphics.OpenGL.GL.ProvokingVertex(mode); }
        internal override void tkglPushAttrib(OpenTK.Graphics.OpenGL.AttribMask mask) { OpenTK.Graphics.OpenGL.GL.PushAttrib(mask); }
        internal override void tkglPushClientAttrib(OpenTK.Graphics.OpenGL.ClientAttribMask mask) { OpenTK.Graphics.OpenGL.GL.PushClientAttrib(mask); }
        internal override void tkglPushMatrix() { OpenTK.Graphics.OpenGL.GL.PushMatrix(); }
        internal override void tkglPushName(Int32 name) { OpenTK.Graphics.OpenGL.GL.PushName(name); }
        internal override void tkgl2PushName(UInt32 name) { OpenTK.Graphics.OpenGL.GL.PushName(name); }
        internal override void tkglRasterPos2(Double x, Double y) { OpenTK.Graphics.OpenGL.GL.RasterPos2(x, y); }
        internal override void tkgl2RasterPos2(Double[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(v); }
        internal override void tkgl3RasterPos2(ref Double v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(ref v); }
        internal override unsafe void tkgl4RasterPos2(Double* v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(v); }
        internal override void tkgl5RasterPos2(Single x, Single y) { OpenTK.Graphics.OpenGL.GL.RasterPos2(x, y); }
        internal override void tkgl6RasterPos2(Single[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(v); }
        internal override void tkgl7RasterPos2(ref Single v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(ref v); }
        internal override unsafe void tkgl8RasterPos2(Single* v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(v); }
        internal override void tkgl9RasterPos2(Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.RasterPos2(x, y); }
        internal override void tkgl10RasterPos2(Int32[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(v); }
        internal override void tkgl11RasterPos2(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(ref v); }
        internal override unsafe void tkgl12RasterPos2(Int32* v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(v); }
        internal override void tkgl13RasterPos2(Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.RasterPos2(x, y); }
        internal override void tkgl14RasterPos2(Int16[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(v); }
        internal override void tkgl15RasterPos2(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(ref v); }
        internal override unsafe void tkgl16RasterPos2(Int16* v) { OpenTK.Graphics.OpenGL.GL.RasterPos2(v); }
        internal override void tkglRasterPos3(Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.RasterPos3(x, y, z); }
        internal override void tkgl2RasterPos3(Double[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(v); }
        internal override void tkgl3RasterPos3(ref Double v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(ref v); }
        internal override unsafe void tkgl4RasterPos3(Double* v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(v); }
        internal override void tkgl5RasterPos3(Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.RasterPos3(x, y, z); }
        internal override void tkgl6RasterPos3(Single[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(v); }
        internal override void tkgl7RasterPos3(ref Single v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(ref v); }
        internal override unsafe void tkgl8RasterPos3(Single* v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(v); }
        internal override void tkgl9RasterPos3(Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.RasterPos3(x, y, z); }
        internal override void tkgl10RasterPos3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(v); }
        internal override void tkgl11RasterPos3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(ref v); }
        internal override unsafe void tkgl12RasterPos3(Int32* v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(v); }
        internal override void tkgl13RasterPos3(Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.RasterPos3(x, y, z); }
        internal override void tkgl14RasterPos3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(v); }
        internal override void tkgl15RasterPos3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(ref v); }
        internal override unsafe void tkgl16RasterPos3(Int16* v) { OpenTK.Graphics.OpenGL.GL.RasterPos3(v); }
        internal override void tkglRasterPos4(Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.RasterPos4(x, y, z, w); }
        internal override void tkgl2RasterPos4(Double[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(v); }
        internal override void tkgl3RasterPos4(ref Double v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(ref v); }
        internal override unsafe void tkgl4RasterPos4(Double* v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(v); }
        internal override void tkgl5RasterPos4(Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.RasterPos4(x, y, z, w); }
        internal override void tkgl6RasterPos4(Single[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(v); }
        internal override void tkgl7RasterPos4(ref Single v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(ref v); }
        internal override unsafe void tkgl8RasterPos4(Single* v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(v); }
        internal override void tkgl9RasterPos4(Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.RasterPos4(x, y, z, w); }
        internal override void tkgl10RasterPos4(Int32[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(v); }
        internal override void tkgl11RasterPos4(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(ref v); }
        internal override unsafe void tkgl12RasterPos4(Int32* v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(v); }
        internal override void tkgl13RasterPos4(Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.RasterPos4(x, y, z, w); }
        internal override void tkgl14RasterPos4(Int16[] v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(v); }
        internal override void tkgl15RasterPos4(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(ref v); }
        internal override unsafe void tkgl16RasterPos4(Int16* v) { OpenTK.Graphics.OpenGL.GL.RasterPos4(v); }
        internal override void tkglReadBuffer(OpenTK.Graphics.OpenGL.ReadBufferMode mode) { OpenTK.Graphics.OpenGL.GL.ReadBuffer(mode); }
        internal override void tkglReadPixels(Int32 x, Int32 y, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.ReadPixels(x, y, width, height, format, type, pixels); }
        internal override void tkglRect(Double x1, Double y1, Double x2, Double y2) { OpenTK.Graphics.OpenGL.GL.Rect(x1, y1, x2, y2); }
        internal override void tkgl2Rect(Double[] v1, Double[] v2) { OpenTK.Graphics.OpenGL.GL.Rect(v1, v2); }
        internal override void tkgl3Rect(ref Double v1, ref Double v2) { OpenTK.Graphics.OpenGL.GL.Rect(ref v1, ref v2); }
        internal override unsafe void tkgl4Rect(Double* v1, Double* v2) { OpenTK.Graphics.OpenGL.GL.Rect(v1, v2); }
        internal override void tkgl5Rect(Single x1, Single y1, Single x2, Single y2) { OpenTK.Graphics.OpenGL.GL.Rect(x1, y1, x2, y2); }
        internal override void tkgl6Rect(Single[] v1, Single[] v2) { OpenTK.Graphics.OpenGL.GL.Rect(v1, v2); }
        internal override void tkgl7Rect(ref Single v1, ref Single v2) { OpenTK.Graphics.OpenGL.GL.Rect(ref v1, ref v2); }
        internal override unsafe void tkgl8Rect(Single* v1, Single* v2) { OpenTK.Graphics.OpenGL.GL.Rect(v1, v2); }
        internal override void tkgl9Rect(Int32 x1, Int32 y1, Int32 x2, Int32 y2) { OpenTK.Graphics.OpenGL.GL.Rect(x1, y1, x2, y2); }
        internal override void tkgl10Rect(Int32[] v1, Int32[] v2) { OpenTK.Graphics.OpenGL.GL.Rect(v1, v2); }
        internal override void tkgl11Rect(ref Int32 v1, ref Int32 v2) { OpenTK.Graphics.OpenGL.GL.Rect(ref v1, ref v2); }
        internal override unsafe void tkgl12Rect(Int32* v1, Int32* v2) { OpenTK.Graphics.OpenGL.GL.Rect(v1, v2); }
        internal override void tkglRects(Int16 x1, Int16 y1, Int16 x2, Int16 y2) { OpenTK.Graphics.OpenGL.GL.Rects(x1, y1, x2, y2); }
        internal override void tkgl13Rect(Int16[] v1, Int16[] v2) { OpenTK.Graphics.OpenGL.GL.Rect(v1, v2); }
        internal override void tkgl14Rect(ref Int16 v1, ref Int16 v2) { OpenTK.Graphics.OpenGL.GL.Rect(ref v1, ref v2); }
        internal override unsafe void tkgl15Rect(Int16* v1, Int16* v2) { OpenTK.Graphics.OpenGL.GL.Rect(v1, v2); }
        internal override void tkglRenderbufferStorage(OpenTK.Graphics.OpenGL.RenderbufferTarget target, OpenTK.Graphics.OpenGL.RenderbufferStorage internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.RenderbufferStorage(target, internalformat, width, height); }
        internal override void tkglRenderbufferStorageMultisample(OpenTK.Graphics.OpenGL.RenderbufferTarget target, Int32 samples, OpenTK.Graphics.OpenGL.RenderbufferStorage internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.RenderbufferStorageMultisample(target, samples, internalformat, width, height); }
        internal override Int32 tkglRenderMode(OpenTK.Graphics.OpenGL.RenderingMode mode) { return OpenTK.Graphics.OpenGL.GL.RenderMode(mode); }
        internal override void tkglResetHistogram(OpenTK.Graphics.OpenGL.HistogramTarget target) { OpenTK.Graphics.OpenGL.GL.ResetHistogram(target); }
        internal override void tkglResetMinmax(OpenTK.Graphics.OpenGL.MinmaxTarget target) { OpenTK.Graphics.OpenGL.GL.ResetMinmax(target); }
        internal override void tkglRotate(Double angle, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Rotate(angle, x, y, z); }
        internal override void tkgl2Rotate(Single angle, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Rotate(angle, x, y, z); }
        internal override void tkgl2SampleCoverage(Single value, bool invert) { OpenTK.Graphics.OpenGL.GL.SampleCoverage(value, invert); }
        internal override void tkglSampleMask(Int32 index, Int32 mask) { OpenTK.Graphics.OpenGL.GL.SampleMask(index, mask); }
        internal override void tkgl2SampleMask(UInt32 index, UInt32 mask) { OpenTK.Graphics.OpenGL.GL.SampleMask(index, mask); }
        internal override void tkglScale(Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Scale(x, y, z); }
        internal override void tkgl2Scale(Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Scale(x, y, z); }
        internal override void tkglScissor(Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Scissor(x, y, width, height); }
        internal override void tkglSecondaryColor3(SByte red, SByte green, SByte blue) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(red, green, blue); }
        internal override void tkgl2SecondaryColor3(SByte[] v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl3SecondaryColor3(ref SByte v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(ref v); }
        internal override unsafe void tkgl4SecondaryColor3(SByte* v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl5SecondaryColor3(Double red, Double green, Double blue) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(red, green, blue); }
        internal override void tkgl6SecondaryColor3(Double[] v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl7SecondaryColor3(ref Double v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(ref v); }
        internal override unsafe void tkgl8SecondaryColor3(Double* v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl9SecondaryColor3(Single red, Single green, Single blue) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(red, green, blue); }
        internal override void tkgl10SecondaryColor3(Single[] v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl11SecondaryColor3(ref Single v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(ref v); }
        internal override unsafe void tkgl12SecondaryColor3(Single* v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl13SecondaryColor3(Int32 red, Int32 green, Int32 blue) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(red, green, blue); }
        internal override void tkgl14SecondaryColor3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl15SecondaryColor3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(ref v); }
        internal override unsafe void tkgl16SecondaryColor3(Int32* v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl17SecondaryColor3(Int16 red, Int16 green, Int16 blue) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(red, green, blue); }
        internal override void tkgl18SecondaryColor3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl19SecondaryColor3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(ref v); }
        internal override unsafe void tkgl20SecondaryColor3(Int16* v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl21SecondaryColor3(Byte red, Byte green, Byte blue) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(red, green, blue); }
        internal override void tkgl22SecondaryColor3(Byte[] v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl23SecondaryColor3(ref Byte v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(ref v); }
        internal override unsafe void tkgl24SecondaryColor3(Byte* v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl25SecondaryColor3(UInt32 red, UInt32 green, UInt32 blue) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(red, green, blue); }
        internal override void tkgl26SecondaryColor3(UInt32[] v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl27SecondaryColor3(ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(ref v); }
        internal override unsafe void tkgl28SecondaryColor3(UInt32* v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl29SecondaryColor3(UInt16 red, UInt16 green, UInt16 blue) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(red, green, blue); }
        internal override void tkgl30SecondaryColor3(UInt16[] v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkgl31SecondaryColor3(ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(ref v); }
        internal override unsafe void tkgl32SecondaryColor3(UInt16* v) { OpenTK.Graphics.OpenGL.GL.SecondaryColor3(v); }
        internal override void tkglSecondaryColorPointer(Int32 size, OpenTK.Graphics.OpenGL.ColorPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.SecondaryColorPointer(size, type, stride, pointer); }
        internal override void tkglSelectBuffer(Int32 size, Int32[] buffer) { OpenTK.Graphics.OpenGL.GL.SelectBuffer(size, buffer); }
        internal override void tkgl2SelectBuffer(Int32 size, out Int32 buffer) { OpenTK.Graphics.OpenGL.GL.SelectBuffer(size, out buffer); }
        internal override unsafe void tkgl3SelectBuffer(Int32 size, Int32* buffer) { OpenTK.Graphics.OpenGL.GL.SelectBuffer(size, buffer); }
        internal override void tkgl4SelectBuffer(Int32 size, UInt32[] buffer) { OpenTK.Graphics.OpenGL.GL.SelectBuffer(size, buffer); }
        internal override void tkgl5SelectBuffer(Int32 size, out UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.SelectBuffer(size, out buffer); }
        internal override unsafe void tkgl6SelectBuffer(Int32 size, UInt32* buffer) { OpenTK.Graphics.OpenGL.GL.SelectBuffer(size, buffer); }
        internal override void tkglSeparableFilter2D(OpenTK.Graphics.OpenGL.SeparableTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr row, IntPtr column) { OpenTK.Graphics.OpenGL.GL.SeparableFilter2D(target, internalformat, width, height, format, type, row, column); }
        internal override void tkglShadeModel(OpenTK.Graphics.OpenGL.ShadingModel mode) { OpenTK.Graphics.OpenGL.GL.ShadeModel(mode); }
        internal override void tkgl5ShaderSource(Int32 shader, Int32 count, String[] @string, ref Int32 length) { OpenTK.Graphics.OpenGL.GL.ShaderSource(shader, count, @string, ref length); }
        internal override unsafe void tkgl6ShaderSource(Int32 shader, Int32 count, String[] @string, Int32* length) { OpenTK.Graphics.OpenGL.GL.ShaderSource(shader, count, @string, length); }
        internal override void tkgl7ShaderSource(UInt32 shader, Int32 count, String[] @string, ref Int32 length) { OpenTK.Graphics.OpenGL.GL.ShaderSource(shader, count, @string, ref length); }
        internal override unsafe void tkgl8ShaderSource(UInt32 shader, Int32 count, String[] @string, Int32* length) { OpenTK.Graphics.OpenGL.GL.ShaderSource(shader, count, @string, length); }
        internal override void tkglStencilFunc(OpenTK.Graphics.OpenGL.StencilFunction func, Int32 @ref, Int32 mask) { OpenTK.Graphics.OpenGL.GL.StencilFunc(func, @ref, mask); }
        internal override void tkgl2StencilFunc(OpenTK.Graphics.OpenGL.StencilFunction func, Int32 @ref, UInt32 mask) { OpenTK.Graphics.OpenGL.GL.StencilFunc(func, @ref, mask); }
        internal override void tkgl3StencilFuncSeparate(OpenTK.Graphics.OpenGL.StencilFace face, OpenTK.Graphics.OpenGL.StencilFunction func, Int32 @ref, Int32 mask) { OpenTK.Graphics.OpenGL.GL.StencilFuncSeparate(face, func, @ref, mask); }
        internal override void tkgl4StencilFuncSeparate(OpenTK.Graphics.OpenGL.StencilFace face, OpenTK.Graphics.OpenGL.StencilFunction func, Int32 @ref, UInt32 mask) { OpenTK.Graphics.OpenGL.GL.StencilFuncSeparate(face, func, @ref, mask); }
        internal override void tkglStencilMask(Int32 mask) { OpenTK.Graphics.OpenGL.GL.StencilMask(mask); }
        internal override void tkgl2StencilMask(UInt32 mask) { OpenTK.Graphics.OpenGL.GL.StencilMask(mask); }
        internal override void tkglStencilMaskSeparate(OpenTK.Graphics.OpenGL.StencilFace face, Int32 mask) { OpenTK.Graphics.OpenGL.GL.StencilMaskSeparate(face, mask); }
        internal override void tkgl2StencilMaskSeparate(OpenTK.Graphics.OpenGL.StencilFace face, UInt32 mask) { OpenTK.Graphics.OpenGL.GL.StencilMaskSeparate(face, mask); }
        internal override void tkglStencilOp(OpenTK.Graphics.OpenGL.StencilOp fail, OpenTK.Graphics.OpenGL.StencilOp zfail, OpenTK.Graphics.OpenGL.StencilOp zpass) { OpenTK.Graphics.OpenGL.GL.StencilOp(fail, zfail, zpass); }
        internal override void tkgl2StencilOpSeparate(OpenTK.Graphics.OpenGL.StencilFace face, OpenTK.Graphics.OpenGL.StencilOp sfail, OpenTK.Graphics.OpenGL.StencilOp dpfail, OpenTK.Graphics.OpenGL.StencilOp dppass) { OpenTK.Graphics.OpenGL.GL.StencilOpSeparate(face, sfail, dpfail, dppass); }
        internal override void tkgl3TexBuffer(OpenTK.Graphics.OpenGL.TextureBufferTarget target, OpenTK.Graphics.OpenGL.SizedInternalFormat internalformat, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.TexBuffer(target, internalformat, buffer); }
        internal override void tkgl4TexBuffer(OpenTK.Graphics.OpenGL.TextureBufferTarget target, OpenTK.Graphics.OpenGL.SizedInternalFormat internalformat, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.TexBuffer(target, internalformat, buffer); }
        internal override void tkglTexCoord1(Double s) { OpenTK.Graphics.OpenGL.GL.TexCoord1(s); }
        internal override unsafe void tkgl2TexCoord1(Double* v) { OpenTK.Graphics.OpenGL.GL.TexCoord1(v); }
        internal override void tkgl3TexCoord1(Single s) { OpenTK.Graphics.OpenGL.GL.TexCoord1(s); }
        internal override unsafe void tkgl4TexCoord1(Single* v) { OpenTK.Graphics.OpenGL.GL.TexCoord1(v); }
        internal override void tkgl5TexCoord1(Int32 s) { OpenTK.Graphics.OpenGL.GL.TexCoord1(s); }
        internal override unsafe void tkgl6TexCoord1(Int32* v) { OpenTK.Graphics.OpenGL.GL.TexCoord1(v); }
        internal override void tkgl7TexCoord1(Int16 s) { OpenTK.Graphics.OpenGL.GL.TexCoord1(s); }
        internal override unsafe void tkgl8TexCoord1(Int16* v) { OpenTK.Graphics.OpenGL.GL.TexCoord1(v); }
        internal override void tkglTexCoord2(Double s, Double t) { OpenTK.Graphics.OpenGL.GL.TexCoord2(s, t); }
        internal override void tkgl2TexCoord2(Double[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(v); }
        internal override void tkgl3TexCoord2(ref Double v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(ref v); }
        internal override unsafe void tkgl4TexCoord2(Double* v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(v); }
        internal override void tkgl5TexCoord2(Single s, Single t) { OpenTK.Graphics.OpenGL.GL.TexCoord2(s, t); }
        internal override void tkgl6TexCoord2(Single[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(v); }
        internal override void tkgl7TexCoord2(ref Single v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(ref v); }
        internal override unsafe void tkgl8TexCoord2(Single* v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(v); }
        internal override void tkgl9TexCoord2(Int32 s, Int32 t) { OpenTK.Graphics.OpenGL.GL.TexCoord2(s, t); }
        internal override void tkgl10TexCoord2(Int32[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(v); }
        internal override void tkgl11TexCoord2(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(ref v); }
        internal override unsafe void tkgl12TexCoord2(Int32* v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(v); }
        internal override void tkgl13TexCoord2(Int16 s, Int16 t) { OpenTK.Graphics.OpenGL.GL.TexCoord2(s, t); }
        internal override void tkgl14TexCoord2(Int16[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(v); }
        internal override void tkgl15TexCoord2(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(ref v); }
        internal override unsafe void tkgl16TexCoord2(Int16* v) { OpenTK.Graphics.OpenGL.GL.TexCoord2(v); }
        internal override void tkglTexCoord3(Double s, Double t, Double r) { OpenTK.Graphics.OpenGL.GL.TexCoord3(s, t, r); }
        internal override void tkgl2TexCoord3(Double[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(v); }
        internal override void tkgl3TexCoord3(ref Double v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(ref v); }
        internal override unsafe void tkgl4TexCoord3(Double* v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(v); }
        internal override void tkgl5TexCoord3(Single s, Single t, Single r) { OpenTK.Graphics.OpenGL.GL.TexCoord3(s, t, r); }
        internal override void tkgl6TexCoord3(Single[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(v); }
        internal override void tkgl7TexCoord3(ref Single v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(ref v); }
        internal override unsafe void tkgl8TexCoord3(Single* v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(v); }
        internal override void tkgl9TexCoord3(Int32 s, Int32 t, Int32 r) { OpenTK.Graphics.OpenGL.GL.TexCoord3(s, t, r); }
        internal override void tkgl10TexCoord3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(v); }
        internal override void tkgl11TexCoord3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(ref v); }
        internal override unsafe void tkgl12TexCoord3(Int32* v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(v); }
        internal override void tkgl13TexCoord3(Int16 s, Int16 t, Int16 r) { OpenTK.Graphics.OpenGL.GL.TexCoord3(s, t, r); }
        internal override void tkgl14TexCoord3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(v); }
        internal override void tkgl15TexCoord3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(ref v); }
        internal override unsafe void tkgl16TexCoord3(Int16* v) { OpenTK.Graphics.OpenGL.GL.TexCoord3(v); }
        internal override void tkglTexCoord4(Double s, Double t, Double r, Double q) { OpenTK.Graphics.OpenGL.GL.TexCoord4(s, t, r, q); }
        internal override void tkgl2TexCoord4(Double[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(v); }
        internal override void tkgl3TexCoord4(ref Double v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(ref v); }
        internal override unsafe void tkgl4TexCoord4(Double* v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(v); }
        internal override void tkgl5TexCoord4(Single s, Single t, Single r, Single q) { OpenTK.Graphics.OpenGL.GL.TexCoord4(s, t, r, q); }
        internal override void tkgl6TexCoord4(Single[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(v); }
        internal override void tkgl7TexCoord4(ref Single v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(ref v); }
        internal override unsafe void tkgl8TexCoord4(Single* v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(v); }
        internal override void tkgl9TexCoord4(Int32 s, Int32 t, Int32 r, Int32 q) { OpenTK.Graphics.OpenGL.GL.TexCoord4(s, t, r, q); }
        internal override void tkgl10TexCoord4(Int32[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(v); }
        internal override void tkgl11TexCoord4(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(ref v); }
        internal override unsafe void tkgl12TexCoord4(Int32* v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(v); }
        internal override void tkgl13TexCoord4(Int16 s, Int16 t, Int16 r, Int16 q) { OpenTK.Graphics.OpenGL.GL.TexCoord4(s, t, r, q); }
        internal override void tkgl14TexCoord4(Int16[] v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(v); }
        internal override void tkgl15TexCoord4(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(ref v); }
        internal override unsafe void tkgl16TexCoord4(Int16* v) { OpenTK.Graphics.OpenGL.GL.TexCoord4(v); }
        internal override void tkglTexCoordPointer(Int32 size, OpenTK.Graphics.OpenGL.TexCoordPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.TexCoordPointer(size, type, stride, pointer); }
        internal override void tkglTexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.TexEnv(target, pname, param); }
        internal override void tkgl2TexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.TexEnv(target, pname, @params); }
        internal override unsafe void tkgl3TexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.TexEnv(target, pname, @params); }
        internal override void tkgl4TexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.TexEnv(target, pname, param); }
        internal override void tkgl5TexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.TexEnv(target, pname, @params); }
        internal override unsafe void tkgl6TexEnv(OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.TexEnv(target, pname, @params); }
        internal override void tkglTexGend(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double param) { OpenTK.Graphics.OpenGL.GL.TexGend(coord, pname, param); }
        internal override void tkglTexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, @params); }
        internal override void tkgl2TexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, ref Double @params) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, ref @params); }
        internal override unsafe void tkgl3TexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, @params); }
        internal override void tkgl4TexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, param); }
        internal override void tkgl5TexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, @params); }
        internal override unsafe void tkgl6TexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, @params); }
        internal override void tkgl7TexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, param); }
        internal override void tkgl8TexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, @params); }
        internal override unsafe void tkgl9TexGen(OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.TexGen(coord, pname, @params); }
        internal override void tkglTexImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.TexImage1D(target, level, internalformat, width, border, format, type, pixels); }
        internal override void tkglTexImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels); }
        internal override void tkglTexImage2DMultisample(OpenTK.Graphics.OpenGL.TextureTargetMultisample target, Int32 samples, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, bool fixedsamplelocations) { OpenTK.Graphics.OpenGL.GL.TexImage2DMultisample(target, samples, internalformat, width, height, fixedsamplelocations); }
        internal override void tkglTexImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.TexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels); }
        internal override void tkglTexImage3DMultisample(OpenTK.Graphics.OpenGL.TextureTargetMultisample target, Int32 samples, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, bool fixedsamplelocations) { OpenTK.Graphics.OpenGL.GL.TexImage3DMultisample(target, samples, internalformat, width, height, depth, fixedsamplelocations); }
        internal override void tkglTexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single param) { OpenTK.Graphics.OpenGL.GL.TexParameter(target, pname, param); }
        internal override void tkgl2TexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.TexParameter(target, pname, @params); }
        internal override unsafe void tkgl3TexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.TexParameter(target, pname, @params); }
        internal override void tkgl4TexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.TexParameter(target, pname, param); }
        internal override void tkglTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.TexParameterI(target, pname, @params); }
        internal override void tkgl2TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.TexParameterI(target, pname, ref @params); }
        internal override unsafe void tkgl3TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.TexParameterI(target, pname, @params); }
        internal override void tkgl4TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.TexParameterI(target, pname, @params); }
        internal override void tkgl5TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.TexParameterI(target, pname, ref @params); }
        internal override unsafe void tkgl6TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.TexParameterI(target, pname, @params); }
        internal override void tkgl5TexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.TexParameter(target, pname, @params); }
        internal override unsafe void tkgl6TexParameter(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.TexParameter(target, pname, @params); }
        internal override void tkglTexSubImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.TexSubImage1D(target, level, xoffset, width, format, type, pixels); }
        internal override void tkglTexSubImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.TexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels); }
        internal override void tkglTexSubImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.TexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels); }
        internal override void tkglTransformFeedbackVaryings(Int32 program, Int32 count, String[] varyings, OpenTK.Graphics.OpenGL.TransformFeedbackMode bufferMode) { OpenTK.Graphics.OpenGL.GL.TransformFeedbackVaryings(program, count, varyings, bufferMode); }
        internal override void tkgl2TransformFeedbackVaryings(UInt32 program, Int32 count, String[] varyings, OpenTK.Graphics.OpenGL.TransformFeedbackMode bufferMode) { OpenTK.Graphics.OpenGL.GL.TransformFeedbackVaryings(program, count, varyings, bufferMode); }
        internal override void tkglTranslate(Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Translate(x, y, z); }
        internal override void tkgl2Translate(Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Translate(x, y, z); }
        internal override void tkgl9Uniform1(Int32 location, Single v0) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, v0); }
        internal override void tkgl10Uniform1(Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, value); }
        internal override void tkgl11Uniform1(Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, ref value); }
        internal override unsafe void tkgl12Uniform1(Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, value); }
        internal override void tkgl13Uniform1(Int32 location, Int32 v0) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, v0); }
        internal override void tkgl14Uniform1(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, value); }
        internal override void tkgl15Uniform1(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, ref value); }
        internal override unsafe void tkgl16Uniform1(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, value); }
        internal override void tkgl17Uniform1(Int32 location, UInt32 v0) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, v0); }
        internal override void tkgl18Uniform1(Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, value); }
        internal override void tkgl19Uniform1(Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, ref value); }
        internal override unsafe void tkgl20Uniform1(Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Uniform1(location, count, value); }
        internal override void tkgl8Uniform2(Int32 location, Single v0, Single v1) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, v0, v1); }
        internal override void tkgl9Uniform2(Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, count, value); }
        internal override void tkgl10Uniform2(Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, count, ref value); }
        internal override unsafe void tkgl11Uniform2(Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, count, value); }
        internal override void tkgl12Uniform2(Int32 location, Int32 v0, Int32 v1) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, v0, v1); }
        internal override void tkgl13Uniform2(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, count, value); }
        internal override unsafe void tkgl14Uniform2(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, count, value); }
        internal override void tkgl15Uniform2(Int32 location, UInt32 v0, UInt32 v1) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, v0, v1); }
        internal override void tkgl16Uniform2(Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, count, value); }
        internal override void tkgl17Uniform2(Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, count, ref value); }
        internal override unsafe void tkgl18Uniform2(Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Uniform2(location, count, value); }
        internal override void tkgl9Uniform3(Int32 location, Single v0, Single v1, Single v2) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, v0, v1, v2); }
        internal override void tkgl10Uniform3(Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, value); }
        internal override void tkgl11Uniform3(Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, ref value); }
        internal override unsafe void tkgl12Uniform3(Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, value); }
        internal override void tkgl13Uniform3(Int32 location, Int32 v0, Int32 v1, Int32 v2) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, v0, v1, v2); }
        internal override void tkgl14Uniform3(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, value); }
        internal override void tkgl15Uniform3(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, ref value); }
        internal override unsafe void tkgl16Uniform3(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, value); }
        internal override void tkgl17Uniform3(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, v0, v1, v2); }
        internal override void tkgl18Uniform3(Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, value); }
        internal override void tkgl19Uniform3(Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, ref value); }
        internal override unsafe void tkgl20Uniform3(Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Uniform3(location, count, value); }
        internal override void tkgl9Uniform4(Int32 location, Single v0, Single v1, Single v2, Single v3) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, v0, v1, v2, v3); }
        internal override void tkgl10Uniform4(Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, value); }
        internal override void tkgl11Uniform4(Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, ref value); }
        internal override unsafe void tkgl12Uniform4(Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, value); }
        internal override void tkgl13Uniform4(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, v0, v1, v2, v3); }
        internal override void tkgl14Uniform4(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, value); }
        internal override void tkgl15Uniform4(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, ref value); }
        internal override unsafe void tkgl16Uniform4(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, value); }
        internal override void tkgl17Uniform4(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, v0, v1, v2, v3); }
        internal override void tkgl18Uniform4(Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, value); }
        internal override void tkgl19Uniform4(Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, ref value); }
        internal override unsafe void tkgl20Uniform4(Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Uniform4(location, count, value); }
        internal override void tkglUniformBlockBinding(Int32 program, Int32 uniformBlockIndex, Int32 uniformBlockBinding) { OpenTK.Graphics.OpenGL.GL.UniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding); }
        internal override void tkgl2UniformBlockBinding(UInt32 program, UInt32 uniformBlockIndex, UInt32 uniformBlockBinding) { OpenTK.Graphics.OpenGL.GL.UniformBlockBinding(program, uniformBlockIndex, uniformBlockBinding); }
        internal override void tkgl4UniformMatrix2(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2(location, count, transpose, value); }
        internal override void tkgl5UniformMatrix2(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2(location, count, transpose, ref value); }
        internal override unsafe void tkgl6UniformMatrix2(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2(location, count, transpose, value); }
        internal override void tkglUniformMatrix2x3(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2x3(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix2x3(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2x3(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix2x3(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2x3(location, count, transpose, value); }
        internal override void tkglUniformMatrix2x4(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2x4(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix2x4(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2x4(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix2x4(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix2x4(location, count, transpose, value); }
        internal override void tkgl4UniformMatrix3(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3(location, count, transpose, value); }
        internal override void tkgl5UniformMatrix3(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3(location, count, transpose, ref value); }
        internal override unsafe void tkgl6UniformMatrix3(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3(location, count, transpose, value); }
        internal override void tkglUniformMatrix3x2(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3x2(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix3x2(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3x2(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix3x2(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3x2(location, count, transpose, value); }
        internal override void tkglUniformMatrix3x4(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3x4(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix3x4(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3x4(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix3x4(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix3x4(location, count, transpose, value); }
        internal override void tkgl4UniformMatrix4(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4(location, count, transpose, value); }
        internal override void tkgl5UniformMatrix4(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4(location, count, transpose, ref value); }
        internal override unsafe void tkgl6UniformMatrix4(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4(location, count, transpose, value); }
        internal override void tkglUniformMatrix4x2(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4x2(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix4x2(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4x2(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix4x2(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4x2(location, count, transpose, value); }
        internal override void tkglUniformMatrix4x3(Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4x3(location, count, transpose, value); }
        internal override void tkgl2UniformMatrix4x3(Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4x3(location, count, transpose, ref value); }
        internal override unsafe void tkgl3UniformMatrix4x3(Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.UniformMatrix4x3(location, count, transpose, value); }
        internal override bool tkgl2UnmapBuffer(OpenTK.Graphics.OpenGL.BufferTarget target) { return OpenTK.Graphics.OpenGL.GL.UnmapBuffer(target); }
        internal override void tkglUseProgram(Int32 program) { OpenTK.Graphics.OpenGL.GL.UseProgram(program); }
        internal override void tkgl2UseProgram(UInt32 program) { OpenTK.Graphics.OpenGL.GL.UseProgram(program); }
        internal override void tkgl3ValidateProgram(Int32 program) { OpenTK.Graphics.OpenGL.GL.ValidateProgram(program); }
        internal override void tkgl4ValidateProgram(UInt32 program) { OpenTK.Graphics.OpenGL.GL.ValidateProgram(program); }
        internal override void tkglVertex2(Double x, Double y) { OpenTK.Graphics.OpenGL.GL.Vertex2(x, y); }
        internal override void tkgl2Vertex2(Double[] v) { OpenTK.Graphics.OpenGL.GL.Vertex2(v); }
        internal override void tkgl3Vertex2(ref Double v) { OpenTK.Graphics.OpenGL.GL.Vertex2(ref v); }
        internal override unsafe void tkgl4Vertex2(Double* v) { OpenTK.Graphics.OpenGL.GL.Vertex2(v); }
        internal override void tkgl5Vertex2(Single x, Single y) { OpenTK.Graphics.OpenGL.GL.Vertex2(x, y); }
        internal override void tkgl6Vertex2(Single[] v) { OpenTK.Graphics.OpenGL.GL.Vertex2(v); }
        internal override void tkgl7Vertex2(ref Single v) { OpenTK.Graphics.OpenGL.GL.Vertex2(ref v); }
        internal override unsafe void tkgl8Vertex2(Single* v) { OpenTK.Graphics.OpenGL.GL.Vertex2(v); }
        internal override void tkgl9Vertex2(Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.Vertex2(x, y); }
        internal override void tkgl10Vertex2(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Vertex2(v); }
        internal override void tkgl11Vertex2(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Vertex2(ref v); }
        internal override unsafe void tkgl12Vertex2(Int32* v) { OpenTK.Graphics.OpenGL.GL.Vertex2(v); }
        internal override void tkgl13Vertex2(Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.Vertex2(x, y); }
        internal override void tkgl14Vertex2(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Vertex2(v); }
        internal override void tkgl15Vertex2(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Vertex2(ref v); }
        internal override unsafe void tkgl16Vertex2(Int16* v) { OpenTK.Graphics.OpenGL.GL.Vertex2(v); }
        internal override void tkglVertex3(Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Vertex3(x, y, z); }
        internal override void tkgl2Vertex3(Double[] v) { OpenTK.Graphics.OpenGL.GL.Vertex3(v); }
        internal override void tkgl3Vertex3(ref Double v) { OpenTK.Graphics.OpenGL.GL.Vertex3(ref v); }
        internal override unsafe void tkgl4Vertex3(Double* v) { OpenTK.Graphics.OpenGL.GL.Vertex3(v); }
        internal override void tkgl5Vertex3(Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Vertex3(x, y, z); }
        internal override void tkgl6Vertex3(Single[] v) { OpenTK.Graphics.OpenGL.GL.Vertex3(v); }
        internal override void tkgl7Vertex3(ref Single v) { OpenTK.Graphics.OpenGL.GL.Vertex3(ref v); }
        internal override unsafe void tkgl8Vertex3(Single* v) { OpenTK.Graphics.OpenGL.GL.Vertex3(v); }
        internal override void tkgl9Vertex3(Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.Vertex3(x, y, z); }
        internal override void tkgl10Vertex3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Vertex3(v); }
        internal override void tkgl11Vertex3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Vertex3(ref v); }
        internal override unsafe void tkgl12Vertex3(Int32* v) { OpenTK.Graphics.OpenGL.GL.Vertex3(v); }
        internal override void tkgl13Vertex3(Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.Vertex3(x, y, z); }
        internal override void tkgl14Vertex3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Vertex3(v); }
        internal override void tkgl15Vertex3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Vertex3(ref v); }
        internal override unsafe void tkgl16Vertex3(Int16* v) { OpenTK.Graphics.OpenGL.GL.Vertex3(v); }
        internal override void tkglVertex4(Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Vertex4(x, y, z, w); }
        internal override void tkgl2Vertex4(Double[] v) { OpenTK.Graphics.OpenGL.GL.Vertex4(v); }
        internal override void tkgl3Vertex4(ref Double v) { OpenTK.Graphics.OpenGL.GL.Vertex4(ref v); }
        internal override unsafe void tkgl4Vertex4(Double* v) { OpenTK.Graphics.OpenGL.GL.Vertex4(v); }
        internal override void tkgl5Vertex4(Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Vertex4(x, y, z, w); }
        internal override void tkgl6Vertex4(Single[] v) { OpenTK.Graphics.OpenGL.GL.Vertex4(v); }
        internal override void tkgl7Vertex4(ref Single v) { OpenTK.Graphics.OpenGL.GL.Vertex4(ref v); }
        internal override unsafe void tkgl8Vertex4(Single* v) { OpenTK.Graphics.OpenGL.GL.Vertex4(v); }
        internal override void tkgl9Vertex4(Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.Vertex4(x, y, z, w); }
        internal override void tkgl10Vertex4(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Vertex4(v); }
        internal override void tkgl11Vertex4(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Vertex4(ref v); }
        internal override unsafe void tkgl12Vertex4(Int32* v) { OpenTK.Graphics.OpenGL.GL.Vertex4(v); }
        internal override void tkgl13Vertex4(Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.Vertex4(x, y, z, w); }
        internal override void tkgl14Vertex4(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Vertex4(v); }
        internal override void tkgl15Vertex4(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Vertex4(ref v); }
        internal override unsafe void tkgl16Vertex4(Int16* v) { OpenTK.Graphics.OpenGL.GL.Vertex4(v); }
        internal override void tkgl13VertexAttrib1(Int32 index, Double x) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, x); }
        internal override void tkgl14VertexAttrib1(UInt32 index, Double x) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, x); }
        internal override unsafe void tkgl15VertexAttrib1(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, v); }
        internal override unsafe void tkgl16VertexAttrib1(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, v); }
        internal override void tkgl17VertexAttrib1(Int32 index, Single x) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, x); }
        internal override void tkgl18VertexAttrib1(UInt32 index, Single x) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, x); }
        internal override unsafe void tkgl19VertexAttrib1(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, v); }
        internal override unsafe void tkgl20VertexAttrib1(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, v); }
        internal override void tkgl21VertexAttrib1(Int32 index, Int16 x) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, x); }
        internal override void tkgl22VertexAttrib1(UInt32 index, Int16 x) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, x); }
        internal override unsafe void tkgl23VertexAttrib1(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, v); }
        internal override unsafe void tkgl24VertexAttrib1(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib1(index, v); }
        internal override void tkgl25VertexAttrib2(Int32 index, Double x, Double y) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, x, y); }
        internal override void tkgl26VertexAttrib2(UInt32 index, Double x, Double y) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, x, y); }
        internal override void tkgl27VertexAttrib2(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl28VertexAttrib2(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl29VertexAttrib2(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl30VertexAttrib2(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl31VertexAttrib2(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl32VertexAttrib2(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl33VertexAttrib2(Int32 index, Single x, Single y) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, x, y); }
        internal override void tkgl34VertexAttrib2(UInt32 index, Single x, Single y) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, x, y); }
        internal override void tkgl35VertexAttrib2(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl36VertexAttrib2(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl37VertexAttrib2(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl38VertexAttrib2(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl39VertexAttrib2(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl40VertexAttrib2(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl41VertexAttrib2(Int32 index, Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, x, y); }
        internal override void tkgl42VertexAttrib2(UInt32 index, Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, x, y); }
        internal override void tkgl43VertexAttrib2(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl44VertexAttrib2(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl45VertexAttrib2(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl46VertexAttrib2(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl47VertexAttrib2(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl48VertexAttrib2(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib2(index, v); }
        internal override void tkgl25VertexAttrib3(Int32 index, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, x, y, z); }
        internal override void tkgl26VertexAttrib3(UInt32 index, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, x, y, z); }
        internal override void tkgl27VertexAttrib3(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl28VertexAttrib3(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl29VertexAttrib3(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl30VertexAttrib3(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl31VertexAttrib3(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl32VertexAttrib3(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl33VertexAttrib3(Int32 index, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, x, y, z); }
        internal override void tkgl34VertexAttrib3(UInt32 index, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, x, y, z); }
        internal override void tkgl35VertexAttrib3(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl36VertexAttrib3(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl37VertexAttrib3(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl38VertexAttrib3(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl39VertexAttrib3(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl40VertexAttrib3(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl41VertexAttrib3(Int32 index, Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, x, y, z); }
        internal override void tkgl42VertexAttrib3(UInt32 index, Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, x, y, z); }
        internal override void tkgl43VertexAttrib3(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl44VertexAttrib3(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl45VertexAttrib3(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl46VertexAttrib3(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl47VertexAttrib3(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl48VertexAttrib3(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib3(index, v); }
        internal override void tkgl46VertexAttrib4(UInt32 index, SByte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl47VertexAttrib4(UInt32 index, ref SByte v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl48VertexAttrib4(UInt32 index, SByte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl49VertexAttrib4(Int32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl50VertexAttrib4(UInt32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl51VertexAttrib4(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl52VertexAttrib4(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl53VertexAttrib4(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl54VertexAttrib4(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl55VertexAttrib4(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl56VertexAttrib4(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl57VertexAttrib4(Int32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl58VertexAttrib4(UInt32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl59VertexAttrib4(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl60VertexAttrib4(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl61VertexAttrib4(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl62VertexAttrib4(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl63VertexAttrib4(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl64VertexAttrib4(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl65VertexAttrib4(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl66VertexAttrib4(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl67VertexAttrib4(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl68VertexAttrib4(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl69VertexAttrib4(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl70VertexAttrib4(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl30VertexAttrib4N(UInt32 index, SByte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl31VertexAttrib4N(UInt32 index, ref SByte v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl32VertexAttrib4N(UInt32 index, SByte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl33VertexAttrib4N(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl34VertexAttrib4N(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl35VertexAttrib4N(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl36VertexAttrib4N(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl37VertexAttrib4N(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl38VertexAttrib4N(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl39VertexAttrib4N(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl40VertexAttrib4N(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl41VertexAttrib4N(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl42VertexAttrib4N(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl43VertexAttrib4N(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl44VertexAttrib4N(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl45VertexAttrib4N(Int32 index, Byte x, Byte y, Byte z, Byte w) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, x, y, z, w); }
        internal override void tkgl46VertexAttrib4N(UInt32 index, Byte x, Byte y, Byte z, Byte w) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, x, y, z, w); }
        internal override void tkgl47VertexAttrib4N(Int32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl48VertexAttrib4N(Int32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl49VertexAttrib4N(Int32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl50VertexAttrib4N(UInt32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl51VertexAttrib4N(UInt32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl52VertexAttrib4N(UInt32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl53VertexAttrib4N(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl54VertexAttrib4N(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl55VertexAttrib4N(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl56VertexAttrib4N(UInt32 index, UInt16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl57VertexAttrib4N(UInt32 index, ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, ref v); }
        internal override unsafe void tkgl58VertexAttrib4N(UInt32 index, UInt16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4N(index, v); }
        internal override void tkgl71VertexAttrib4(Int32 index, Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl72VertexAttrib4(UInt32 index, Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl73VertexAttrib4(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl74VertexAttrib4(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl75VertexAttrib4(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl76VertexAttrib4(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl77VertexAttrib4(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl78VertexAttrib4(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl79VertexAttrib4(Int32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl80VertexAttrib4(Int32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl81VertexAttrib4(Int32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl82VertexAttrib4(UInt32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl83VertexAttrib4(UInt32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl84VertexAttrib4(UInt32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl85VertexAttrib4(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl86VertexAttrib4(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl87VertexAttrib4(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl88VertexAttrib4(UInt32 index, UInt16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkgl89VertexAttrib4(UInt32 index, ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl90VertexAttrib4(UInt32 index, UInt16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttrib4(index, v); }
        internal override void tkglVertexAttribI1(Int32 index, Int32 x) { OpenTK.Graphics.OpenGL.GL.VertexAttribI1(index, x); }
        internal override void tkgl2VertexAttribI1(UInt32 index, Int32 x) { OpenTK.Graphics.OpenGL.GL.VertexAttribI1(index, x); }
        internal override unsafe void tkgl3VertexAttribI1(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI1(index, v); }
        internal override unsafe void tkgl4VertexAttribI1(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI1(index, v); }
        internal override void tkgl5VertexAttribI1(UInt32 index, UInt32 x) { OpenTK.Graphics.OpenGL.GL.VertexAttribI1(index, x); }
        internal override unsafe void tkgl6VertexAttribI1(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI1(index, v); }
        internal override void tkglVertexAttribI2(Int32 index, Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, x, y); }
        internal override void tkgl2VertexAttribI2(UInt32 index, Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, x, y); }
        internal override void tkgl3VertexAttribI2(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, v); }
        internal override void tkgl4VertexAttribI2(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, ref v); }
        internal override unsafe void tkgl5VertexAttribI2(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, v); }
        internal override void tkgl6VertexAttribI2(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, v); }
        internal override void tkgl7VertexAttribI2(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, ref v); }
        internal override unsafe void tkgl8VertexAttribI2(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, v); }
        internal override void tkgl9VertexAttribI2(UInt32 index, UInt32 x, UInt32 y) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, x, y); }
        internal override void tkgl10VertexAttribI2(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, v); }
        internal override void tkgl11VertexAttribI2(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, ref v); }
        internal override unsafe void tkgl12VertexAttribI2(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI2(index, v); }
        internal override void tkglVertexAttribI3(Int32 index, Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, x, y, z); }
        internal override void tkgl2VertexAttribI3(UInt32 index, Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, x, y, z); }
        internal override void tkgl3VertexAttribI3(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, v); }
        internal override void tkgl4VertexAttribI3(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, ref v); }
        internal override unsafe void tkgl5VertexAttribI3(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, v); }
        internal override void tkgl6VertexAttribI3(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, v); }
        internal override void tkgl7VertexAttribI3(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, ref v); }
        internal override unsafe void tkgl8VertexAttribI3(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, v); }
        internal override void tkgl9VertexAttribI3(UInt32 index, UInt32 x, UInt32 y, UInt32 z) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, x, y, z); }
        internal override void tkgl10VertexAttribI3(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, v); }
        internal override void tkgl11VertexAttribI3(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, ref v); }
        internal override unsafe void tkgl12VertexAttribI3(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI3(index, v); }
        internal override void tkglVertexAttribI4(UInt32 index, SByte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl2VertexAttribI4(UInt32 index, ref SByte v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl3VertexAttribI4(UInt32 index, SByte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl4VertexAttribI4(Int32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, x, y, z, w); }
        internal override void tkgl5VertexAttribI4(UInt32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, x, y, z, w); }
        internal override void tkgl6VertexAttribI4(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl7VertexAttribI4(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl8VertexAttribI4(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl9VertexAttribI4(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl10VertexAttribI4(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl11VertexAttribI4(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl12VertexAttribI4(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl13VertexAttribI4(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl14VertexAttribI4(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl15VertexAttribI4(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl16VertexAttribI4(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl17VertexAttribI4(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl18VertexAttribI4(Int32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl19VertexAttribI4(Int32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl20VertexAttribI4(Int32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl21VertexAttribI4(UInt32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl22VertexAttribI4(UInt32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl23VertexAttribI4(UInt32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl24VertexAttribI4(UInt32 index, UInt32 x, UInt32 y, UInt32 z, UInt32 w) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, x, y, z, w); }
        internal override void tkgl25VertexAttribI4(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl26VertexAttribI4(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl27VertexAttribI4(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl28VertexAttribI4(UInt32 index, UInt16[] v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkgl29VertexAttribI4(UInt32 index, ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl30VertexAttribI4(UInt32 index, UInt16* v) { OpenTK.Graphics.OpenGL.GL.VertexAttribI4(index, v); }
        internal override void tkglVertexAttribIPointer(Int32 index, Int32 size, OpenTK.Graphics.OpenGL.VertexAttribIPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.VertexAttribIPointer(index, size, type, stride, pointer); }
        internal override void tkgl2VertexAttribIPointer(UInt32 index, Int32 size, OpenTK.Graphics.OpenGL.VertexAttribIPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.VertexAttribIPointer(index, size, type, stride, pointer); }
        internal override void tkgl3VertexAttribPointer(Int32 index, Int32 size, OpenTK.Graphics.OpenGL.VertexAttribPointerType type, bool normalized, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.VertexAttribPointer(index, size, type, normalized, stride, pointer); }
        internal override void tkgl4VertexAttribPointer(UInt32 index, Int32 size, OpenTK.Graphics.OpenGL.VertexAttribPointerType type, bool normalized, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.VertexAttribPointer(index, size, type, normalized, stride, pointer); }
        internal override void tkglVertexPointer(Int32 size, OpenTK.Graphics.OpenGL.VertexPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.VertexPointer(size, type, stride, pointer); }
        internal override void tkglViewport(Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Viewport(x, y, width, height); }
        internal override void tkglWaitSync(IntPtr sync, Int32 flags, Int64 timeout) { OpenTK.Graphics.OpenGL.GL.WaitSync(sync, flags, timeout); }
        internal override void tkgl2WaitSync(IntPtr sync, UInt32 flags, UInt64 timeout) { OpenTK.Graphics.OpenGL.GL.WaitSync(sync, flags, timeout); }
        internal override void tkgl17WindowPos2(Double x, Double y) { OpenTK.Graphics.OpenGL.GL.WindowPos2(x, y); }
        internal override void tkgl18WindowPos2(Double[] v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(v); }
        internal override void tkgl19WindowPos2(ref Double v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(ref v); }
        internal override unsafe void tkgl20WindowPos2(Double* v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(v); }
        internal override void tkgl21WindowPos2(Single x, Single y) { OpenTK.Graphics.OpenGL.GL.WindowPos2(x, y); }
        internal override void tkgl22WindowPos2(Single[] v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(v); }
        internal override void tkgl23WindowPos2(ref Single v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(ref v); }
        internal override unsafe void tkgl24WindowPos2(Single* v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(v); }
        internal override void tkgl25WindowPos2(Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.WindowPos2(x, y); }
        internal override void tkgl26WindowPos2(Int32[] v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(v); }
        internal override void tkgl27WindowPos2(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(ref v); }
        internal override unsafe void tkgl28WindowPos2(Int32* v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(v); }
        internal override void tkgl29WindowPos2(Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.WindowPos2(x, y); }
        internal override void tkgl30WindowPos2(Int16[] v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(v); }
        internal override void tkgl31WindowPos2(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(ref v); }
        internal override unsafe void tkgl32WindowPos2(Int16* v) { OpenTK.Graphics.OpenGL.GL.WindowPos2(v); }
        internal override void tkgl17WindowPos3(Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.WindowPos3(x, y, z); }
        internal override void tkgl18WindowPos3(Double[] v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(v); }
        internal override void tkgl19WindowPos3(ref Double v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(ref v); }
        internal override unsafe void tkgl20WindowPos3(Double* v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(v); }
        internal override void tkgl21WindowPos3(Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.WindowPos3(x, y, z); }
        internal override void tkgl22WindowPos3(Single[] v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(v); }
        internal override void tkgl23WindowPos3(ref Single v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(ref v); }
        internal override unsafe void tkgl24WindowPos3(Single* v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(v); }
        internal override void tkgl25WindowPos3(Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.WindowPos3(x, y, z); }
        internal override void tkgl26WindowPos3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(v); }
        internal override void tkgl27WindowPos3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(ref v); }
        internal override unsafe void tkgl28WindowPos3(Int32* v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(v); }
        internal override void tkgl29WindowPos3(Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.WindowPos3(x, y, z); }
        internal override void tkgl30WindowPos3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(v); }
        internal override void tkgl31WindowPos3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(ref v); }
        internal override unsafe void tkgl32WindowPos3(Int16* v) { OpenTK.Graphics.OpenGL.GL.WindowPos3(v); }
        internal override void tkglActiveStencilFace(OpenTK.Graphics.OpenGL.ExtStencilTwoSide face) { OpenTK.Graphics.OpenGL.GL.Ext.ActiveStencilFace(face); }
        internal override void tkglApplyTexture(OpenTK.Graphics.OpenGL.ExtLightTexture mode) { OpenTK.Graphics.OpenGL.GL.Ext.ApplyTexture(mode); }
        internal override bool tkgl7AreTexturesResident(Int32 n, Int32[] textures, bool[] residences) { return OpenTK.Graphics.OpenGL.GL.Ext.AreTexturesResident(n, textures, residences); }
        internal override bool tkgl8AreTexturesResident(Int32 n, ref Int32 textures, out bool residences) { return OpenTK.Graphics.OpenGL.GL.Ext.AreTexturesResident(n, ref textures, out residences); }
        internal override unsafe bool tkgl9AreTexturesResident(Int32 n, Int32* textures, bool* residences) { return OpenTK.Graphics.OpenGL.GL.Ext.AreTexturesResident(n, textures, residences); }
        internal override bool tkgl10AreTexturesResident(Int32 n, UInt32[] textures, bool[] residences) { return OpenTK.Graphics.OpenGL.GL.Ext.AreTexturesResident(n, textures, residences); }
        internal override bool tkgl11AreTexturesResident(Int32 n, ref UInt32 textures, out bool residences) { return OpenTK.Graphics.OpenGL.GL.Ext.AreTexturesResident(n, ref textures, out residences); }
        internal override unsafe bool tkgl12AreTexturesResident(Int32 n, UInt32* textures, bool* residences) { return OpenTK.Graphics.OpenGL.GL.Ext.AreTexturesResident(n, textures, residences); }
        internal override void tkgl2ArrayElement(Int32 i) { OpenTK.Graphics.OpenGL.GL.Ext.ArrayElement(i); }
        internal override void tkgl2BeginTransformFeedback(OpenTK.Graphics.OpenGL.ExtTransformFeedback primitiveMode) { OpenTK.Graphics.OpenGL.GL.Ext.BeginTransformFeedback(primitiveMode); }
        internal override void tkglBeginVertexShader() { OpenTK.Graphics.OpenGL.GL.Ext.BeginVertexShader(); }
        internal override void tkgl3BindBufferBase(OpenTK.Graphics.OpenGL.ExtTransformFeedback target, Int32 index, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.BindBufferBase(target, index, buffer); }
        internal override void tkgl4BindBufferBase(OpenTK.Graphics.OpenGL.ExtTransformFeedback target, UInt32 index, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.BindBufferBase(target, index, buffer); }
        internal override void tkglBindBufferOffset(OpenTK.Graphics.OpenGL.ExtTransformFeedback target, Int32 index, Int32 buffer, IntPtr offset) { OpenTK.Graphics.OpenGL.GL.Ext.BindBufferOffset(target, index, buffer, offset); }
        internal override void tkgl2BindBufferOffset(OpenTK.Graphics.OpenGL.ExtTransformFeedback target, UInt32 index, UInt32 buffer, IntPtr offset) { OpenTK.Graphics.OpenGL.GL.Ext.BindBufferOffset(target, index, buffer, offset); }
        internal override void tkgl3BindBufferRange(OpenTK.Graphics.OpenGL.ExtTransformFeedback target, Int32 index, Int32 buffer, IntPtr offset, IntPtr size) { OpenTK.Graphics.OpenGL.GL.Ext.BindBufferRange(target, index, buffer, offset, size); }
        internal override void tkgl4BindBufferRange(OpenTK.Graphics.OpenGL.ExtTransformFeedback target, UInt32 index, UInt32 buffer, IntPtr offset, IntPtr size) { OpenTK.Graphics.OpenGL.GL.Ext.BindBufferRange(target, index, buffer, offset, size); }
        internal override void tkgl3BindFragDataLocation(Int32 program, Int32 color, String name) { OpenTK.Graphics.OpenGL.GL.Ext.BindFragDataLocation(program, color, name); }
        internal override void tkgl4BindFragDataLocation(UInt32 program, UInt32 color, String name) { OpenTK.Graphics.OpenGL.GL.Ext.BindFragDataLocation(program, color, name); }
        internal override void tkgl3BindFramebuffer(OpenTK.Graphics.OpenGL.FramebufferTarget target, Int32 framebuffer) { OpenTK.Graphics.OpenGL.GL.Ext.BindFramebuffer(target, framebuffer); }
        internal override void tkgl4BindFramebuffer(OpenTK.Graphics.OpenGL.FramebufferTarget target, UInt32 framebuffer) { OpenTK.Graphics.OpenGL.GL.Ext.BindFramebuffer(target, framebuffer); }
        internal override Int32 tkglBindLightParameter(OpenTK.Graphics.OpenGL.LightName light, OpenTK.Graphics.OpenGL.LightParameter value) { return OpenTK.Graphics.OpenGL.GL.Ext.BindLightParameter(light, value); }
        internal override Int32 tkglBindMaterialParameter(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter value) { return OpenTK.Graphics.OpenGL.GL.Ext.BindMaterialParameter(face, value); }
        internal override void tkglBindMultiTexture(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 texture) { OpenTK.Graphics.OpenGL.GL.Ext.BindMultiTexture(texunit, target, texture); }
        internal override void tkgl2BindMultiTexture(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, UInt32 texture) { OpenTK.Graphics.OpenGL.GL.Ext.BindMultiTexture(texunit, target, texture); }
        internal override Int32 tkglBindParameter(OpenTK.Graphics.OpenGL.ExtVertexShader value) { return OpenTK.Graphics.OpenGL.GL.Ext.BindParameter(value); }
        internal override void tkgl3BindRenderbuffer(OpenTK.Graphics.OpenGL.RenderbufferTarget target, Int32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.BindRenderbuffer(target, renderbuffer); }
        internal override void tkgl4BindRenderbuffer(OpenTK.Graphics.OpenGL.RenderbufferTarget target, UInt32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.BindRenderbuffer(target, renderbuffer); }
        internal override Int32 tkglBindTexGenParameter(OpenTK.Graphics.OpenGL.TextureUnit unit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter value) { return OpenTK.Graphics.OpenGL.GL.Ext.BindTexGenParameter(unit, coord, value); }
        internal override void tkgl3BindTexture(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 texture) { OpenTK.Graphics.OpenGL.GL.Ext.BindTexture(target, texture); }
        internal override void tkgl4BindTexture(OpenTK.Graphics.OpenGL.TextureTarget target, UInt32 texture) { OpenTK.Graphics.OpenGL.GL.Ext.BindTexture(target, texture); }
        internal override Int32 tkglBindTextureUnitParameter(OpenTK.Graphics.OpenGL.TextureUnit unit, OpenTK.Graphics.OpenGL.ExtVertexShader value) { return OpenTK.Graphics.OpenGL.GL.Ext.BindTextureUnitParameter(unit, value); }
        internal override void tkglBindVertexShader(Int32 id) { OpenTK.Graphics.OpenGL.GL.Ext.BindVertexShader(id); }
        internal override void tkgl2BindVertexShader(UInt32 id) { OpenTK.Graphics.OpenGL.GL.Ext.BindVertexShader(id); }
        internal override void tkglBinormal3(Byte bx, Byte by, Byte bz) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(bx, by, bz); }
        internal override void tkgl2Binormal3(SByte bx, SByte by, SByte bz) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(bx, by, bz); }
        internal override void tkgl3Binormal3(Byte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl4Binormal3(ref Byte v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(ref v); }
        internal override unsafe void tkgl5Binormal3(Byte* v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl6Binormal3(SByte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl7Binormal3(ref SByte v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(ref v); }
        internal override unsafe void tkgl8Binormal3(SByte* v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl9Binormal3(Double bx, Double by, Double bz) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(bx, by, bz); }
        internal override void tkgl10Binormal3(Double[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl11Binormal3(ref Double v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(ref v); }
        internal override unsafe void tkgl12Binormal3(Double* v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl13Binormal3(Single bx, Single by, Single bz) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(bx, by, bz); }
        internal override void tkgl14Binormal3(Single[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl15Binormal3(ref Single v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(ref v); }
        internal override unsafe void tkgl16Binormal3(Single* v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl17Binormal3(Int32 bx, Int32 by, Int32 bz) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(bx, by, bz); }
        internal override void tkgl18Binormal3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl19Binormal3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(ref v); }
        internal override unsafe void tkgl20Binormal3(Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl21Binormal3(Int16 bx, Int16 by, Int16 bz) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(bx, by, bz); }
        internal override void tkgl22Binormal3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkgl23Binormal3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(ref v); }
        internal override unsafe void tkgl24Binormal3(Int16* v) { OpenTK.Graphics.OpenGL.GL.Ext.Binormal3(v); }
        internal override void tkglBinormalPointer(OpenTK.Graphics.OpenGL.NormalPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.BinormalPointer(type, stride, pointer); }
        internal override void tkgl2BlendColor(Single red, Single green, Single blue, Single alpha) { OpenTK.Graphics.OpenGL.GL.Ext.BlendColor(red, green, blue, alpha); }
        internal override void tkgl4BlendEquation(OpenTK.Graphics.OpenGL.ExtBlendMinmax mode) { OpenTK.Graphics.OpenGL.GL.Ext.BlendEquation(mode); }
        internal override void tkgl4BlendEquationSeparate(OpenTK.Graphics.OpenGL.ExtBlendEquationSeparate modeRGB, OpenTK.Graphics.OpenGL.ExtBlendEquationSeparate modeAlpha) { OpenTK.Graphics.OpenGL.GL.Ext.BlendEquationSeparate(modeRGB, modeAlpha); }
        internal override void tkgl4BlendFuncSeparate(OpenTK.Graphics.OpenGL.ExtBlendFuncSeparate sfactorRGB, OpenTK.Graphics.OpenGL.ExtBlendFuncSeparate dfactorRGB, OpenTK.Graphics.OpenGL.ExtBlendFuncSeparate sfactorAlpha, OpenTK.Graphics.OpenGL.ExtBlendFuncSeparate dfactorAlpha) { OpenTK.Graphics.OpenGL.GL.Ext.BlendFuncSeparate(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha); }
        internal override void tkgl2BlitFramebuffer(Int32 srcX0, Int32 srcY0, Int32 srcX1, Int32 srcY1, Int32 dstX0, Int32 dstY0, Int32 dstX1, Int32 dstY1, OpenTK.Graphics.OpenGL.ClearBufferMask mask, OpenTK.Graphics.OpenGL.ExtFramebufferBlit filter) { OpenTK.Graphics.OpenGL.GL.Ext.BlitFramebuffer(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter); }
        internal override OpenTK.Graphics.OpenGL.FramebufferErrorCode tkgl2CheckFramebufferStatus(OpenTK.Graphics.OpenGL.FramebufferTarget target) { return OpenTK.Graphics.OpenGL.GL.Ext.CheckFramebufferStatus(target); }
        internal override OpenTK.Graphics.OpenGL.ExtDirectStateAccess tkglCheckNamedFramebufferStatus(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferTarget target) { return OpenTK.Graphics.OpenGL.GL.Ext.CheckNamedFramebufferStatus(framebuffer, target); }
        internal override OpenTK.Graphics.OpenGL.ExtDirectStateAccess tkgl2CheckNamedFramebufferStatus(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferTarget target) { return OpenTK.Graphics.OpenGL.GL.Ext.CheckNamedFramebufferStatus(framebuffer, target); }
        internal override void tkglClearColorI(Int32 red, Int32 green, Int32 blue, Int32 alpha) { OpenTK.Graphics.OpenGL.GL.Ext.ClearColorI(red, green, blue, alpha); }
        internal override void tkgl2ClearColorI(UInt32 red, UInt32 green, UInt32 blue, UInt32 alpha) { OpenTK.Graphics.OpenGL.GL.Ext.ClearColorI(red, green, blue, alpha); }
        internal override void tkglClientAttribDefault(OpenTK.Graphics.OpenGL.ClientAttribMask mask) { OpenTK.Graphics.OpenGL.GL.Ext.ClientAttribDefault(mask); }
        internal override void tkglColorMaskIndexed(Int32 index, bool r, bool g, bool b, bool a) { OpenTK.Graphics.OpenGL.GL.Ext.ColorMaskIndexed(index, r, g, b, a); }
        internal override void tkgl2ColorMaskIndexed(UInt32 index, bool r, bool g, bool b, bool a) { OpenTK.Graphics.OpenGL.GL.Ext.ColorMaskIndexed(index, r, g, b, a); }
        internal override void tkgl2ColorPointer(Int32 size, OpenTK.Graphics.OpenGL.ColorPointerType type, Int32 stride, Int32 count, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.ColorPointer(size, type, stride, count, pointer); }
        internal override void tkgl2ColorSubTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, Int32 start, Int32 count, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.ColorSubTable(target, start, count, format, type, data); }
        internal override void tkgl2ColorTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalFormat, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr table) { OpenTK.Graphics.OpenGL.GL.Ext.ColorTable(target, internalFormat, width, format, type, table); }
        internal override void tkglCompressedMultiTexImage1D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedMultiTexImage1D(texunit, target, level, internalformat, width, border, imageSize, bits); }
        internal override void tkglCompressedMultiTexImage2D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedMultiTexImage2D(texunit, target, level, internalformat, width, height, border, imageSize, bits); }
        internal override void tkglCompressedMultiTexImage3D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedMultiTexImage3D(texunit, target, level, internalformat, width, height, depth, border, imageSize, bits); }
        internal override void tkglCompressedMultiTexSubImage1D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedMultiTexSubImage1D(texunit, target, level, xoffset, width, format, imageSize, bits); }
        internal override void tkglCompressedMultiTexSubImage2D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedMultiTexSubImage2D(texunit, target, level, xoffset, yoffset, width, height, format, imageSize, bits); }
        internal override void tkglCompressedMultiTexSubImage3D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedMultiTexSubImage3D(texunit, target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, bits); }
        internal override void tkglCompressedTextureImage1D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureImage1D(texture, target, level, internalformat, width, border, imageSize, bits); }
        internal override void tkgl2CompressedTextureImage1D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureImage1D(texture, target, level, internalformat, width, border, imageSize, bits); }
        internal override void tkglCompressedTextureImage2D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureImage2D(texture, target, level, internalformat, width, height, border, imageSize, bits); }
        internal override void tkgl2CompressedTextureImage2D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureImage2D(texture, target, level, internalformat, width, height, border, imageSize, bits); }
        internal override void tkglCompressedTextureImage3D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureImage3D(texture, target, level, internalformat, width, height, depth, border, imageSize, bits); }
        internal override void tkgl2CompressedTextureImage3D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureImage3D(texture, target, level, internalformat, width, height, depth, border, imageSize, bits); }
        internal override void tkglCompressedTextureSubImage1D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureSubImage1D(texture, target, level, xoffset, width, format, imageSize, bits); }
        internal override void tkgl2CompressedTextureSubImage1D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureSubImage1D(texture, target, level, xoffset, width, format, imageSize, bits); }
        internal override void tkglCompressedTextureSubImage2D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureSubImage2D(texture, target, level, xoffset, yoffset, width, height, format, imageSize, bits); }
        internal override void tkgl2CompressedTextureSubImage2D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureSubImage2D(texture, target, level, xoffset, yoffset, width, height, format, imageSize, bits); }
        internal override void tkglCompressedTextureSubImage3D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureSubImage3D(texture, target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, bits); }
        internal override void tkgl2CompressedTextureSubImage3D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, Int32 imageSize, IntPtr bits) { OpenTK.Graphics.OpenGL.GL.Ext.CompressedTextureSubImage3D(texture, target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, bits); }
        internal override void tkgl2ConvolutionFilter1D(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr image) { OpenTK.Graphics.OpenGL.GL.Ext.ConvolutionFilter1D(target, internalformat, width, format, type, image); }
        internal override void tkgl2ConvolutionFilter2D(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr image) { OpenTK.Graphics.OpenGL.GL.Ext.ConvolutionFilter2D(target, internalformat, width, height, format, type, image); }
        internal override void tkgl7ConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.ConvolutionParameter(target, pname, @params); }
        internal override void tkgl8ConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.ConvolutionParameter(target, pname, @params); }
        internal override unsafe void tkgl9ConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.ConvolutionParameter(target, pname, @params); }
        internal override void tkgl10ConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.ConvolutionParameter(target, pname, @params); }
        internal override void tkgl11ConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.ConvolutionParameter(target, pname, @params); }
        internal override unsafe void tkgl12ConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.ConvolutionParameter(target, pname, @params); }
        internal override void tkgl2CopyColorSubTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, Int32 start, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.Ext.CopyColorSubTable(target, start, x, y, width); }
        internal override void tkgl2CopyConvolutionFilter1D(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.Ext.CopyConvolutionFilter1D(target, internalformat, x, y, width); }
        internal override void tkgl2CopyConvolutionFilter2D(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyConvolutionFilter2D(target, internalformat, x, y, width, height); }
        internal override void tkglCopyMultiTexImage1D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 x, Int32 y, Int32 width, Int32 border) { OpenTK.Graphics.OpenGL.GL.Ext.CopyMultiTexImage1D(texunit, target, level, internalformat, x, y, width, border); }
        internal override void tkglCopyMultiTexImage2D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border) { OpenTK.Graphics.OpenGL.GL.Ext.CopyMultiTexImage2D(texunit, target, level, internalformat, x, y, width, height, border); }
        internal override void tkglCopyMultiTexSubImage1D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.Ext.CopyMultiTexSubImage1D(texunit, target, level, xoffset, x, y, width); }
        internal override void tkglCopyMultiTexSubImage2D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyMultiTexSubImage2D(texunit, target, level, xoffset, yoffset, x, y, width, height); }
        internal override void tkglCopyMultiTexSubImage3D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyMultiTexSubImage3D(texunit, target, level, xoffset, yoffset, zoffset, x, y, width, height); }
        internal override void tkgl2CopyTexImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 border) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTexImage1D(target, level, internalformat, x, y, width, border); }
        internal override void tkgl2CopyTexImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTexImage2D(target, level, internalformat, x, y, width, height, border); }
        internal override void tkgl2CopyTexSubImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTexSubImage1D(target, level, xoffset, x, y, width); }
        internal override void tkgl2CopyTexSubImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTexSubImage2D(target, level, xoffset, yoffset, x, y, width, height); }
        internal override void tkgl2CopyTexSubImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTexSubImage3D(target, level, xoffset, yoffset, zoffset, x, y, width, height); }
        internal override void tkglCopyTextureImage1D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 x, Int32 y, Int32 width, Int32 border) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureImage1D(texture, target, level, internalformat, x, y, width, border); }
        internal override void tkgl2CopyTextureImage1D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 x, Int32 y, Int32 width, Int32 border) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureImage1D(texture, target, level, internalformat, x, y, width, border); }
        internal override void tkglCopyTextureImage2D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureImage2D(texture, target, level, internalformat, x, y, width, height, border); }
        internal override void tkgl2CopyTextureImage2D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 x, Int32 y, Int32 width, Int32 height, Int32 border) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureImage2D(texture, target, level, internalformat, x, y, width, height, border); }
        internal override void tkglCopyTextureSubImage1D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureSubImage1D(texture, target, level, xoffset, x, y, width); }
        internal override void tkgl2CopyTextureSubImage1D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureSubImage1D(texture, target, level, xoffset, x, y, width); }
        internal override void tkglCopyTextureSubImage2D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureSubImage2D(texture, target, level, xoffset, yoffset, x, y, width, height); }
        internal override void tkgl2CopyTextureSubImage2D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureSubImage2D(texture, target, level, xoffset, yoffset, x, y, width, height); }
        internal override void tkglCopyTextureSubImage3D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureSubImage3D(texture, target, level, xoffset, yoffset, zoffset, x, y, width, height); }
        internal override void tkgl2CopyTextureSubImage3D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 x, Int32 y, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.CopyTextureSubImage3D(texture, target, level, xoffset, yoffset, zoffset, x, y, width, height); }
        internal override void tkglCullParameter(OpenTK.Graphics.OpenGL.ExtCullVertex pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.CullParameter(pname, @params); }
        internal override void tkgl2CullParameter(OpenTK.Graphics.OpenGL.ExtCullVertex pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.Ext.CullParameter(pname, out @params); }
        internal override unsafe void tkgl3CullParameter(OpenTK.Graphics.OpenGL.ExtCullVertex pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.Ext.CullParameter(pname, @params); }
        internal override void tkgl4CullParameter(OpenTK.Graphics.OpenGL.ExtCullVertex pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.CullParameter(pname, @params); }
        internal override void tkgl5CullParameter(OpenTK.Graphics.OpenGL.ExtCullVertex pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.CullParameter(pname, out @params); }
        internal override unsafe void tkgl6CullParameter(OpenTK.Graphics.OpenGL.ExtCullVertex pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.CullParameter(pname, @params); }
        internal override void tkgl7DeleteFramebuffers(Int32 n, Int32[] framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteFramebuffers(n, framebuffers); }
        internal override void tkgl8DeleteFramebuffers(Int32 n, ref Int32 framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteFramebuffers(n, ref framebuffers); }
        internal override unsafe void tkgl9DeleteFramebuffers(Int32 n, Int32* framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteFramebuffers(n, framebuffers); }
        internal override void tkgl10DeleteFramebuffers(Int32 n, UInt32[] framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteFramebuffers(n, framebuffers); }
        internal override void tkgl11DeleteFramebuffers(Int32 n, ref UInt32 framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteFramebuffers(n, ref framebuffers); }
        internal override unsafe void tkgl12DeleteFramebuffers(Int32 n, UInt32* framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteFramebuffers(n, framebuffers); }
        internal override void tkgl7DeleteRenderbuffers(Int32 n, Int32[] renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteRenderbuffers(n, renderbuffers); }
        internal override void tkgl8DeleteRenderbuffers(Int32 n, ref Int32 renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteRenderbuffers(n, ref renderbuffers); }
        internal override unsafe void tkgl9DeleteRenderbuffers(Int32 n, Int32* renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteRenderbuffers(n, renderbuffers); }
        internal override void tkgl10DeleteRenderbuffers(Int32 n, UInt32[] renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteRenderbuffers(n, renderbuffers); }
        internal override void tkgl11DeleteRenderbuffers(Int32 n, ref UInt32 renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteRenderbuffers(n, ref renderbuffers); }
        internal override unsafe void tkgl12DeleteRenderbuffers(Int32 n, UInt32* renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteRenderbuffers(n, renderbuffers); }
        internal override void tkgl7DeleteTextures(Int32 n, Int32[] textures) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteTextures(n, textures); }
        internal override void tkgl8DeleteTextures(Int32 n, ref Int32 textures) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteTextures(n, ref textures); }
        internal override unsafe void tkgl9DeleteTextures(Int32 n, Int32* textures) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteTextures(n, textures); }
        internal override void tkgl10DeleteTextures(Int32 n, UInt32[] textures) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteTextures(n, textures); }
        internal override void tkgl11DeleteTextures(Int32 n, ref UInt32 textures) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteTextures(n, ref textures); }
        internal override unsafe void tkgl12DeleteTextures(Int32 n, UInt32* textures) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteTextures(n, textures); }
        internal override void tkglDeleteVertexShader(Int32 id) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteVertexShader(id); }
        internal override void tkgl2DeleteVertexShader(UInt32 id) { OpenTK.Graphics.OpenGL.GL.Ext.DeleteVertexShader(id); }
        internal override void tkglDepthBounds(Double zmin, Double zmax) { OpenTK.Graphics.OpenGL.GL.Ext.DepthBounds(zmin, zmax); }
        internal override void tkglDisableClientStateIndexed(OpenTK.Graphics.OpenGL.EnableCap array, Int32 index) { OpenTK.Graphics.OpenGL.GL.Ext.DisableClientStateIndexed(array, index); }
        internal override void tkgl2DisableClientStateIndexed(OpenTK.Graphics.OpenGL.EnableCap array, UInt32 index) { OpenTK.Graphics.OpenGL.GL.Ext.DisableClientStateIndexed(array, index); }
        internal override void tkglDisableIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index) { OpenTK.Graphics.OpenGL.GL.Ext.DisableIndexed(target, index); }
        internal override void tkgl2DisableIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index) { OpenTK.Graphics.OpenGL.GL.Ext.DisableIndexed(target, index); }
        internal override void tkglDisableVariantClientState(Int32 id) { OpenTK.Graphics.OpenGL.GL.Ext.DisableVariantClientState(id); }
        internal override void tkgl2DisableVariantClientState(UInt32 id) { OpenTK.Graphics.OpenGL.GL.Ext.DisableVariantClientState(id); }
        internal override void tkgl2DrawArrays(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 first, Int32 count) { OpenTK.Graphics.OpenGL.GL.Ext.DrawArrays(mode, first, count); }
        internal override void tkgl3DrawArraysInstanced(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Ext.DrawArraysInstanced(mode, start, count, primcount); }
        internal override void tkgl3DrawElementsInstanced(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Ext.DrawElementsInstanced(mode, count, type, indices, primcount); }
        internal override void tkgl3DrawRangeElements(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 start, Int32 end, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices) { OpenTK.Graphics.OpenGL.GL.Ext.DrawRangeElements(mode, start, end, count, type, indices); }
        internal override void tkgl4DrawRangeElements(OpenTK.Graphics.OpenGL.BeginMode mode, UInt32 start, UInt32 end, Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices) { OpenTK.Graphics.OpenGL.GL.Ext.DrawRangeElements(mode, start, end, count, type, indices); }
        internal override void tkgl2EdgeFlagPointer(Int32 stride, Int32 count, bool[] pointer) { OpenTK.Graphics.OpenGL.GL.Ext.EdgeFlagPointer(stride, count, pointer); }
        internal override void tkgl3EdgeFlagPointer(Int32 stride, Int32 count, ref bool pointer) { OpenTK.Graphics.OpenGL.GL.Ext.EdgeFlagPointer(stride, count, ref pointer); }
        internal override unsafe void tkgl4EdgeFlagPointer(Int32 stride, Int32 count, bool* pointer) { OpenTK.Graphics.OpenGL.GL.Ext.EdgeFlagPointer(stride, count, pointer); }
        internal override void tkglEnableClientStateIndexed(OpenTK.Graphics.OpenGL.EnableCap array, Int32 index) { OpenTK.Graphics.OpenGL.GL.Ext.EnableClientStateIndexed(array, index); }
        internal override void tkgl2EnableClientStateIndexed(OpenTK.Graphics.OpenGL.EnableCap array, UInt32 index) { OpenTK.Graphics.OpenGL.GL.Ext.EnableClientStateIndexed(array, index); }
        internal override void tkglEnableIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index) { OpenTK.Graphics.OpenGL.GL.Ext.EnableIndexed(target, index); }
        internal override void tkgl2EnableIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index) { OpenTK.Graphics.OpenGL.GL.Ext.EnableIndexed(target, index); }
        internal override void tkglEnableVariantClientState(Int32 id) { OpenTK.Graphics.OpenGL.GL.Ext.EnableVariantClientState(id); }
        internal override void tkgl2EnableVariantClientState(UInt32 id) { OpenTK.Graphics.OpenGL.GL.Ext.EnableVariantClientState(id); }
        internal override void tkgl2EndTransformFeedback() { OpenTK.Graphics.OpenGL.GL.Ext.EndTransformFeedback(); }
        internal override void tkglEndVertexShader() { OpenTK.Graphics.OpenGL.GL.Ext.EndVertexShader(); }
        internal override void tkglExtractComponent(Int32 res, Int32 src, Int32 num) { OpenTK.Graphics.OpenGL.GL.Ext.ExtractComponent(res, src, num); }
        internal override void tkgl2ExtractComponent(UInt32 res, UInt32 src, UInt32 num) { OpenTK.Graphics.OpenGL.GL.Ext.ExtractComponent(res, src, num); }
        internal override void tkgl5FogCoord(Double coord) { OpenTK.Graphics.OpenGL.GL.Ext.FogCoord(coord); }
        internal override unsafe void tkgl6FogCoord(Double* coord) { OpenTK.Graphics.OpenGL.GL.Ext.FogCoord(coord); }
        internal override void tkgl7FogCoord(Single coord) { OpenTK.Graphics.OpenGL.GL.Ext.FogCoord(coord); }
        internal override unsafe void tkgl8FogCoord(Single* coord) { OpenTK.Graphics.OpenGL.GL.Ext.FogCoord(coord); }
        internal override void tkgl2FogCoordPointer(OpenTK.Graphics.OpenGL.ExtFogCoord type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.FogCoordPointer(type, stride, pointer); }
        internal override void tkglFramebufferDrawBuffer(Int32 framebuffer, OpenTK.Graphics.OpenGL.DrawBufferMode mode) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferDrawBuffer(framebuffer, mode); }
        internal override void tkgl2FramebufferDrawBuffer(UInt32 framebuffer, OpenTK.Graphics.OpenGL.DrawBufferMode mode) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferDrawBuffer(framebuffer, mode); }
        internal override void tkglFramebufferDrawBuffers(Int32 framebuffer, Int32 n, OpenTK.Graphics.OpenGL.DrawBufferMode[] bufs) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferDrawBuffers(framebuffer, n, bufs); }
        internal override void tkgl2FramebufferDrawBuffers(Int32 framebuffer, Int32 n, ref OpenTK.Graphics.OpenGL.DrawBufferMode bufs) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferDrawBuffers(framebuffer, n, ref bufs); }
        internal override unsafe void tkgl3FramebufferDrawBuffers(Int32 framebuffer, Int32 n, OpenTK.Graphics.OpenGL.DrawBufferMode* bufs) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferDrawBuffers(framebuffer, n, bufs); }
        internal override void tkgl4FramebufferDrawBuffers(UInt32 framebuffer, Int32 n, OpenTK.Graphics.OpenGL.DrawBufferMode[] bufs) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferDrawBuffers(framebuffer, n, bufs); }
        internal override void tkgl5FramebufferDrawBuffers(UInt32 framebuffer, Int32 n, ref OpenTK.Graphics.OpenGL.DrawBufferMode bufs) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferDrawBuffers(framebuffer, n, ref bufs); }
        internal override unsafe void tkgl6FramebufferDrawBuffers(UInt32 framebuffer, Int32 n, OpenTK.Graphics.OpenGL.DrawBufferMode* bufs) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferDrawBuffers(framebuffer, n, bufs); }
        internal override void tkglFramebufferReadBuffer(Int32 framebuffer, OpenTK.Graphics.OpenGL.ReadBufferMode mode) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferReadBuffer(framebuffer, mode); }
        internal override void tkgl2FramebufferReadBuffer(UInt32 framebuffer, OpenTK.Graphics.OpenGL.ReadBufferMode mode) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferReadBuffer(framebuffer, mode); }
        internal override void tkgl3FramebufferRenderbuffer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.RenderbufferTarget renderbuffertarget, Int32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer); }
        internal override void tkgl4FramebufferRenderbuffer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.RenderbufferTarget renderbuffertarget, UInt32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferRenderbuffer(target, attachment, renderbuffertarget, renderbuffer); }
        internal override void tkgl3FramebufferTexture1D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTexture1D(target, attachment, textarget, texture, level); }
        internal override void tkgl4FramebufferTexture1D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTexture1D(target, attachment, textarget, texture, level); }
        internal override void tkgl3FramebufferTexture2D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTexture2D(target, attachment, textarget, texture, level); }
        internal override void tkgl4FramebufferTexture2D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTexture2D(target, attachment, textarget, texture, level); }
        internal override void tkgl3FramebufferTexture3D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level, Int32 zoffset) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTexture3D(target, attachment, textarget, texture, level, zoffset); }
        internal override void tkgl4FramebufferTexture3D(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level, Int32 zoffset) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTexture3D(target, attachment, textarget, texture, level, zoffset); }
        internal override void tkgl5FramebufferTexture(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTexture(target, attachment, texture, level); }
        internal override void tkgl6FramebufferTexture(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTexture(target, attachment, texture, level); }
        internal override void tkgl5FramebufferTextureFace(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level, OpenTK.Graphics.OpenGL.TextureTarget face) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTextureFace(target, attachment, texture, level, face); }
        internal override void tkgl6FramebufferTextureFace(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, OpenTK.Graphics.OpenGL.TextureTarget face) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTextureFace(target, attachment, texture, level, face); }
        internal override void tkgl5FramebufferTextureLayer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level, Int32 layer) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTextureLayer(target, attachment, texture, level, layer); }
        internal override void tkgl6FramebufferTextureLayer(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, Int32 layer) { OpenTK.Graphics.OpenGL.GL.Ext.FramebufferTextureLayer(target, attachment, texture, level, layer); }
        internal override void tkgl2GenerateMipmap(OpenTK.Graphics.OpenGL.GenerateMipmapTarget target) { OpenTK.Graphics.OpenGL.GL.Ext.GenerateMipmap(target); }
        internal override void tkglGenerateMultiTexMipmap(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target) { OpenTK.Graphics.OpenGL.GL.Ext.GenerateMultiTexMipmap(texunit, target); }
        internal override void tkglGenerateTextureMipmap(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target) { OpenTK.Graphics.OpenGL.GL.Ext.GenerateTextureMipmap(texture, target); }
        internal override void tkgl2GenerateTextureMipmap(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target) { OpenTK.Graphics.OpenGL.GL.Ext.GenerateTextureMipmap(texture, target); }
        internal override void tkgl7GenFramebuffers(Int32 n, Int32[] framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenFramebuffers(n, framebuffers); }
        internal override void tkgl8GenFramebuffers(Int32 n, out Int32 framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenFramebuffers(n, out framebuffers); }
        internal override unsafe void tkgl9GenFramebuffers(Int32 n, Int32* framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenFramebuffers(n, framebuffers); }
        internal override void tkgl10GenFramebuffers(Int32 n, UInt32[] framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenFramebuffers(n, framebuffers); }
        internal override void tkgl11GenFramebuffers(Int32 n, out UInt32 framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenFramebuffers(n, out framebuffers); }
        internal override unsafe void tkgl12GenFramebuffers(Int32 n, UInt32* framebuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenFramebuffers(n, framebuffers); }
        internal override void tkgl7GenRenderbuffers(Int32 n, Int32[] renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenRenderbuffers(n, renderbuffers); }
        internal override void tkgl8GenRenderbuffers(Int32 n, out Int32 renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenRenderbuffers(n, out renderbuffers); }
        internal override unsafe void tkgl9GenRenderbuffers(Int32 n, Int32* renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenRenderbuffers(n, renderbuffers); }
        internal override void tkgl10GenRenderbuffers(Int32 n, UInt32[] renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenRenderbuffers(n, renderbuffers); }
        internal override void tkgl11GenRenderbuffers(Int32 n, out UInt32 renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenRenderbuffers(n, out renderbuffers); }
        internal override unsafe void tkgl12GenRenderbuffers(Int32 n, UInt32* renderbuffers) { OpenTK.Graphics.OpenGL.GL.Ext.GenRenderbuffers(n, renderbuffers); }
        internal override Int32 tkglGenSymbol(OpenTK.Graphics.OpenGL.ExtVertexShader datatype, OpenTK.Graphics.OpenGL.ExtVertexShader storagetype, OpenTK.Graphics.OpenGL.ExtVertexShader range, Int32 components) { return OpenTK.Graphics.OpenGL.GL.Ext.GenSymbol(datatype, storagetype, range, components); }
        internal override Int32 tkgl2GenSymbol(OpenTK.Graphics.OpenGL.ExtVertexShader datatype, OpenTK.Graphics.OpenGL.ExtVertexShader storagetype, OpenTK.Graphics.OpenGL.ExtVertexShader range, UInt32 components) { return OpenTK.Graphics.OpenGL.GL.Ext.GenSymbol(datatype, storagetype, range, components); }
        internal override void tkgl7GenTextures(Int32 n, Int32[] textures) { OpenTK.Graphics.OpenGL.GL.Ext.GenTextures(n, textures); }
        internal override void tkgl8GenTextures(Int32 n, out Int32 textures) { OpenTK.Graphics.OpenGL.GL.Ext.GenTextures(n, out textures); }
        internal override unsafe void tkgl9GenTextures(Int32 n, Int32* textures) { OpenTK.Graphics.OpenGL.GL.Ext.GenTextures(n, textures); }
        internal override void tkgl10GenTextures(Int32 n, UInt32[] textures) { OpenTK.Graphics.OpenGL.GL.Ext.GenTextures(n, textures); }
        internal override void tkgl11GenTextures(Int32 n, out UInt32 textures) { OpenTK.Graphics.OpenGL.GL.Ext.GenTextures(n, out textures); }
        internal override unsafe void tkgl12GenTextures(Int32 n, UInt32* textures) { OpenTK.Graphics.OpenGL.GL.Ext.GenTextures(n, textures); }
        internal override Int32 tkglGenVertexShaders(Int32 range) { return OpenTK.Graphics.OpenGL.GL.Ext.GenVertexShaders(range); }
        internal override Int32 tkgl2GenVertexShaders(UInt32 range) { return OpenTK.Graphics.OpenGL.GL.Ext.GenVertexShaders(range); }
        internal override void tkglGetBooleanIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index, bool[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetBooleanIndexed(target, index, data); }
        internal override void tkgl2GetBooleanIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index, out bool data) { OpenTK.Graphics.OpenGL.GL.Ext.GetBooleanIndexed(target, index, out data); }
        internal override unsafe void tkgl3GetBooleanIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index, bool* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetBooleanIndexed(target, index, data); }
        internal override void tkgl4GetBooleanIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index, bool[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetBooleanIndexed(target, index, data); }
        internal override void tkgl5GetBooleanIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index, out bool data) { OpenTK.Graphics.OpenGL.GL.Ext.GetBooleanIndexed(target, index, out data); }
        internal override unsafe void tkgl6GetBooleanIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index, bool* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetBooleanIndexed(target, index, data); }
        internal override void tkgl2GetColorTable(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.GetColorTable(target, format, type, data); }
        internal override void tkgl7GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl8GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetColorTableParameter(target, pname, out @params); }
        internal override unsafe void tkgl9GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl10GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl11GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetColorTableParameter(target, pname, out @params); }
        internal override unsafe void tkgl12GetColorTableParameter(OpenTK.Graphics.OpenGL.ColorTableTarget target, OpenTK.Graphics.OpenGL.GetColorTableParameterPName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetColorTableParameter(target, pname, @params); }
        internal override void tkglGetCompressedMultiTexImage(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 lod, IntPtr img) { OpenTK.Graphics.OpenGL.GL.Ext.GetCompressedMultiTexImage(texunit, target, lod, img); }
        internal override void tkglGetCompressedTextureImage(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 lod, IntPtr img) { OpenTK.Graphics.OpenGL.GL.Ext.GetCompressedTextureImage(texture, target, lod, img); }
        internal override void tkgl2GetCompressedTextureImage(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 lod, IntPtr img) { OpenTK.Graphics.OpenGL.GL.Ext.GetCompressedTextureImage(texture, target, lod, img); }
        internal override void tkgl2GetConvolutionFilter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr image) { OpenTK.Graphics.OpenGL.GL.Ext.GetConvolutionFilter(target, format, type, image); }
        internal override void tkgl7GetConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetConvolutionParameter(target, pname, @params); }
        internal override void tkgl8GetConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetConvolutionParameter(target, pname, out @params); }
        internal override unsafe void tkgl9GetConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetConvolutionParameter(target, pname, @params); }
        internal override void tkgl10GetConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetConvolutionParameter(target, pname, @params); }
        internal override void tkgl11GetConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetConvolutionParameter(target, pname, out @params); }
        internal override unsafe void tkgl12GetConvolutionParameter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.ExtConvolution pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetConvolutionParameter(target, pname, @params); }
        internal override void tkglGetDoubleIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Double[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetDoubleIndexed(target, index, data); }
        internal override void tkgl2GetDoubleIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, out Double data) { OpenTK.Graphics.OpenGL.GL.Ext.GetDoubleIndexed(target, index, out data); }
        internal override unsafe void tkgl3GetDoubleIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Double* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetDoubleIndexed(target, index, data); }
        internal override void tkgl4GetDoubleIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Double[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetDoubleIndexed(target, index, data); }
        internal override void tkgl5GetDoubleIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, out Double data) { OpenTK.Graphics.OpenGL.GL.Ext.GetDoubleIndexed(target, index, out data); }
        internal override unsafe void tkgl6GetDoubleIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Double* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetDoubleIndexed(target, index, data); }
        internal override void tkglGetFloatIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Single[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetFloatIndexed(target, index, data); }
        internal override void tkgl2GetFloatIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, out Single data) { OpenTK.Graphics.OpenGL.GL.Ext.GetFloatIndexed(target, index, out data); }
        internal override unsafe void tkgl3GetFloatIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Single* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetFloatIndexed(target, index, data); }
        internal override void tkgl4GetFloatIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Single[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetFloatIndexed(target, index, data); }
        internal override void tkgl5GetFloatIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, out Single data) { OpenTK.Graphics.OpenGL.GL.Ext.GetFloatIndexed(target, index, out data); }
        internal override unsafe void tkgl6GetFloatIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Single* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetFloatIndexed(target, index, data); }
        internal override Int32 tkgl3GetFragDataLocation(Int32 program, String name) { return OpenTK.Graphics.OpenGL.GL.Ext.GetFragDataLocation(program, name); }
        internal override Int32 tkgl4GetFragDataLocation(UInt32 program, String name) { return OpenTK.Graphics.OpenGL.GL.Ext.GetFragDataLocation(program, name); }
        internal override void tkgl4GetFramebufferAttachmentParameter(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.FramebufferParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferAttachmentParameter(target, attachment, pname, @params); }
        internal override void tkgl5GetFramebufferAttachmentParameter(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.FramebufferParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferAttachmentParameter(target, attachment, pname, out @params); }
        internal override unsafe void tkgl6GetFramebufferAttachmentParameter(OpenTK.Graphics.OpenGL.FramebufferTarget target, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.FramebufferParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferAttachmentParameter(target, attachment, pname, @params); }
        internal override void tkglGetFramebufferParameter(Int32 framebuffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferParameter(framebuffer, pname, @params); }
        internal override void tkgl2GetFramebufferParameter(Int32 framebuffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferParameter(framebuffer, pname, out @params); }
        internal override unsafe void tkgl3GetFramebufferParameter(Int32 framebuffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferParameter(framebuffer, pname, @params); }
        internal override void tkgl4GetFramebufferParameter(UInt32 framebuffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferParameter(framebuffer, pname, @params); }
        internal override void tkgl5GetFramebufferParameter(UInt32 framebuffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferParameter(framebuffer, pname, out @params); }
        internal override unsafe void tkgl6GetFramebufferParameter(UInt32 framebuffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetFramebufferParameter(framebuffer, pname, @params); }
        internal override void tkgl2GetHistogram(OpenTK.Graphics.OpenGL.ExtHistogram target, bool reset, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr values) { OpenTK.Graphics.OpenGL.GL.Ext.GetHistogram(target, reset, format, type, values); }
        internal override void tkgl7GetHistogramParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetHistogramParameter(target, pname, @params); }
        internal override void tkgl8GetHistogramParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetHistogramParameter(target, pname, out @params); }
        internal override unsafe void tkgl9GetHistogramParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetHistogramParameter(target, pname, @params); }
        internal override void tkgl10GetHistogramParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetHistogramParameter(target, pname, @params); }
        internal override void tkgl11GetHistogramParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetHistogramParameter(target, pname, out @params); }
        internal override unsafe void tkgl12GetHistogramParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetHistogramParameter(target, pname, @params); }
        internal override void tkglGetIntegerIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index, Int32[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetIntegerIndexed(target, index, data); }
        internal override void tkgl2GetIntegerIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index, out Int32 data) { OpenTK.Graphics.OpenGL.GL.Ext.GetIntegerIndexed(target, index, out data); }
        internal override unsafe void tkgl3GetIntegerIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index, Int32* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetIntegerIndexed(target, index, data); }
        internal override void tkgl4GetIntegerIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index, Int32[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetIntegerIndexed(target, index, data); }
        internal override void tkgl5GetIntegerIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index, out Int32 data) { OpenTK.Graphics.OpenGL.GL.Ext.GetIntegerIndexed(target, index, out data); }
        internal override unsafe void tkgl6GetIntegerIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index, Int32* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetIntegerIndexed(target, index, data); }
        internal override void tkglGetInvariantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantBoolean(id, value, data); }
        internal override void tkgl2GetInvariantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out bool data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantBoolean(id, value, out data); }
        internal override unsafe void tkgl3GetInvariantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantBoolean(id, value, data); }
        internal override void tkgl4GetInvariantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantBoolean(id, value, data); }
        internal override void tkgl5GetInvariantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out bool data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantBoolean(id, value, out data); }
        internal override unsafe void tkgl6GetInvariantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantBoolean(id, value, data); }
        internal override void tkglGetInvariantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantFloat(id, value, data); }
        internal override void tkgl2GetInvariantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Single data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantFloat(id, value, out data); }
        internal override unsafe void tkgl3GetInvariantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantFloat(id, value, data); }
        internal override void tkgl4GetInvariantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantFloat(id, value, data); }
        internal override void tkgl5GetInvariantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Single data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantFloat(id, value, out data); }
        internal override unsafe void tkgl6GetInvariantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantFloat(id, value, data); }
        internal override void tkglGetInvariantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantInteger(id, value, data); }
        internal override void tkgl2GetInvariantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Int32 data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantInteger(id, value, out data); }
        internal override unsafe void tkgl3GetInvariantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantInteger(id, value, data); }
        internal override void tkgl4GetInvariantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantInteger(id, value, data); }
        internal override void tkgl5GetInvariantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Int32 data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantInteger(id, value, out data); }
        internal override unsafe void tkgl6GetInvariantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetInvariantInteger(id, value, data); }
        internal override void tkglGetLocalConstantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantBoolean(id, value, data); }
        internal override void tkgl2GetLocalConstantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out bool data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantBoolean(id, value, out data); }
        internal override unsafe void tkgl3GetLocalConstantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantBoolean(id, value, data); }
        internal override void tkgl4GetLocalConstantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantBoolean(id, value, data); }
        internal override void tkgl5GetLocalConstantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out bool data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantBoolean(id, value, out data); }
        internal override unsafe void tkgl6GetLocalConstantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantBoolean(id, value, data); }
        internal override void tkglGetLocalConstantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantFloat(id, value, data); }
        internal override void tkgl2GetLocalConstantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Single data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantFloat(id, value, out data); }
        internal override unsafe void tkgl3GetLocalConstantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantFloat(id, value, data); }
        internal override void tkgl4GetLocalConstantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantFloat(id, value, data); }
        internal override void tkgl5GetLocalConstantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Single data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantFloat(id, value, out data); }
        internal override unsafe void tkgl6GetLocalConstantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantFloat(id, value, data); }
        internal override void tkglGetLocalConstantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantInteger(id, value, data); }
        internal override void tkgl2GetLocalConstantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Int32 data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantInteger(id, value, out data); }
        internal override unsafe void tkgl3GetLocalConstantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantInteger(id, value, data); }
        internal override void tkgl4GetLocalConstantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantInteger(id, value, data); }
        internal override void tkgl5GetLocalConstantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Int32 data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantInteger(id, value, out data); }
        internal override unsafe void tkgl6GetLocalConstantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetLocalConstantInteger(id, value, data); }
        internal override void tkgl2GetMinmax(OpenTK.Graphics.OpenGL.ExtHistogram target, bool reset, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr values) { OpenTK.Graphics.OpenGL.GL.Ext.GetMinmax(target, reset, format, type, values); }
        internal override void tkgl7GetMinmaxParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMinmaxParameter(target, pname, @params); }
        internal override void tkgl8GetMinmaxParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMinmaxParameter(target, pname, out @params); }
        internal override unsafe void tkgl9GetMinmaxParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMinmaxParameter(target, pname, @params); }
        internal override void tkgl10GetMinmaxParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMinmaxParameter(target, pname, @params); }
        internal override void tkgl11GetMinmaxParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMinmaxParameter(target, pname, out @params); }
        internal override unsafe void tkgl12GetMinmaxParameter(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.ExtHistogram pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMinmaxParameter(target, pname, @params); }
        internal override void tkglGetMultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexEnv(texunit, target, pname, @params); }
        internal override void tkgl2GetMultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexEnv(texunit, target, pname, out @params); }
        internal override unsafe void tkgl3GetMultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexEnv(texunit, target, pname, @params); }
        internal override void tkgl4GetMultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexEnv(texunit, target, pname, @params); }
        internal override void tkgl5GetMultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexEnv(texunit, target, pname, out @params); }
        internal override unsafe void tkgl6GetMultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexEnv(texunit, target, pname, @params); }
        internal override void tkglGetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, @params); }
        internal override void tkgl2GetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, out @params); }
        internal override unsafe void tkgl3GetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, @params); }
        internal override void tkgl4GetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, @params); }
        internal override void tkgl5GetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, out @params); }
        internal override unsafe void tkgl6GetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, @params); }
        internal override void tkgl7GetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, @params); }
        internal override void tkgl8GetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, out @params); }
        internal override unsafe void tkgl9GetMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexGen(texunit, coord, pname, @params); }
        internal override void tkglGetMultiTexImage(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexImage(texunit, target, level, format, type, pixels); }
        internal override void tkglGetMultiTexLevelParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexLevelParameter(texunit, target, level, pname, @params); }
        internal override void tkgl2GetMultiTexLevelParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexLevelParameter(texunit, target, level, pname, out @params); }
        internal override unsafe void tkgl3GetMultiTexLevelParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexLevelParameter(texunit, target, level, pname, @params); }
        internal override void tkgl4GetMultiTexLevelParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexLevelParameter(texunit, target, level, pname, @params); }
        internal override void tkgl5GetMultiTexLevelParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexLevelParameter(texunit, target, level, pname, out @params); }
        internal override unsafe void tkgl6GetMultiTexLevelParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexLevelParameter(texunit, target, level, pname, @params); }
        internal override void tkglGetMultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameter(texunit, target, pname, @params); }
        internal override void tkgl2GetMultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameter(texunit, target, pname, out @params); }
        internal override unsafe void tkgl3GetMultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameter(texunit, target, pname, @params); }
        internal override void tkglGetMultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameterI(texunit, target, pname, @params); }
        internal override void tkgl2GetMultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameterI(texunit, target, pname, out @params); }
        internal override unsafe void tkgl3GetMultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameterI(texunit, target, pname, @params); }
        internal override void tkgl4GetMultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameterI(texunit, target, pname, @params); }
        internal override void tkgl5GetMultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameterI(texunit, target, pname, out @params); }
        internal override unsafe void tkgl6GetMultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameterI(texunit, target, pname, @params); }
        internal override void tkgl4GetMultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameter(texunit, target, pname, @params); }
        internal override void tkgl5GetMultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameter(texunit, target, pname, out @params); }
        internal override unsafe void tkgl6GetMultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetMultiTexParameter(texunit, target, pname, @params); }
        internal override void tkglGetNamedBufferParameter(Int32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferParameter(buffer, pname, @params); }
        internal override void tkgl2GetNamedBufferParameter(Int32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferParameter(buffer, pname, out @params); }
        internal override unsafe void tkgl3GetNamedBufferParameter(Int32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferParameter(buffer, pname, @params); }
        internal override void tkgl4GetNamedBufferParameter(UInt32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferParameter(buffer, pname, @params); }
        internal override void tkgl5GetNamedBufferParameter(UInt32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferParameter(buffer, pname, out @params); }
        internal override unsafe void tkgl6GetNamedBufferParameter(UInt32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferParameter(buffer, pname, @params); }
        internal override void tkglGetNamedBufferPointer(Int32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, IntPtr @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferPointer(buffer, pname, @params); }
        internal override void tkgl2GetNamedBufferPointer(UInt32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, IntPtr @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferPointer(buffer, pname, @params); }
        internal override void tkglGetNamedBufferSubData(Int32 buffer, IntPtr offset, IntPtr size, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferSubData(buffer, offset, size, data); }
        internal override void tkgl2GetNamedBufferSubData(UInt32 buffer, IntPtr offset, IntPtr size, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedBufferSubData(buffer, offset, size, data); }
        internal override void tkglGetNamedFramebufferAttachmentParameter(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedFramebufferAttachmentParameter(framebuffer, attachment, pname, @params); }
        internal override void tkgl2GetNamedFramebufferAttachmentParameter(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedFramebufferAttachmentParameter(framebuffer, attachment, pname, out @params); }
        internal override unsafe void tkgl3GetNamedFramebufferAttachmentParameter(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedFramebufferAttachmentParameter(framebuffer, attachment, pname, @params); }
        internal override void tkgl4GetNamedFramebufferAttachmentParameter(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedFramebufferAttachmentParameter(framebuffer, attachment, pname, @params); }
        internal override void tkgl5GetNamedFramebufferAttachmentParameter(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedFramebufferAttachmentParameter(framebuffer, attachment, pname, out @params); }
        internal override unsafe void tkgl6GetNamedFramebufferAttachmentParameter(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedFramebufferAttachmentParameter(framebuffer, attachment, pname, @params); }
        internal override void tkglGetNamedProgram(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgram(program, target, pname, out @params); }
        internal override unsafe void tkgl2GetNamedProgram(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgram(program, target, pname, @params); }
        internal override void tkgl3GetNamedProgram(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgram(program, target, pname, out @params); }
        internal override unsafe void tkgl4GetNamedProgram(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgram(program, target, pname, @params); }
        internal override void tkglGetNamedProgramLocalParameter(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, @params); }
        internal override void tkgl2GetNamedProgramLocalParameter(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, out Double @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, out @params); }
        internal override unsafe void tkgl3GetNamedProgramLocalParameter(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, @params); }
        internal override void tkgl4GetNamedProgramLocalParameter(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, @params); }
        internal override void tkgl5GetNamedProgramLocalParameter(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, out Double @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, out @params); }
        internal override unsafe void tkgl6GetNamedProgramLocalParameter(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, @params); }
        internal override void tkgl7GetNamedProgramLocalParameter(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, @params); }
        internal override void tkgl8GetNamedProgramLocalParameter(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, out @params); }
        internal override unsafe void tkgl9GetNamedProgramLocalParameter(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, @params); }
        internal override void tkgl10GetNamedProgramLocalParameter(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, @params); }
        internal override void tkgl11GetNamedProgramLocalParameter(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, out @params); }
        internal override unsafe void tkgl12GetNamedProgramLocalParameter(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameter(program, target, index, @params); }
        internal override void tkglGetNamedProgramLocalParameterI(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, @params); }
        internal override void tkgl2GetNamedProgramLocalParameterI(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, out @params); }
        internal override unsafe void tkgl3GetNamedProgramLocalParameterI(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, @params); }
        internal override void tkgl4GetNamedProgramLocalParameterI(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, @params); }
        internal override void tkgl5GetNamedProgramLocalParameterI(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, out @params); }
        internal override unsafe void tkgl6GetNamedProgramLocalParameterI(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, @params); }
        internal override void tkgl7GetNamedProgramLocalParameterI(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, @params); }
        internal override void tkgl8GetNamedProgramLocalParameterI(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, out @params); }
        internal override unsafe void tkgl9GetNamedProgramLocalParameterI(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramLocalParameterI(program, target, index, @params); }
        internal override void tkglGetNamedProgramString(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, IntPtr @string) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramString(program, target, pname, @string); }
        internal override void tkgl2GetNamedProgramString(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess pname, IntPtr @string) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedProgramString(program, target, pname, @string); }
        internal override void tkglGetNamedRenderbufferParameter(Int32 renderbuffer, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedRenderbufferParameter(renderbuffer, pname, @params); }
        internal override void tkgl2GetNamedRenderbufferParameter(Int32 renderbuffer, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedRenderbufferParameter(renderbuffer, pname, out @params); }
        internal override unsafe void tkgl3GetNamedRenderbufferParameter(Int32 renderbuffer, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedRenderbufferParameter(renderbuffer, pname, @params); }
        internal override void tkgl4GetNamedRenderbufferParameter(UInt32 renderbuffer, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedRenderbufferParameter(renderbuffer, pname, @params); }
        internal override void tkgl5GetNamedRenderbufferParameter(UInt32 renderbuffer, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedRenderbufferParameter(renderbuffer, pname, out @params); }
        internal override unsafe void tkgl6GetNamedRenderbufferParameter(UInt32 renderbuffer, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetNamedRenderbufferParameter(renderbuffer, pname, @params); }
        internal override void tkglGetPointerIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.GetPointerIndexed(target, index, data); }
        internal override void tkgl2GetPointerIndexed(OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.GetPointerIndexed(target, index, data); }
        internal override void tkgl2GetPointer(OpenTK.Graphics.OpenGL.GetPointervPName pname, IntPtr @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetPointer(pname, @params); }
        internal override void tkglGetQueryObjecti64(Int32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, Int64[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjecti64(id, pname, @params); }
        internal override void tkgl2GetQueryObjecti64(Int32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, out Int64 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjecti64(id, pname, out @params); }
        internal override unsafe void tkgl3GetQueryObjecti64(Int32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, Int64* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjecti64(id, pname, @params); }
        internal override void tkgl4GetQueryObjecti64(UInt32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, Int64[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjecti64(id, pname, @params); }
        internal override void tkgl5GetQueryObjecti64(UInt32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, out Int64 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjecti64(id, pname, out @params); }
        internal override unsafe void tkgl6GetQueryObjecti64(UInt32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, Int64* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjecti64(id, pname, @params); }
        internal override void tkglGetQueryObjectui64(Int32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, Int64[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjectui64(id, pname, @params); }
        internal override void tkgl2GetQueryObjectui64(Int32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, out Int64 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjectui64(id, pname, out @params); }
        internal override unsafe void tkgl3GetQueryObjectui64(Int32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, Int64* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjectui64(id, pname, @params); }
        internal override void tkgl4GetQueryObjectui64(UInt32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, UInt64[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjectui64(id, pname, @params); }
        internal override void tkgl5GetQueryObjectui64(UInt32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, out UInt64 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjectui64(id, pname, out @params); }
        internal override unsafe void tkgl6GetQueryObjectui64(UInt32 id, OpenTK.Graphics.OpenGL.ExtTimerQuery pname, UInt64* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetQueryObjectui64(id, pname, @params); }
        internal override void tkgl4GetRenderbufferParameter(OpenTK.Graphics.OpenGL.RenderbufferTarget target, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetRenderbufferParameter(target, pname, @params); }
        internal override void tkgl5GetRenderbufferParameter(OpenTK.Graphics.OpenGL.RenderbufferTarget target, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetRenderbufferParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetRenderbufferParameter(OpenTK.Graphics.OpenGL.RenderbufferTarget target, OpenTK.Graphics.OpenGL.RenderbufferParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetRenderbufferParameter(target, pname, @params); }
        internal override void tkgl2GetSeparableFilter(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr row, IntPtr column, IntPtr span) { OpenTK.Graphics.OpenGL.GL.Ext.GetSeparableFilter(target, format, type, row, column, span); }
        internal override void tkgl7GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTexParameterI(target, pname, @params); }
        internal override void tkgl8GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTexParameterI(target, pname, out @params); }
        internal override unsafe void tkgl9GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTexParameterI(target, pname, @params); }
        internal override void tkgl10GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTexParameterI(target, pname, @params); }
        internal override void tkgl11GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTexParameterI(target, pname, out @params); }
        internal override unsafe void tkgl12GetTexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTexParameterI(target, pname, @params); }
        internal override void tkglGetTextureImage(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureImage(texture, target, level, format, type, pixels); }
        internal override void tkgl2GetTextureImage(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureImage(texture, target, level, format, type, pixels); }
        internal override void tkglGetTextureLevelParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, @params); }
        internal override void tkgl2GetTextureLevelParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, out @params); }
        internal override unsafe void tkgl3GetTextureLevelParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, @params); }
        internal override void tkgl4GetTextureLevelParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, @params); }
        internal override void tkgl5GetTextureLevelParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, out @params); }
        internal override unsafe void tkgl6GetTextureLevelParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, @params); }
        internal override void tkgl7GetTextureLevelParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, @params); }
        internal override void tkgl8GetTextureLevelParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, out @params); }
        internal override unsafe void tkgl9GetTextureLevelParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, @params); }
        internal override void tkgl10GetTextureLevelParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, @params); }
        internal override void tkgl11GetTextureLevelParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, out @params); }
        internal override unsafe void tkgl12GetTextureLevelParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureLevelParameter(texture, target, level, pname, @params); }
        internal override void tkglGetTextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, @params); }
        internal override void tkgl2GetTextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, out @params); }
        internal override unsafe void tkgl3GetTextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, @params); }
        internal override void tkgl4GetTextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, @params); }
        internal override void tkgl5GetTextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, out @params); }
        internal override unsafe void tkgl6GetTextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, @params); }
        internal override void tkglGetTextureParameterI(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, @params); }
        internal override void tkgl2GetTextureParameterI(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, out @params); }
        internal override unsafe void tkgl3GetTextureParameterI(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, @params); }
        internal override void tkgl4GetTextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, @params); }
        internal override void tkgl5GetTextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, out @params); }
        internal override unsafe void tkgl6GetTextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, @params); }
        internal override void tkgl7GetTextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, @params); }
        internal override void tkgl8GetTextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, out @params); }
        internal override unsafe void tkgl9GetTextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameterI(texture, target, pname, @params); }
        internal override void tkgl7GetTextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, @params); }
        internal override void tkgl8GetTextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, out @params); }
        internal override unsafe void tkgl9GetTextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, @params); }
        internal override void tkgl10GetTextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, @params); }
        internal override void tkgl11GetTextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, out @params); }
        internal override unsafe void tkgl12GetTextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.GetTextureParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetTextureParameter(texture, target, pname, @params); }
        internal override void tkgl5GetTransformFeedbackVarying(Int32 program, Int32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ExtTransformFeedback type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Ext.GetTransformFeedbackVarying(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl6GetTransformFeedbackVarying(Int32 program, Int32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ExtTransformFeedback* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Ext.GetTransformFeedbackVarying(program, index, bufSize, length, size, type, name); }
        internal override void tkgl7GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.ExtTransformFeedback type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Ext.GetTransformFeedbackVarying(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl8GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.ExtTransformFeedback* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.Ext.GetTransformFeedbackVarying(program, index, bufSize, length, size, type, name); }
        internal override Int32 tkglGetUniformBufferSize(Int32 program, Int32 location) { return OpenTK.Graphics.OpenGL.GL.Ext.GetUniformBufferSize(program, location); }
        internal override Int32 tkgl2GetUniformBufferSize(UInt32 program, Int32 location) { return OpenTK.Graphics.OpenGL.GL.Ext.GetUniformBufferSize(program, location); }
        internal override IntPtr tkglGetUniformOffset(Int32 program, Int32 location) { return OpenTK.Graphics.OpenGL.GL.Ext.GetUniformOffset(program, location); }
        internal override IntPtr tkgl2GetUniformOffset(UInt32 program, Int32 location) { return OpenTK.Graphics.OpenGL.GL.Ext.GetUniformOffset(program, location); }
        internal override void tkgl28GetUniform(Int32 program, Int32 location, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetUniform(program, location, @params); }
        internal override void tkgl29GetUniform(Int32 program, Int32 location, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetUniform(program, location, out @params); }
        internal override unsafe void tkgl30GetUniform(Int32 program, Int32 location, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetUniform(program, location, @params); }
        internal override void tkgl31GetUniform(UInt32 program, Int32 location, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetUniform(program, location, @params); }
        internal override void tkgl32GetUniform(UInt32 program, Int32 location, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetUniform(program, location, out @params); }
        internal override unsafe void tkgl33GetUniform(UInt32 program, Int32 location, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetUniform(program, location, @params); }
        internal override void tkglGetVariantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantBoolean(id, value, data); }
        internal override void tkgl2GetVariantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out bool data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantBoolean(id, value, out data); }
        internal override unsafe void tkgl3GetVariantBoolean(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantBoolean(id, value, data); }
        internal override void tkgl4GetVariantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantBoolean(id, value, data); }
        internal override void tkgl5GetVariantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out bool data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantBoolean(id, value, out data); }
        internal override unsafe void tkgl6GetVariantBoolean(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, bool* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantBoolean(id, value, data); }
        internal override void tkglGetVariantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantFloat(id, value, data); }
        internal override void tkgl2GetVariantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Single data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantFloat(id, value, out data); }
        internal override unsafe void tkgl3GetVariantFloat(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantFloat(id, value, data); }
        internal override void tkgl4GetVariantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantFloat(id, value, data); }
        internal override void tkgl5GetVariantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Single data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantFloat(id, value, out data); }
        internal override unsafe void tkgl6GetVariantFloat(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Single* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantFloat(id, value, data); }
        internal override void tkglGetVariantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantInteger(id, value, data); }
        internal override void tkgl2GetVariantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Int32 data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantInteger(id, value, out data); }
        internal override unsafe void tkgl3GetVariantInteger(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantInteger(id, value, data); }
        internal override void tkgl4GetVariantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32[] data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantInteger(id, value, data); }
        internal override void tkgl5GetVariantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, out Int32 data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantInteger(id, value, out data); }
        internal override unsafe void tkgl6GetVariantInteger(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, Int32* data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantInteger(id, value, data); }
        internal override void tkglGetVariantPointer(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantPointer(id, value, data); }
        internal override void tkgl2GetVariantPointer(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader value, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.GetVariantPointer(id, value, data); }
        internal override void tkgl7GetVertexAttribI(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram4 pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetVertexAttribI(index, pname, out @params); }
        internal override unsafe void tkgl8GetVertexAttribI(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram4 pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetVertexAttribI(index, pname, @params); }
        internal override void tkgl9GetVertexAttribI(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram4 pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetVertexAttribI(index, pname, out @params); }
        internal override unsafe void tkgl10GetVertexAttribI(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram4 pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetVertexAttribI(index, pname, @params); }
        internal override void tkgl11GetVertexAttribI(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram4 pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetVertexAttribI(index, pname, out @params); }
        internal override unsafe void tkgl12GetVertexAttribI(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram4 pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.GetVertexAttribI(index, pname, @params); }
        internal override void tkgl2Histogram(OpenTK.Graphics.OpenGL.ExtHistogram target, Int32 width, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, bool sink) { OpenTK.Graphics.OpenGL.GL.Ext.Histogram(target, width, internalformat, sink); }
        internal override void tkglIndexFunc(OpenTK.Graphics.OpenGL.ExtIndexFunc func, Single @ref) { OpenTK.Graphics.OpenGL.GL.Ext.IndexFunc(func, @ref); }
        internal override void tkglIndexMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.ExtIndexMaterial mode) { OpenTK.Graphics.OpenGL.GL.Ext.IndexMaterial(face, mode); }
        internal override void tkgl2IndexPointer(OpenTK.Graphics.OpenGL.IndexPointerType type, Int32 stride, Int32 count, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.IndexPointer(type, stride, count, pointer); }
        internal override void tkglInsertComponent(Int32 res, Int32 src, Int32 num) { OpenTK.Graphics.OpenGL.GL.Ext.InsertComponent(res, src, num); }
        internal override void tkgl2InsertComponent(UInt32 res, UInt32 src, UInt32 num) { OpenTK.Graphics.OpenGL.GL.Ext.InsertComponent(res, src, num); }
        internal override bool tkglIsEnabledIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, Int32 index) { return OpenTK.Graphics.OpenGL.GL.Ext.IsEnabledIndexed(target, index); }
        internal override bool tkgl2IsEnabledIndexed(OpenTK.Graphics.OpenGL.ExtDrawBuffers2 target, UInt32 index) { return OpenTK.Graphics.OpenGL.GL.Ext.IsEnabledIndexed(target, index); }
        internal override bool tkgl3IsFramebuffer(Int32 framebuffer) { return OpenTK.Graphics.OpenGL.GL.Ext.IsFramebuffer(framebuffer); }
        internal override bool tkgl4IsFramebuffer(UInt32 framebuffer) { return OpenTK.Graphics.OpenGL.GL.Ext.IsFramebuffer(framebuffer); }
        internal override bool tkgl3IsRenderbuffer(Int32 renderbuffer) { return OpenTK.Graphics.OpenGL.GL.Ext.IsRenderbuffer(renderbuffer); }
        internal override bool tkgl4IsRenderbuffer(UInt32 renderbuffer) { return OpenTK.Graphics.OpenGL.GL.Ext.IsRenderbuffer(renderbuffer); }
        internal override bool tkgl3IsTexture(Int32 texture) { return OpenTK.Graphics.OpenGL.GL.Ext.IsTexture(texture); }
        internal override bool tkgl4IsTexture(UInt32 texture) { return OpenTK.Graphics.OpenGL.GL.Ext.IsTexture(texture); }
        internal override bool tkglIsVariantEnabled(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader cap) { return OpenTK.Graphics.OpenGL.GL.Ext.IsVariantEnabled(id, cap); }
        internal override bool tkgl2IsVariantEnabled(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader cap) { return OpenTK.Graphics.OpenGL.GL.Ext.IsVariantEnabled(id, cap); }
        internal override void tkglLockArrays(Int32 first, Int32 count) { OpenTK.Graphics.OpenGL.GL.Ext.LockArrays(first, count); }
        internal override unsafe System.IntPtr tkglMapNamedBuffer(Int32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess access) { return OpenTK.Graphics.OpenGL.GL.Ext.MapNamedBuffer(buffer, access); }
        internal override unsafe System.IntPtr tkgl2MapNamedBuffer(UInt32 buffer, OpenTK.Graphics.OpenGL.ExtDirectStateAccess access) { return OpenTK.Graphics.OpenGL.GL.Ext.MapNamedBuffer(buffer, access); }
        internal override void tkglMatrixFrustum(OpenTK.Graphics.OpenGL.MatrixMode mode, Double left, Double right, Double bottom, Double top, Double zNear, Double zFar) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixFrustum(mode, left, right, bottom, top, zNear, zFar); }
        internal override void tkglMatrixLoad(OpenTK.Graphics.OpenGL.MatrixMode mode, Double[] m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoad(mode, m); }
        internal override void tkgl2MatrixLoad(OpenTK.Graphics.OpenGL.MatrixMode mode, ref Double m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoad(mode, ref m); }
        internal override unsafe void tkgl3MatrixLoad(OpenTK.Graphics.OpenGL.MatrixMode mode, Double* m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoad(mode, m); }
        internal override void tkgl4MatrixLoad(OpenTK.Graphics.OpenGL.MatrixMode mode, Single[] m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoad(mode, m); }
        internal override void tkgl5MatrixLoad(OpenTK.Graphics.OpenGL.MatrixMode mode, ref Single m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoad(mode, ref m); }
        internal override unsafe void tkgl6MatrixLoad(OpenTK.Graphics.OpenGL.MatrixMode mode, Single* m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoad(mode, m); }
        internal override void tkglMatrixLoadIdentity(OpenTK.Graphics.OpenGL.MatrixMode mode) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoadIdentity(mode); }
        internal override void tkglMatrixLoadTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, Double[] m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoadTranspose(mode, m); }
        internal override void tkgl2MatrixLoadTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, ref Double m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoadTranspose(mode, ref m); }
        internal override unsafe void tkgl3MatrixLoadTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, Double* m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoadTranspose(mode, m); }
        internal override void tkgl4MatrixLoadTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, Single[] m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoadTranspose(mode, m); }
        internal override void tkgl5MatrixLoadTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, ref Single m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoadTranspose(mode, ref m); }
        internal override unsafe void tkgl6MatrixLoadTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, Single* m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixLoadTranspose(mode, m); }
        internal override void tkglMatrixMult(OpenTK.Graphics.OpenGL.MatrixMode mode, Double[] m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMult(mode, m); }
        internal override void tkgl2MatrixMult(OpenTK.Graphics.OpenGL.MatrixMode mode, ref Double m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMult(mode, ref m); }
        internal override unsafe void tkgl3MatrixMult(OpenTK.Graphics.OpenGL.MatrixMode mode, Double* m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMult(mode, m); }
        internal override void tkgl4MatrixMult(OpenTK.Graphics.OpenGL.MatrixMode mode, Single[] m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMult(mode, m); }
        internal override void tkgl5MatrixMult(OpenTK.Graphics.OpenGL.MatrixMode mode, ref Single m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMult(mode, ref m); }
        internal override unsafe void tkgl6MatrixMult(OpenTK.Graphics.OpenGL.MatrixMode mode, Single* m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMult(mode, m); }
        internal override void tkglMatrixMultTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, Double[] m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMultTranspose(mode, m); }
        internal override void tkgl2MatrixMultTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, ref Double m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMultTranspose(mode, ref m); }
        internal override unsafe void tkgl3MatrixMultTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, Double* m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMultTranspose(mode, m); }
        internal override void tkgl4MatrixMultTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, Single[] m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMultTranspose(mode, m); }
        internal override void tkgl5MatrixMultTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, ref Single m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMultTranspose(mode, ref m); }
        internal override unsafe void tkgl6MatrixMultTranspose(OpenTK.Graphics.OpenGL.MatrixMode mode, Single* m) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixMultTranspose(mode, m); }
        internal override void tkglMatrixOrtho(OpenTK.Graphics.OpenGL.MatrixMode mode, Double left, Double right, Double bottom, Double top, Double zNear, Double zFar) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixOrtho(mode, left, right, bottom, top, zNear, zFar); }
        internal override void tkglMatrixPop(OpenTK.Graphics.OpenGL.MatrixMode mode) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixPop(mode); }
        internal override void tkglMatrixPush(OpenTK.Graphics.OpenGL.MatrixMode mode) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixPush(mode); }
        internal override void tkglMatrixRotate(OpenTK.Graphics.OpenGL.MatrixMode mode, Double angle, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixRotate(mode, angle, x, y, z); }
        internal override void tkgl2MatrixRotate(OpenTK.Graphics.OpenGL.MatrixMode mode, Single angle, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixRotate(mode, angle, x, y, z); }
        internal override void tkglMatrixScale(OpenTK.Graphics.OpenGL.MatrixMode mode, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixScale(mode, x, y, z); }
        internal override void tkgl2MatrixScale(OpenTK.Graphics.OpenGL.MatrixMode mode, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixScale(mode, x, y, z); }
        internal override void tkglMatrixTranslate(OpenTK.Graphics.OpenGL.MatrixMode mode, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixTranslate(mode, x, y, z); }
        internal override void tkgl2MatrixTranslate(OpenTK.Graphics.OpenGL.MatrixMode mode, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Ext.MatrixTranslate(mode, x, y, z); }
        internal override void tkgl2Minmax(OpenTK.Graphics.OpenGL.ExtHistogram target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, bool sink) { OpenTK.Graphics.OpenGL.GL.Ext.Minmax(target, internalformat, sink); }
        internal override void tkgl4MultiDrawArrays(OpenTK.Graphics.OpenGL.BeginMode mode, Int32[] first, Int32[] count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Ext.MultiDrawArrays(mode, first, count, primcount); }
        internal override void tkgl5MultiDrawArrays(OpenTK.Graphics.OpenGL.BeginMode mode, out Int32 first, out Int32 count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Ext.MultiDrawArrays(mode, out first, out count, primcount); }
        internal override unsafe void tkgl6MultiDrawArrays(OpenTK.Graphics.OpenGL.BeginMode mode, Int32* first, Int32* count, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Ext.MultiDrawArrays(mode, first, count, primcount); }
        internal override void tkgl4MultiDrawElements(OpenTK.Graphics.OpenGL.BeginMode mode, Int32[] count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Ext.MultiDrawElements(mode, count, type, indices, primcount); }
        internal override void tkgl5MultiDrawElements(OpenTK.Graphics.OpenGL.BeginMode mode, ref Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Ext.MultiDrawElements(mode, ref count, type, indices, primcount); }
        internal override unsafe void tkgl6MultiDrawElements(OpenTK.Graphics.OpenGL.BeginMode mode, Int32* count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount) { OpenTK.Graphics.OpenGL.GL.Ext.MultiDrawElements(mode, count, type, indices, primcount); }
        internal override void tkglMultiTexBuffer(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexBuffer(texunit, target, internalformat, buffer); }
        internal override void tkgl2MultiTexBuffer(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexBuffer(texunit, target, internalformat, buffer); }
        internal override void tkglMultiTexCoordPointer(OpenTK.Graphics.OpenGL.TextureUnit texunit, Int32 size, OpenTK.Graphics.OpenGL.TexCoordPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexCoordPointer(texunit, size, type, stride, pointer); }
        internal override void tkglMultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexEnv(texunit, target, pname, param); }
        internal override void tkgl2MultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexEnv(texunit, target, pname, @params); }
        internal override unsafe void tkgl3MultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexEnv(texunit, target, pname, @params); }
        internal override void tkgl4MultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexEnv(texunit, target, pname, param); }
        internal override void tkgl5MultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexEnv(texunit, target, pname, @params); }
        internal override unsafe void tkgl6MultiTexEnv(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureEnvTarget target, OpenTK.Graphics.OpenGL.TextureEnvParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexEnv(texunit, target, pname, @params); }
        internal override void tkglMultiTexGend(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double param) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGend(texunit, coord, pname, param); }
        internal override void tkglMultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, @params); }
        internal override void tkgl2MultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, ref Double @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, ref @params); }
        internal override unsafe void tkgl3MultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, @params); }
        internal override void tkgl4MultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, param); }
        internal override void tkgl5MultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, @params); }
        internal override unsafe void tkgl6MultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, @params); }
        internal override void tkgl7MultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, param); }
        internal override void tkgl8MultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, @params); }
        internal override unsafe void tkgl9MultiTexGen(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureCoordName coord, OpenTK.Graphics.OpenGL.TextureGenParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexGen(texunit, coord, pname, @params); }
        internal override void tkglMultiTexImage1D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexImage1D(texunit, target, level, internalformat, width, border, format, type, pixels); }
        internal override void tkglMultiTexImage2D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexImage2D(texunit, target, level, internalformat, width, height, border, format, type, pixels); }
        internal override void tkglMultiTexImage3D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexImage3D(texunit, target, level, internalformat, width, height, depth, border, format, type, pixels); }
        internal override void tkglMultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameter(texunit, target, pname, param); }
        internal override void tkgl2MultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameter(texunit, target, pname, @params); }
        internal override unsafe void tkgl3MultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameter(texunit, target, pname, @params); }
        internal override void tkgl4MultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameter(texunit, target, pname, param); }
        internal override void tkglMultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameterI(texunit, target, pname, @params); }
        internal override void tkgl2MultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameterI(texunit, target, pname, ref @params); }
        internal override unsafe void tkgl3MultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameterI(texunit, target, pname, @params); }
        internal override void tkgl4MultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameterI(texunit, target, pname, @params); }
        internal override void tkgl5MultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameterI(texunit, target, pname, ref @params); }
        internal override unsafe void tkgl6MultiTexParameterI(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameterI(texunit, target, pname, @params); }
        internal override void tkgl5MultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameter(texunit, target, pname, @params); }
        internal override unsafe void tkgl6MultiTexParameter(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexParameter(texunit, target, pname, @params); }
        internal override void tkglMultiTexRenderbuffer(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexRenderbuffer(texunit, target, renderbuffer); }
        internal override void tkgl2MultiTexRenderbuffer(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, UInt32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexRenderbuffer(texunit, target, renderbuffer); }
        internal override void tkglMultiTexSubImage1D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexSubImage1D(texunit, target, level, xoffset, width, format, type, pixels); }
        internal override void tkglMultiTexSubImage2D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexSubImage2D(texunit, target, level, xoffset, yoffset, width, height, format, type, pixels); }
        internal override void tkglMultiTexSubImage3D(OpenTK.Graphics.OpenGL.TextureUnit texunit, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.MultiTexSubImage3D(texunit, target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels); }
        internal override void tkglNamedBufferData(Int32 buffer, IntPtr size, IntPtr data, OpenTK.Graphics.OpenGL.ExtDirectStateAccess usage) { OpenTK.Graphics.OpenGL.GL.Ext.NamedBufferData(buffer, size, data, usage); }
        internal override void tkgl2NamedBufferData(UInt32 buffer, IntPtr size, IntPtr data, OpenTK.Graphics.OpenGL.ExtDirectStateAccess usage) { OpenTK.Graphics.OpenGL.GL.Ext.NamedBufferData(buffer, size, data, usage); }
        internal override void tkglNamedBufferSubData(Int32 buffer, IntPtr offset, IntPtr size, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.NamedBufferSubData(buffer, offset, size, data); }
        internal override void tkgl2NamedBufferSubData(UInt32 buffer, IntPtr offset, IntPtr size, IntPtr data) { OpenTK.Graphics.OpenGL.GL.Ext.NamedBufferSubData(buffer, offset, size, data); }
        internal override void tkglNamedFramebufferRenderbuffer(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.RenderbufferTarget renderbuffertarget, Int32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferRenderbuffer(framebuffer, attachment, renderbuffertarget, renderbuffer); }
        internal override void tkgl2NamedFramebufferRenderbuffer(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.RenderbufferTarget renderbuffertarget, UInt32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferRenderbuffer(framebuffer, attachment, renderbuffertarget, renderbuffer); }
        internal override void tkglNamedFramebufferTexture1D(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTexture1D(framebuffer, attachment, textarget, texture, level); }
        internal override void tkgl2NamedFramebufferTexture1D(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTexture1D(framebuffer, attachment, textarget, texture, level); }
        internal override void tkglNamedFramebufferTexture2D(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTexture2D(framebuffer, attachment, textarget, texture, level); }
        internal override void tkgl2NamedFramebufferTexture2D(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTexture2D(framebuffer, attachment, textarget, texture, level); }
        internal override void tkglNamedFramebufferTexture3D(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, Int32 texture, Int32 level, Int32 zoffset) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTexture3D(framebuffer, attachment, textarget, texture, level, zoffset); }
        internal override void tkgl2NamedFramebufferTexture3D(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, OpenTK.Graphics.OpenGL.TextureTarget textarget, UInt32 texture, Int32 level, Int32 zoffset) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTexture3D(framebuffer, attachment, textarget, texture, level, zoffset); }
        internal override void tkglNamedFramebufferTexture(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTexture(framebuffer, attachment, texture, level); }
        internal override void tkgl2NamedFramebufferTexture(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTexture(framebuffer, attachment, texture, level); }
        internal override void tkglNamedFramebufferTextureFace(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level, OpenTK.Graphics.OpenGL.TextureTarget face) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTextureFace(framebuffer, attachment, texture, level, face); }
        internal override void tkgl2NamedFramebufferTextureFace(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, OpenTK.Graphics.OpenGL.TextureTarget face) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTextureFace(framebuffer, attachment, texture, level, face); }
        internal override void tkglNamedFramebufferTextureLayer(Int32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, Int32 texture, Int32 level, Int32 layer) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTextureLayer(framebuffer, attachment, texture, level, layer); }
        internal override void tkgl2NamedFramebufferTextureLayer(UInt32 framebuffer, OpenTK.Graphics.OpenGL.FramebufferAttachment attachment, UInt32 texture, Int32 level, Int32 layer) { OpenTK.Graphics.OpenGL.GL.Ext.NamedFramebufferTextureLayer(framebuffer, attachment, texture, level, layer); }
        internal override void tkglNamedProgramLocalParameter4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, x, y, z, w); }
        internal override void tkgl2NamedProgramLocalParameter4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, x, y, z, w); }
        internal override void tkgl3NamedProgramLocalParameter4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, @params); }
        internal override void tkgl4NamedProgramLocalParameter4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, ref Double @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, ref @params); }
        internal override unsafe void tkgl5NamedProgramLocalParameter4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, @params); }
        internal override void tkgl6NamedProgramLocalParameter4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Double[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, @params); }
        internal override void tkgl7NamedProgramLocalParameter4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, ref Double @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, ref @params); }
        internal override unsafe void tkgl8NamedProgramLocalParameter4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Double* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, @params); }
        internal override void tkgl9NamedProgramLocalParameter4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, x, y, z, w); }
        internal override void tkgl10NamedProgramLocalParameter4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, x, y, z, w); }
        internal override void tkgl11NamedProgramLocalParameter4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, @params); }
        internal override void tkgl12NamedProgramLocalParameter4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, ref @params); }
        internal override unsafe void tkgl13NamedProgramLocalParameter4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, @params); }
        internal override void tkgl14NamedProgramLocalParameter4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, @params); }
        internal override void tkgl15NamedProgramLocalParameter4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, ref @params); }
        internal override unsafe void tkgl16NamedProgramLocalParameter4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameter4(program, target, index, @params); }
        internal override void tkglNamedProgramLocalParameterI4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, x, y, z, w); }
        internal override void tkgl2NamedProgramLocalParameterI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, x, y, z, w); }
        internal override void tkgl3NamedProgramLocalParameterI4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, @params); }
        internal override void tkgl4NamedProgramLocalParameterI4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, ref @params); }
        internal override unsafe void tkgl5NamedProgramLocalParameterI4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, @params); }
        internal override void tkgl6NamedProgramLocalParameterI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, @params); }
        internal override void tkgl7NamedProgramLocalParameterI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, ref @params); }
        internal override unsafe void tkgl8NamedProgramLocalParameterI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, @params); }
        internal override void tkgl9NamedProgramLocalParameterI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, UInt32 x, UInt32 y, UInt32 z, UInt32 w) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, x, y, z, w); }
        internal override void tkgl10NamedProgramLocalParameterI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, @params); }
        internal override void tkgl11NamedProgramLocalParameterI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, ref @params); }
        internal override unsafe void tkgl12NamedProgramLocalParameterI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameterI4(program, target, index, @params); }
        internal override void tkglNamedProgramLocalParameters4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32 count, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameters4(program, target, index, count, @params); }
        internal override void tkgl2NamedProgramLocalParameters4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32 count, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameters4(program, target, index, count, ref @params); }
        internal override unsafe void tkgl3NamedProgramLocalParameters4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32 count, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameters4(program, target, index, count, @params); }
        internal override void tkgl4NamedProgramLocalParameters4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameters4(program, target, index, count, @params); }
        internal override void tkgl5NamedProgramLocalParameters4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameters4(program, target, index, count, ref @params); }
        internal override unsafe void tkgl6NamedProgramLocalParameters4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParameters4(program, target, index, count, @params); }
        internal override void tkglNamedProgramLocalParametersI4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32 count, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, @params); }
        internal override void tkgl2NamedProgramLocalParametersI4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32 count, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, ref @params); }
        internal override unsafe void tkgl3NamedProgramLocalParametersI4(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, Int32 index, Int32 count, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, @params); }
        internal override void tkgl4NamedProgramLocalParametersI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, @params); }
        internal override void tkgl5NamedProgramLocalParametersI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, ref @params); }
        internal override unsafe void tkgl6NamedProgramLocalParametersI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, @params); }
        internal override void tkgl7NamedProgramLocalParametersI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, @params); }
        internal override void tkgl8NamedProgramLocalParametersI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, ref @params); }
        internal override unsafe void tkgl9NamedProgramLocalParametersI4(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, UInt32 index, Int32 count, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramLocalParametersI4(program, target, index, count, @params); }
        internal override void tkglNamedProgramString(Int32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess format, Int32 len, IntPtr @string) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramString(program, target, format, len, @string); }
        internal override void tkgl2NamedProgramString(UInt32 program, OpenTK.Graphics.OpenGL.ExtDirectStateAccess target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess format, Int32 len, IntPtr @string) { OpenTK.Graphics.OpenGL.GL.Ext.NamedProgramString(program, target, format, len, @string); }
        internal override void tkglNamedRenderbufferStorage(Int32 renderbuffer, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.NamedRenderbufferStorage(renderbuffer, internalformat, width, height); }
        internal override void tkgl2NamedRenderbufferStorage(UInt32 renderbuffer, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.NamedRenderbufferStorage(renderbuffer, internalformat, width, height); }
        internal override void tkglNamedRenderbufferStorageMultisampleCoverage(Int32 renderbuffer, Int32 coverageSamples, Int32 colorSamples, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.NamedRenderbufferStorageMultisampleCoverage(renderbuffer, coverageSamples, colorSamples, internalformat, width, height); }
        internal override void tkgl2NamedRenderbufferStorageMultisampleCoverage(UInt32 renderbuffer, Int32 coverageSamples, Int32 colorSamples, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.NamedRenderbufferStorageMultisampleCoverage(renderbuffer, coverageSamples, colorSamples, internalformat, width, height); }
        internal override void tkglNamedRenderbufferStorageMultisample(Int32 renderbuffer, Int32 samples, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.NamedRenderbufferStorageMultisample(renderbuffer, samples, internalformat, width, height); }
        internal override void tkgl2NamedRenderbufferStorageMultisample(UInt32 renderbuffer, Int32 samples, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.NamedRenderbufferStorageMultisample(renderbuffer, samples, internalformat, width, height); }
        internal override void tkgl2NormalPointer(OpenTK.Graphics.OpenGL.NormalPointerType type, Int32 stride, Int32 count, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.NormalPointer(type, stride, count, pointer); }
        internal override void tkglPixelTransformParameter(OpenTK.Graphics.OpenGL.ExtPixelTransform target, OpenTK.Graphics.OpenGL.ExtPixelTransform pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ext.PixelTransformParameter(target, pname, param); }
        internal override unsafe void tkgl2PixelTransformParameter(OpenTK.Graphics.OpenGL.ExtPixelTransform target, OpenTK.Graphics.OpenGL.ExtPixelTransform pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.PixelTransformParameter(target, pname, @params); }
        internal override void tkgl3PixelTransformParameter(OpenTK.Graphics.OpenGL.ExtPixelTransform target, OpenTK.Graphics.OpenGL.ExtPixelTransform pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Ext.PixelTransformParameter(target, pname, param); }
        internal override unsafe void tkgl4PixelTransformParameter(OpenTK.Graphics.OpenGL.ExtPixelTransform target, OpenTK.Graphics.OpenGL.ExtPixelTransform pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.PixelTransformParameter(target, pname, @params); }
        internal override void tkgl10PointParameter(OpenTK.Graphics.OpenGL.ExtPointParameters pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ext.PointParameter(pname, param); }
        internal override void tkgl11PointParameter(OpenTK.Graphics.OpenGL.ExtPointParameters pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.PointParameter(pname, @params); }
        internal override unsafe void tkgl12PointParameter(OpenTK.Graphics.OpenGL.ExtPointParameters pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.PointParameter(pname, @params); }
        internal override void tkgl2PolygonOffset(Single factor, Single bias) { OpenTK.Graphics.OpenGL.GL.Ext.PolygonOffset(factor, bias); }
        internal override void tkgl7PrioritizeTextures(Int32 n, Int32[] textures, Single[] priorities) { OpenTK.Graphics.OpenGL.GL.Ext.PrioritizeTextures(n, textures, priorities); }
        internal override void tkgl8PrioritizeTextures(Int32 n, ref Int32 textures, ref Single priorities) { OpenTK.Graphics.OpenGL.GL.Ext.PrioritizeTextures(n, ref textures, ref priorities); }
        internal override unsafe void tkgl9PrioritizeTextures(Int32 n, Int32* textures, Single* priorities) { OpenTK.Graphics.OpenGL.GL.Ext.PrioritizeTextures(n, textures, priorities); }
        internal override void tkgl10PrioritizeTextures(Int32 n, UInt32[] textures, Single[] priorities) { OpenTK.Graphics.OpenGL.GL.Ext.PrioritizeTextures(n, textures, priorities); }
        internal override void tkgl11PrioritizeTextures(Int32 n, ref UInt32 textures, ref Single priorities) { OpenTK.Graphics.OpenGL.GL.Ext.PrioritizeTextures(n, ref textures, ref priorities); }
        internal override unsafe void tkgl12PrioritizeTextures(Int32 n, UInt32* textures, Single* priorities) { OpenTK.Graphics.OpenGL.GL.Ext.PrioritizeTextures(n, textures, priorities); }
        internal override void tkglProgramEnvParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, Int32 index, Int32 count, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramEnvParameters4(target, index, count, @params); }
        internal override void tkgl2ProgramEnvParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, Int32 index, Int32 count, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramEnvParameters4(target, index, count, ref @params); }
        internal override unsafe void tkgl3ProgramEnvParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, Int32 index, Int32 count, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramEnvParameters4(target, index, count, @params); }
        internal override void tkgl4ProgramEnvParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, UInt32 index, Int32 count, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramEnvParameters4(target, index, count, @params); }
        internal override void tkgl5ProgramEnvParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, UInt32 index, Int32 count, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramEnvParameters4(target, index, count, ref @params); }
        internal override unsafe void tkgl6ProgramEnvParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, UInt32 index, Int32 count, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramEnvParameters4(target, index, count, @params); }
        internal override void tkglProgramLocalParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, Int32 index, Int32 count, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramLocalParameters4(target, index, count, @params); }
        internal override void tkgl2ProgramLocalParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, Int32 index, Int32 count, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramLocalParameters4(target, index, count, ref @params); }
        internal override unsafe void tkgl3ProgramLocalParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, Int32 index, Int32 count, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramLocalParameters4(target, index, count, @params); }
        internal override void tkgl4ProgramLocalParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, UInt32 index, Int32 count, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramLocalParameters4(target, index, count, @params); }
        internal override void tkgl5ProgramLocalParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, UInt32 index, Int32 count, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramLocalParameters4(target, index, count, ref @params); }
        internal override unsafe void tkgl6ProgramLocalParameters4(OpenTK.Graphics.OpenGL.ExtGpuProgramParameters target, UInt32 index, Int32 count, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramLocalParameters4(target, index, count, @params); }
        internal override void tkgl5ProgramParameter(Int32 program, OpenTK.Graphics.OpenGL.ExtGeometryShader4 pname, Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramParameter(program, pname, value); }
        internal override void tkgl6ProgramParameter(UInt32 program, OpenTK.Graphics.OpenGL.ExtGeometryShader4 pname, Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramParameter(program, pname, value); }
        internal override void tkglProgramUniform1(Int32 program, Int32 location, Single v0) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, v0); }
        internal override void tkgl2ProgramUniform1(UInt32 program, Int32 location, Single v0) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, v0); }
        internal override void tkgl3ProgramUniform1(Int32 program, Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl4ProgramUniform1(Int32 program, Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, ref value); }
        internal override unsafe void tkgl5ProgramUniform1(Int32 program, Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl6ProgramUniform1(UInt32 program, Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl7ProgramUniform1(UInt32 program, Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, ref value); }
        internal override unsafe void tkgl8ProgramUniform1(UInt32 program, Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl9ProgramUniform1(Int32 program, Int32 location, Int32 v0) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, v0); }
        internal override void tkgl10ProgramUniform1(UInt32 program, Int32 location, Int32 v0) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, v0); }
        internal override void tkgl11ProgramUniform1(Int32 program, Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl12ProgramUniform1(Int32 program, Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, ref value); }
        internal override unsafe void tkgl13ProgramUniform1(Int32 program, Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl14ProgramUniform1(UInt32 program, Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl15ProgramUniform1(UInt32 program, Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, ref value); }
        internal override unsafe void tkgl16ProgramUniform1(UInt32 program, Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl17ProgramUniform1(UInt32 program, Int32 location, UInt32 v0) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, v0); }
        internal override void tkgl18ProgramUniform1(UInt32 program, Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkgl19ProgramUniform1(UInt32 program, Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, ref value); }
        internal override unsafe void tkgl20ProgramUniform1(UInt32 program, Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform1(program, location, count, value); }
        internal override void tkglProgramUniform2(Int32 program, Int32 location, Single v0, Single v1) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, v0, v1); }
        internal override void tkgl2ProgramUniform2(UInt32 program, Int32 location, Single v0, Single v1) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, v0, v1); }
        internal override void tkgl3ProgramUniform2(Int32 program, Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override void tkgl4ProgramUniform2(Int32 program, Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, ref value); }
        internal override unsafe void tkgl5ProgramUniform2(Int32 program, Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override void tkgl6ProgramUniform2(UInt32 program, Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override void tkgl7ProgramUniform2(UInt32 program, Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, ref value); }
        internal override unsafe void tkgl8ProgramUniform2(UInt32 program, Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override void tkgl9ProgramUniform2(Int32 program, Int32 location, Int32 v0, Int32 v1) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, v0, v1); }
        internal override void tkgl10ProgramUniform2(UInt32 program, Int32 location, Int32 v0, Int32 v1) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, v0, v1); }
        internal override void tkgl11ProgramUniform2(Int32 program, Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override unsafe void tkgl12ProgramUniform2(Int32 program, Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override void tkgl13ProgramUniform2(UInt32 program, Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override unsafe void tkgl14ProgramUniform2(UInt32 program, Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override void tkgl15ProgramUniform2(UInt32 program, Int32 location, UInt32 v0, UInt32 v1) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, v0, v1); }
        internal override void tkgl16ProgramUniform2(UInt32 program, Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override void tkgl17ProgramUniform2(UInt32 program, Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, ref value); }
        internal override unsafe void tkgl18ProgramUniform2(UInt32 program, Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform2(program, location, count, value); }
        internal override void tkglProgramUniform3(Int32 program, Int32 location, Single v0, Single v1, Single v2) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, v0, v1, v2); }
        internal override void tkgl2ProgramUniform3(UInt32 program, Int32 location, Single v0, Single v1, Single v2) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, v0, v1, v2); }
        internal override void tkgl3ProgramUniform3(Int32 program, Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl4ProgramUniform3(Int32 program, Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, ref value); }
        internal override unsafe void tkgl5ProgramUniform3(Int32 program, Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl6ProgramUniform3(UInt32 program, Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl7ProgramUniform3(UInt32 program, Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, ref value); }
        internal override unsafe void tkgl8ProgramUniform3(UInt32 program, Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl9ProgramUniform3(Int32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, v0, v1, v2); }
        internal override void tkgl10ProgramUniform3(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, v0, v1, v2); }
        internal override void tkgl11ProgramUniform3(Int32 program, Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl12ProgramUniform3(Int32 program, Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, ref value); }
        internal override unsafe void tkgl13ProgramUniform3(Int32 program, Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl14ProgramUniform3(UInt32 program, Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl15ProgramUniform3(UInt32 program, Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, ref value); }
        internal override unsafe void tkgl16ProgramUniform3(UInt32 program, Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl17ProgramUniform3(UInt32 program, Int32 location, UInt32 v0, UInt32 v1, UInt32 v2) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, v0, v1, v2); }
        internal override void tkgl18ProgramUniform3(UInt32 program, Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkgl19ProgramUniform3(UInt32 program, Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, ref value); }
        internal override unsafe void tkgl20ProgramUniform3(UInt32 program, Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform3(program, location, count, value); }
        internal override void tkglProgramUniform4(Int32 program, Int32 location, Single v0, Single v1, Single v2, Single v3) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, v0, v1, v2, v3); }
        internal override void tkgl2ProgramUniform4(UInt32 program, Int32 location, Single v0, Single v1, Single v2, Single v3) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, v0, v1, v2, v3); }
        internal override void tkgl3ProgramUniform4(Int32 program, Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl4ProgramUniform4(Int32 program, Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, ref value); }
        internal override unsafe void tkgl5ProgramUniform4(Int32 program, Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl6ProgramUniform4(UInt32 program, Int32 location, Int32 count, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl7ProgramUniform4(UInt32 program, Int32 location, Int32 count, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, ref value); }
        internal override unsafe void tkgl8ProgramUniform4(UInt32 program, Int32 location, Int32 count, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl9ProgramUniform4(Int32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, v0, v1, v2, v3); }
        internal override void tkgl10ProgramUniform4(UInt32 program, Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, v0, v1, v2, v3); }
        internal override void tkgl11ProgramUniform4(Int32 program, Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl12ProgramUniform4(Int32 program, Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, ref value); }
        internal override unsafe void tkgl13ProgramUniform4(Int32 program, Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl14ProgramUniform4(UInt32 program, Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl15ProgramUniform4(UInt32 program, Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, ref value); }
        internal override unsafe void tkgl16ProgramUniform4(UInt32 program, Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl17ProgramUniform4(UInt32 program, Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, v0, v1, v2, v3); }
        internal override void tkgl18ProgramUniform4(UInt32 program, Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkgl19ProgramUniform4(UInt32 program, Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, ref value); }
        internal override unsafe void tkgl20ProgramUniform4(UInt32 program, Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniform4(program, location, count, value); }
        internal override void tkglProgramUniformMatrix2(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix2(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix2(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix2(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix2(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix2(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2(program, location, count, transpose, value); }
        internal override void tkglProgramUniformMatrix2x3(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x3(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix2x3(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x3(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix2x3(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x3(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix2x3(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x3(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix2x3(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x3(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix2x3(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x3(program, location, count, transpose, value); }
        internal override void tkglProgramUniformMatrix2x4(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x4(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix2x4(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x4(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix2x4(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x4(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix2x4(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x4(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix2x4(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x4(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix2x4(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix2x4(program, location, count, transpose, value); }
        internal override void tkglProgramUniformMatrix3(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix3(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix3(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix3(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix3(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix3(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3(program, location, count, transpose, value); }
        internal override void tkglProgramUniformMatrix3x2(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x2(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix3x2(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x2(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix3x2(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x2(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix3x2(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x2(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix3x2(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x2(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix3x2(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x2(program, location, count, transpose, value); }
        internal override void tkglProgramUniformMatrix3x4(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x4(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix3x4(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x4(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix3x4(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x4(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix3x4(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x4(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix3x4(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x4(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix3x4(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix3x4(program, location, count, transpose, value); }
        internal override void tkglProgramUniformMatrix4(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix4(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix4(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix4(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix4(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix4(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4(program, location, count, transpose, value); }
        internal override void tkglProgramUniformMatrix4x2(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x2(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix4x2(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x2(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix4x2(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x2(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix4x2(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x2(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix4x2(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x2(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix4x2(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x2(program, location, count, transpose, value); }
        internal override void tkglProgramUniformMatrix4x3(Int32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x3(program, location, count, transpose, value); }
        internal override void tkgl2ProgramUniformMatrix4x3(Int32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x3(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl3ProgramUniformMatrix4x3(Int32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x3(program, location, count, transpose, value); }
        internal override void tkgl4ProgramUniformMatrix4x3(UInt32 program, Int32 location, Int32 count, bool transpose, Single[] value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x3(program, location, count, transpose, value); }
        internal override void tkgl5ProgramUniformMatrix4x3(UInt32 program, Int32 location, Int32 count, bool transpose, ref Single value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x3(program, location, count, transpose, ref value); }
        internal override unsafe void tkgl6ProgramUniformMatrix4x3(UInt32 program, Int32 location, Int32 count, bool transpose, Single* value) { OpenTK.Graphics.OpenGL.GL.Ext.ProgramUniformMatrix4x3(program, location, count, transpose, value); }
        internal override void tkgl2ProvokingVertex(OpenTK.Graphics.OpenGL.ExtProvokingVertex mode) { OpenTK.Graphics.OpenGL.GL.Ext.ProvokingVertex(mode); }
        internal override void tkglPushClientAttribDefault(OpenTK.Graphics.OpenGL.ClientAttribMask mask) { OpenTK.Graphics.OpenGL.GL.Ext.PushClientAttribDefault(mask); }
        internal override void tkgl2RenderbufferStorage(OpenTK.Graphics.OpenGL.RenderbufferTarget target, OpenTK.Graphics.OpenGL.RenderbufferStorage internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.RenderbufferStorage(target, internalformat, width, height); }
        internal override void tkgl2RenderbufferStorageMultisample(OpenTK.Graphics.OpenGL.ExtFramebufferMultisample target, Int32 samples, OpenTK.Graphics.OpenGL.ExtFramebufferMultisample internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.Ext.RenderbufferStorageMultisample(target, samples, internalformat, width, height); }
        internal override void tkgl2ResetHistogram(OpenTK.Graphics.OpenGL.ExtHistogram target) { OpenTK.Graphics.OpenGL.GL.Ext.ResetHistogram(target); }
        internal override void tkgl2ResetMinmax(OpenTK.Graphics.OpenGL.ExtHistogram target) { OpenTK.Graphics.OpenGL.GL.Ext.ResetMinmax(target); }
        internal override void tkgl3SampleMask(Single value, bool invert) { OpenTK.Graphics.OpenGL.GL.Ext.SampleMask(value, invert); }
        internal override void tkglSamplePattern(OpenTK.Graphics.OpenGL.ExtMultisample pattern) { OpenTK.Graphics.OpenGL.GL.Ext.SamplePattern(pattern); }
        internal override void tkgl33SecondaryColor3(SByte red, SByte green, SByte blue) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(red, green, blue); }
        internal override void tkgl34SecondaryColor3(SByte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl35SecondaryColor3(ref SByte v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(ref v); }
        internal override unsafe void tkgl36SecondaryColor3(SByte* v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl37SecondaryColor3(Double red, Double green, Double blue) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(red, green, blue); }
        internal override void tkgl38SecondaryColor3(Double[] v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl39SecondaryColor3(ref Double v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(ref v); }
        internal override unsafe void tkgl40SecondaryColor3(Double* v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl41SecondaryColor3(Single red, Single green, Single blue) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(red, green, blue); }
        internal override void tkgl42SecondaryColor3(Single[] v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl43SecondaryColor3(ref Single v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(ref v); }
        internal override unsafe void tkgl44SecondaryColor3(Single* v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl45SecondaryColor3(Int32 red, Int32 green, Int32 blue) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(red, green, blue); }
        internal override void tkgl46SecondaryColor3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl47SecondaryColor3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(ref v); }
        internal override unsafe void tkgl48SecondaryColor3(Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl49SecondaryColor3(Int16 red, Int16 green, Int16 blue) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(red, green, blue); }
        internal override void tkgl50SecondaryColor3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl51SecondaryColor3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(ref v); }
        internal override unsafe void tkgl52SecondaryColor3(Int16* v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl53SecondaryColor3(Byte red, Byte green, Byte blue) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(red, green, blue); }
        internal override void tkgl54SecondaryColor3(Byte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl55SecondaryColor3(ref Byte v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(ref v); }
        internal override unsafe void tkgl56SecondaryColor3(Byte* v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl57SecondaryColor3(UInt32 red, UInt32 green, UInt32 blue) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(red, green, blue); }
        internal override void tkgl58SecondaryColor3(UInt32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl59SecondaryColor3(ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(ref v); }
        internal override unsafe void tkgl60SecondaryColor3(UInt32* v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl61SecondaryColor3(UInt16 red, UInt16 green, UInt16 blue) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(red, green, blue); }
        internal override void tkgl62SecondaryColor3(UInt16[] v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl63SecondaryColor3(ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(ref v); }
        internal override unsafe void tkgl64SecondaryColor3(UInt16* v) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColor3(v); }
        internal override void tkgl2SecondaryColorPointer(Int32 size, OpenTK.Graphics.OpenGL.ColorPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.SecondaryColorPointer(size, type, stride, pointer); }
        internal override void tkgl2SeparableFilter2D(OpenTK.Graphics.OpenGL.ExtConvolution target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr row, IntPtr column) { OpenTK.Graphics.OpenGL.GL.Ext.SeparableFilter2D(target, internalformat, width, height, format, type, row, column); }
        internal override void tkglSetInvariant(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader type, IntPtr addr) { OpenTK.Graphics.OpenGL.GL.Ext.SetInvariant(id, type, addr); }
        internal override void tkgl2SetInvariant(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader type, IntPtr addr) { OpenTK.Graphics.OpenGL.GL.Ext.SetInvariant(id, type, addr); }
        internal override void tkglSetLocalConstant(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader type, IntPtr addr) { OpenTK.Graphics.OpenGL.GL.Ext.SetLocalConstant(id, type, addr); }
        internal override void tkgl2SetLocalConstant(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader type, IntPtr addr) { OpenTK.Graphics.OpenGL.GL.Ext.SetLocalConstant(id, type, addr); }
        internal override void tkglShaderOp1(OpenTK.Graphics.OpenGL.ExtVertexShader op, Int32 res, Int32 arg1) { OpenTK.Graphics.OpenGL.GL.Ext.ShaderOp1(op, res, arg1); }
        internal override void tkgl2ShaderOp1(OpenTK.Graphics.OpenGL.ExtVertexShader op, UInt32 res, UInt32 arg1) { OpenTK.Graphics.OpenGL.GL.Ext.ShaderOp1(op, res, arg1); }
        internal override void tkglShaderOp2(OpenTK.Graphics.OpenGL.ExtVertexShader op, Int32 res, Int32 arg1, Int32 arg2) { OpenTK.Graphics.OpenGL.GL.Ext.ShaderOp2(op, res, arg1, arg2); }
        internal override void tkgl2ShaderOp2(OpenTK.Graphics.OpenGL.ExtVertexShader op, UInt32 res, UInt32 arg1, UInt32 arg2) { OpenTK.Graphics.OpenGL.GL.Ext.ShaderOp2(op, res, arg1, arg2); }
        internal override void tkglShaderOp3(OpenTK.Graphics.OpenGL.ExtVertexShader op, Int32 res, Int32 arg1, Int32 arg2, Int32 arg3) { OpenTK.Graphics.OpenGL.GL.Ext.ShaderOp3(op, res, arg1, arg2, arg3); }
        internal override void tkgl2ShaderOp3(OpenTK.Graphics.OpenGL.ExtVertexShader op, UInt32 res, UInt32 arg1, UInt32 arg2, UInt32 arg3) { OpenTK.Graphics.OpenGL.GL.Ext.ShaderOp3(op, res, arg1, arg2, arg3); }
        internal override void tkglStencilClearTag(Int32 stencilTagBits, Int32 stencilClearTag) { OpenTK.Graphics.OpenGL.GL.Ext.StencilClearTag(stencilTagBits, stencilClearTag); }
        internal override void tkgl2StencilClearTag(Int32 stencilTagBits, UInt32 stencilClearTag) { OpenTK.Graphics.OpenGL.GL.Ext.StencilClearTag(stencilTagBits, stencilClearTag); }
        internal override void tkglSwizzle(Int32 res, Int32 @in, OpenTK.Graphics.OpenGL.ExtVertexShader outX, OpenTK.Graphics.OpenGL.ExtVertexShader outY, OpenTK.Graphics.OpenGL.ExtVertexShader outZ, OpenTK.Graphics.OpenGL.ExtVertexShader outW) { OpenTK.Graphics.OpenGL.GL.Ext.Swizzle(res, @in, outX, outY, outZ, outW); }
        internal override void tkgl2Swizzle(UInt32 res, UInt32 @in, OpenTK.Graphics.OpenGL.ExtVertexShader outX, OpenTK.Graphics.OpenGL.ExtVertexShader outY, OpenTK.Graphics.OpenGL.ExtVertexShader outZ, OpenTK.Graphics.OpenGL.ExtVertexShader outW) { OpenTK.Graphics.OpenGL.GL.Ext.Swizzle(res, @in, outX, outY, outZ, outW); }
        internal override void tkglTangent3(Byte tx, Byte ty, Byte tz) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(tx, ty, tz); }
        internal override void tkgl2Tangent3(SByte tx, SByte ty, SByte tz) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(tx, ty, tz); }
        internal override void tkgl3Tangent3(Byte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl4Tangent3(ref Byte v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(ref v); }
        internal override unsafe void tkgl5Tangent3(Byte* v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl6Tangent3(SByte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl7Tangent3(ref SByte v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(ref v); }
        internal override unsafe void tkgl8Tangent3(SByte* v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl9Tangent3(Double tx, Double ty, Double tz) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(tx, ty, tz); }
        internal override void tkgl10Tangent3(Double[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl11Tangent3(ref Double v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(ref v); }
        internal override unsafe void tkgl12Tangent3(Double* v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl13Tangent3(Single tx, Single ty, Single tz) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(tx, ty, tz); }
        internal override void tkgl14Tangent3(Single[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl15Tangent3(ref Single v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(ref v); }
        internal override unsafe void tkgl16Tangent3(Single* v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl17Tangent3(Int32 tx, Int32 ty, Int32 tz) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(tx, ty, tz); }
        internal override void tkgl18Tangent3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl19Tangent3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(ref v); }
        internal override unsafe void tkgl20Tangent3(Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl21Tangent3(Int16 tx, Int16 ty, Int16 tz) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(tx, ty, tz); }
        internal override void tkgl22Tangent3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkgl23Tangent3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(ref v); }
        internal override unsafe void tkgl24Tangent3(Int16* v) { OpenTK.Graphics.OpenGL.GL.Ext.Tangent3(v); }
        internal override void tkglTangentPointer(OpenTK.Graphics.OpenGL.NormalPointerType type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.TangentPointer(type, stride, pointer); }
        internal override void tkgl5TexBuffer(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.ExtTextureBufferObject internalformat, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.TexBuffer(target, internalformat, buffer); }
        internal override void tkgl6TexBuffer(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.ExtTextureBufferObject internalformat, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.TexBuffer(target, internalformat, buffer); }
        internal override void tkgl2TexCoordPointer(Int32 size, OpenTK.Graphics.OpenGL.TexCoordPointerType type, Int32 stride, Int32 count, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.TexCoordPointer(size, type, stride, count, pointer); }
        internal override void tkgl2TexImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TexImage3D(target, level, internalformat, width, height, depth, border, format, type, pixels); }
        internal override void tkgl7TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TexParameterI(target, pname, @params); }
        internal override void tkgl8TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.TexParameterI(target, pname, ref @params); }
        internal override unsafe void tkgl9TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TexParameterI(target, pname, @params); }
        internal override void tkgl10TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TexParameterI(target, pname, @params); }
        internal override void tkgl11TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.TexParameterI(target, pname, ref @params); }
        internal override unsafe void tkgl12TexParameterI(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TexParameterI(target, pname, @params); }
        internal override void tkgl2TexSubImage1D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TexSubImage1D(target, level, xoffset, width, format, type, pixels); }
        internal override void tkgl2TexSubImage2D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TexSubImage2D(target, level, xoffset, yoffset, width, height, format, type, pixels); }
        internal override void tkgl2TexSubImage3D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TexSubImage3D(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels); }
        internal override void tkglTextureBuffer(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.TextureBuffer(texture, target, internalformat, buffer); }
        internal override void tkgl2TextureBuffer(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.TextureBuffer(texture, target, internalformat, buffer); }
        internal override void tkglTextureImage1D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureImage1D(texture, target, level, internalformat, width, border, format, type, pixels); }
        internal override void tkgl2TextureImage1D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureImage1D(texture, target, level, internalformat, width, border, format, type, pixels); }
        internal override void tkglTextureImage2D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureImage2D(texture, target, level, internalformat, width, height, border, format, type, pixels); }
        internal override void tkgl2TextureImage2D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureImage2D(texture, target, level, internalformat, width, height, border, format, type, pixels); }
        internal override void tkglTextureImage3D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureImage3D(texture, target, level, internalformat, width, height, depth, border, format, type, pixels); }
        internal override void tkgl2TextureImage3D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.ExtDirectStateAccess internalformat, Int32 width, Int32 height, Int32 depth, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureImage3D(texture, target, level, internalformat, width, height, depth, border, format, type, pixels); }
        internal override void tkglTextureLight(OpenTK.Graphics.OpenGL.ExtLightTexture pname) { OpenTK.Graphics.OpenGL.GL.Ext.TextureLight(pname); }
        internal override void tkglTextureMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter mode) { OpenTK.Graphics.OpenGL.GL.Ext.TextureMaterial(face, mode); }
        internal override void tkglTextureNormal(OpenTK.Graphics.OpenGL.ExtTexturePerturbNormal mode) { OpenTK.Graphics.OpenGL.GL.Ext.TextureNormal(mode); }
        internal override void tkglTextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, param); }
        internal override void tkgl2TextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single param) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, param); }
        internal override void tkgl3TextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, @params); }
        internal override unsafe void tkgl4TextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, @params); }
        internal override void tkgl5TextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, @params); }
        internal override unsafe void tkgl6TextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, @params); }
        internal override void tkgl7TextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, param); }
        internal override void tkgl8TextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, param); }
        internal override void tkglTextureParameterI(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, @params); }
        internal override void tkgl2TextureParameterI(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, ref @params); }
        internal override unsafe void tkgl3TextureParameterI(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, @params); }
        internal override void tkgl4TextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, @params); }
        internal override void tkgl5TextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, ref @params); }
        internal override unsafe void tkgl6TextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, @params); }
        internal override void tkgl7TextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, @params); }
        internal override void tkgl8TextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, ref @params); }
        internal override unsafe void tkgl9TextureParameterI(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameterI(texture, target, pname, @params); }
        internal override void tkgl9TextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, @params); }
        internal override unsafe void tkgl10TextureParameter(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, @params); }
        internal override void tkgl11TextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, @params); }
        internal override unsafe void tkgl12TextureParameter(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.TextureParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Ext.TextureParameter(texture, target, pname, @params); }
        internal override void tkglTextureRenderbuffer(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.TextureRenderbuffer(texture, target, renderbuffer); }
        internal override void tkgl2TextureRenderbuffer(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, UInt32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.Ext.TextureRenderbuffer(texture, target, renderbuffer); }
        internal override void tkglTextureSubImage1D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureSubImage1D(texture, target, level, xoffset, width, format, type, pixels); }
        internal override void tkgl2TextureSubImage1D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureSubImage1D(texture, target, level, xoffset, width, format, type, pixels); }
        internal override void tkglTextureSubImage2D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureSubImage2D(texture, target, level, xoffset, yoffset, width, height, format, type, pixels); }
        internal override void tkgl2TextureSubImage2D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 width, Int32 height, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureSubImage2D(texture, target, level, xoffset, yoffset, width, height, format, type, pixels); }
        internal override void tkglTextureSubImage3D(Int32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureSubImage3D(texture, target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels); }
        internal override void tkgl2TextureSubImage3D(UInt32 texture, OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 width, Int32 height, Int32 depth, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Ext.TextureSubImage3D(texture, target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels); }
        internal override void tkgl3TransformFeedbackVaryings(Int32 program, Int32 count, String[] varyings, OpenTK.Graphics.OpenGL.ExtTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.Ext.TransformFeedbackVaryings(program, count, varyings, bufferMode); }
        internal override void tkgl4TransformFeedbackVaryings(UInt32 program, Int32 count, String[] varyings, OpenTK.Graphics.OpenGL.ExtTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.Ext.TransformFeedbackVaryings(program, count, varyings, bufferMode); }
        internal override void tkgl21Uniform1(Int32 location, Int32 v0) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform1(location, v0); }
        internal override void tkgl22Uniform1(Int32 location, UInt32 v0) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform1(location, v0); }
        internal override void tkgl23Uniform1(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform1(location, count, value); }
        internal override void tkgl24Uniform1(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform1(location, count, ref value); }
        internal override unsafe void tkgl25Uniform1(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform1(location, count, value); }
        internal override void tkgl26Uniform1(Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform1(location, count, value); }
        internal override void tkgl27Uniform1(Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform1(location, count, ref value); }
        internal override unsafe void tkgl28Uniform1(Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform1(location, count, value); }
        internal override void tkgl19Uniform2(Int32 location, Int32 v0, Int32 v1) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform2(location, v0, v1); }
        internal override void tkgl20Uniform2(Int32 location, UInt32 v0, UInt32 v1) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform2(location, v0, v1); }
        internal override void tkgl21Uniform2(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform2(location, count, value); }
        internal override unsafe void tkgl22Uniform2(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform2(location, count, value); }
        internal override void tkgl23Uniform2(Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform2(location, count, value); }
        internal override void tkgl24Uniform2(Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform2(location, count, ref value); }
        internal override unsafe void tkgl25Uniform2(Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform2(location, count, value); }
        internal override void tkgl21Uniform3(Int32 location, Int32 v0, Int32 v1, Int32 v2) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform3(location, v0, v1, v2); }
        internal override void tkgl22Uniform3(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform3(location, v0, v1, v2); }
        internal override void tkgl23Uniform3(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform3(location, count, value); }
        internal override void tkgl24Uniform3(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform3(location, count, ref value); }
        internal override unsafe void tkgl25Uniform3(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform3(location, count, value); }
        internal override void tkgl26Uniform3(Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform3(location, count, value); }
        internal override void tkgl27Uniform3(Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform3(location, count, ref value); }
        internal override unsafe void tkgl28Uniform3(Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform3(location, count, value); }
        internal override void tkgl21Uniform4(Int32 location, Int32 v0, Int32 v1, Int32 v2, Int32 v3) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform4(location, v0, v1, v2, v3); }
        internal override void tkgl22Uniform4(Int32 location, UInt32 v0, UInt32 v1, UInt32 v2, UInt32 v3) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform4(location, v0, v1, v2, v3); }
        internal override void tkgl23Uniform4(Int32 location, Int32 count, Int32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform4(location, count, value); }
        internal override void tkgl24Uniform4(Int32 location, Int32 count, ref Int32 value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform4(location, count, ref value); }
        internal override unsafe void tkgl25Uniform4(Int32 location, Int32 count, Int32* value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform4(location, count, value); }
        internal override void tkgl26Uniform4(Int32 location, Int32 count, UInt32[] value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform4(location, count, value); }
        internal override void tkgl27Uniform4(Int32 location, Int32 count, ref UInt32 value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform4(location, count, ref value); }
        internal override unsafe void tkgl28Uniform4(Int32 location, Int32 count, UInt32* value) { OpenTK.Graphics.OpenGL.GL.Ext.Uniform4(location, count, value); }
        internal override void tkglUniformBuffer(Int32 program, Int32 location, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.UniformBuffer(program, location, buffer); }
        internal override void tkgl2UniformBuffer(UInt32 program, Int32 location, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.Ext.UniformBuffer(program, location, buffer); }
        internal override void tkglUnlockArrays() { OpenTK.Graphics.OpenGL.GL.Ext.UnlockArrays(); }
        internal override bool tkglUnmapNamedBuffer(Int32 buffer) { return OpenTK.Graphics.OpenGL.GL.Ext.UnmapNamedBuffer(buffer); }
        internal override bool tkgl2UnmapNamedBuffer(UInt32 buffer) { return OpenTK.Graphics.OpenGL.GL.Ext.UnmapNamedBuffer(buffer); }
        internal override void tkglVariant(UInt32 id, SByte[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl2Variant(UInt32 id, ref SByte addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl3Variant(UInt32 id, SByte* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl4Variant(Int32 id, Double[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl5Variant(Int32 id, ref Double addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl6Variant(Int32 id, Double* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl7Variant(UInt32 id, Double[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl8Variant(UInt32 id, ref Double addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl9Variant(UInt32 id, Double* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl10Variant(Int32 id, Single[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl11Variant(Int32 id, ref Single addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl12Variant(Int32 id, Single* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl13Variant(UInt32 id, Single[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl14Variant(UInt32 id, ref Single addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl15Variant(UInt32 id, Single* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl16Variant(Int32 id, Int32[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl17Variant(Int32 id, ref Int32 addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl18Variant(Int32 id, Int32* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl19Variant(UInt32 id, Int32[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl20Variant(UInt32 id, ref Int32 addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl21Variant(UInt32 id, Int32* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkglVariantPointer(Int32 id, OpenTK.Graphics.OpenGL.ExtVertexShader type, Int32 stride, IntPtr addr) { OpenTK.Graphics.OpenGL.GL.Ext.VariantPointer(id, type, stride, addr); }
        internal override void tkgl2VariantPointer(UInt32 id, OpenTK.Graphics.OpenGL.ExtVertexShader type, UInt32 stride, IntPtr addr) { OpenTK.Graphics.OpenGL.GL.Ext.VariantPointer(id, type, stride, addr); }
        internal override void tkgl22Variant(Int32 id, Int16[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl23Variant(Int32 id, ref Int16 addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl24Variant(Int32 id, Int16* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl25Variant(UInt32 id, Int16[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl26Variant(UInt32 id, ref Int16 addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl27Variant(UInt32 id, Int16* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl28Variant(Int32 id, Byte[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl29Variant(Int32 id, ref Byte addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl30Variant(Int32 id, Byte* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl31Variant(UInt32 id, Byte[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl32Variant(UInt32 id, ref Byte addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl33Variant(UInt32 id, Byte* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl34Variant(UInt32 id, UInt32[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl35Variant(UInt32 id, ref UInt32 addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl36Variant(UInt32 id, UInt32* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl37Variant(UInt32 id, UInt16[] addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl38Variant(UInt32 id, ref UInt16 addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, ref addr); }
        internal override unsafe void tkgl39Variant(UInt32 id, UInt16* addr) { OpenTK.Graphics.OpenGL.GL.Ext.Variant(id, addr); }
        internal override void tkgl7VertexAttribI1(Int32 index, Int32 x) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI1(index, x); }
        internal override void tkgl8VertexAttribI1(UInt32 index, Int32 x) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI1(index, x); }
        internal override unsafe void tkgl9VertexAttribI1(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI1(index, v); }
        internal override unsafe void tkgl10VertexAttribI1(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI1(index, v); }
        internal override void tkgl11VertexAttribI1(UInt32 index, UInt32 x) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI1(index, x); }
        internal override unsafe void tkgl12VertexAttribI1(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI1(index, v); }
        internal override void tkgl13VertexAttribI2(Int32 index, Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, x, y); }
        internal override void tkgl14VertexAttribI2(UInt32 index, Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, x, y); }
        internal override void tkgl15VertexAttribI2(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, v); }
        internal override void tkgl16VertexAttribI2(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, ref v); }
        internal override unsafe void tkgl17VertexAttribI2(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, v); }
        internal override void tkgl18VertexAttribI2(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, v); }
        internal override void tkgl19VertexAttribI2(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, ref v); }
        internal override unsafe void tkgl20VertexAttribI2(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, v); }
        internal override void tkgl21VertexAttribI2(UInt32 index, UInt32 x, UInt32 y) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, x, y); }
        internal override void tkgl22VertexAttribI2(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, v); }
        internal override void tkgl23VertexAttribI2(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, ref v); }
        internal override unsafe void tkgl24VertexAttribI2(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI2(index, v); }
        internal override void tkgl13VertexAttribI3(Int32 index, Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, x, y, z); }
        internal override void tkgl14VertexAttribI3(UInt32 index, Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, x, y, z); }
        internal override void tkgl15VertexAttribI3(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, v); }
        internal override void tkgl16VertexAttribI3(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, ref v); }
        internal override unsafe void tkgl17VertexAttribI3(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, v); }
        internal override void tkgl18VertexAttribI3(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, v); }
        internal override void tkgl19VertexAttribI3(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, ref v); }
        internal override unsafe void tkgl20VertexAttribI3(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, v); }
        internal override void tkgl21VertexAttribI3(UInt32 index, UInt32 x, UInt32 y, UInt32 z) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, x, y, z); }
        internal override void tkgl22VertexAttribI3(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, v); }
        internal override void tkgl23VertexAttribI3(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, ref v); }
        internal override unsafe void tkgl24VertexAttribI3(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI3(index, v); }
        internal override void tkgl31VertexAttribI4(UInt32 index, SByte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl32VertexAttribI4(UInt32 index, ref SByte v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl33VertexAttribI4(UInt32 index, SByte* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl34VertexAttribI4(Int32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, x, y, z, w); }
        internal override void tkgl35VertexAttribI4(UInt32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, x, y, z, w); }
        internal override void tkgl36VertexAttribI4(Int32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl37VertexAttribI4(Int32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl38VertexAttribI4(Int32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl39VertexAttribI4(UInt32 index, Int32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl40VertexAttribI4(UInt32 index, ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl41VertexAttribI4(UInt32 index, Int32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl42VertexAttribI4(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl43VertexAttribI4(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl44VertexAttribI4(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl45VertexAttribI4(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl46VertexAttribI4(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl47VertexAttribI4(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl48VertexAttribI4(Int32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl49VertexAttribI4(Int32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl50VertexAttribI4(Int32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl51VertexAttribI4(UInt32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl52VertexAttribI4(UInt32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl53VertexAttribI4(UInt32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl54VertexAttribI4(UInt32 index, UInt32 x, UInt32 y, UInt32 z, UInt32 w) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, x, y, z, w); }
        internal override void tkgl55VertexAttribI4(UInt32 index, UInt32[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl56VertexAttribI4(UInt32 index, ref UInt32 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl57VertexAttribI4(UInt32 index, UInt32* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl58VertexAttribI4(UInt32 index, UInt16[] v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl59VertexAttribI4(UInt32 index, ref UInt16 v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, ref v); }
        internal override unsafe void tkgl60VertexAttribI4(UInt32 index, UInt16* v) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribI4(index, v); }
        internal override void tkgl3VertexAttribIPointer(Int32 index, Int32 size, OpenTK.Graphics.OpenGL.NvVertexProgram4 type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribIPointer(index, size, type, stride, pointer); }
        internal override void tkgl4VertexAttribIPointer(UInt32 index, Int32 size, OpenTK.Graphics.OpenGL.NvVertexProgram4 type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.VertexAttribIPointer(index, size, type, stride, pointer); }
        internal override void tkgl2VertexPointer(Int32 size, OpenTK.Graphics.OpenGL.VertexPointerType type, Int32 stride, Int32 count, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.VertexPointer(size, type, stride, count, pointer); }
        internal override void tkglVertexWeight(Single weight) { OpenTK.Graphics.OpenGL.GL.Ext.VertexWeight(weight); }
        internal override unsafe void tkgl2VertexWeight(Single* weight) { OpenTK.Graphics.OpenGL.GL.Ext.VertexWeight(weight); }
        internal override void tkglVertexWeightPointer(Int32 size, OpenTK.Graphics.OpenGL.ExtVertexWeighting type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Ext.VertexWeightPointer(size, type, stride, pointer); }
        internal override void tkglWriteMask(Int32 res, Int32 @in, OpenTK.Graphics.OpenGL.ExtVertexShader outX, OpenTK.Graphics.OpenGL.ExtVertexShader outY, OpenTK.Graphics.OpenGL.ExtVertexShader outZ, OpenTK.Graphics.OpenGL.ExtVertexShader outW) { OpenTK.Graphics.OpenGL.GL.Ext.WriteMask(res, @in, outX, outY, outZ, outW); }
        internal override void tkgl2WriteMask(UInt32 res, UInt32 @in, OpenTK.Graphics.OpenGL.ExtVertexShader outX, OpenTK.Graphics.OpenGL.ExtVertexShader outY, OpenTK.Graphics.OpenGL.ExtVertexShader outZ, OpenTK.Graphics.OpenGL.ExtVertexShader outW) { OpenTK.Graphics.OpenGL.GL.Ext.WriteMask(res, @in, outX, outY, outZ, outW); }
        internal override void tkglFrameTerminator() { OpenTK.Graphics.OpenGL.GL.Gremedy.FrameTerminator(); }
        internal override void tkglStringMarker(Int32 len, IntPtr @string) { OpenTK.Graphics.OpenGL.GL.Gremedy.StringMarker(len, @string); }
        internal override void tkglGetImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.HP.GetImageTransformParameter(target, pname, @params); }
        internal override void tkgl2GetImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.HP.GetImageTransformParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.HP.GetImageTransformParameter(target, pname, @params); }
        internal override void tkgl4GetImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.HP.GetImageTransformParameter(target, pname, @params); }
        internal override void tkgl5GetImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.HP.GetImageTransformParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.HP.GetImageTransformParameter(target, pname, @params); }
        internal override void tkglImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Single param) { OpenTK.Graphics.OpenGL.GL.HP.ImageTransformParameter(target, pname, param); }
        internal override void tkgl2ImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.HP.ImageTransformParameter(target, pname, @params); }
        internal override unsafe void tkgl3ImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.HP.ImageTransformParameter(target, pname, @params); }
        internal override void tkgl4ImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.HP.ImageTransformParameter(target, pname, param); }
        internal override void tkgl5ImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.HP.ImageTransformParameter(target, pname, @params); }
        internal override unsafe void tkgl6ImageTransformParameter(OpenTK.Graphics.OpenGL.HpImageTransform target, OpenTK.Graphics.OpenGL.HpImageTransform pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.HP.ImageTransformParameter(target, pname, @params); }
        internal override void tkglColorPointerList(Int32 size, OpenTK.Graphics.OpenGL.ColorPointerType type, Int32 stride, IntPtr pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.ColorPointerList(size, type, stride, pointer, ptrstride); }
        internal override void tkglEdgeFlagPointerList(Int32 stride, bool[] pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.EdgeFlagPointerList(stride, pointer, ptrstride); }
        internal override void tkgl2EdgeFlagPointerList(Int32 stride, ref bool pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.EdgeFlagPointerList(stride, ref pointer, ptrstride); }
        internal override unsafe void tkgl3EdgeFlagPointerList(Int32 stride, bool* pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.EdgeFlagPointerList(stride, pointer, ptrstride); }
        internal override void tkglFogCoordPointerList(OpenTK.Graphics.OpenGL.IbmVertexArrayLists type, Int32 stride, IntPtr pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.FogCoordPointerList(type, stride, pointer, ptrstride); }
        internal override void tkglIndexPointerList(OpenTK.Graphics.OpenGL.IndexPointerType type, Int32 stride, IntPtr pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.IndexPointerList(type, stride, pointer, ptrstride); }
        internal override void tkglMultiModeDrawArrays(OpenTK.Graphics.OpenGL.BeginMode[] mode, Int32[] first, Int32[] count, Int32 primcount, Int32 modestride) { OpenTK.Graphics.OpenGL.GL.Ibm.MultiModeDrawArrays(mode, first, count, primcount, modestride); }
        internal override void tkgl2MultiModeDrawArrays(ref OpenTK.Graphics.OpenGL.BeginMode mode, ref Int32 first, ref Int32 count, Int32 primcount, Int32 modestride) { OpenTK.Graphics.OpenGL.GL.Ibm.MultiModeDrawArrays(ref mode, ref first, ref count, primcount, modestride); }
        internal override unsafe void tkgl3MultiModeDrawArrays(OpenTK.Graphics.OpenGL.BeginMode* mode, Int32* first, Int32* count, Int32 primcount, Int32 modestride) { OpenTK.Graphics.OpenGL.GL.Ibm.MultiModeDrawArrays(mode, first, count, primcount, modestride); }
        internal override void tkglMultiModeDrawElements(OpenTK.Graphics.OpenGL.BeginMode[] mode, Int32[] count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32 modestride) { OpenTK.Graphics.OpenGL.GL.Ibm.MultiModeDrawElements(mode, count, type, indices, primcount, modestride); }
        internal override void tkgl2MultiModeDrawElements(ref OpenTK.Graphics.OpenGL.BeginMode mode, ref Int32 count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32 modestride) { OpenTK.Graphics.OpenGL.GL.Ibm.MultiModeDrawElements(ref mode, ref count, type, indices, primcount, modestride); }
        internal override unsafe void tkgl3MultiModeDrawElements(OpenTK.Graphics.OpenGL.BeginMode* mode, Int32* count, OpenTK.Graphics.OpenGL.DrawElementsType type, IntPtr indices, Int32 primcount, Int32 modestride) { OpenTK.Graphics.OpenGL.GL.Ibm.MultiModeDrawElements(mode, count, type, indices, primcount, modestride); }
        internal override void tkglNormalPointerList(OpenTK.Graphics.OpenGL.NormalPointerType type, Int32 stride, IntPtr pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.NormalPointerList(type, stride, pointer, ptrstride); }
        internal override void tkglSecondaryColorPointerList(Int32 size, OpenTK.Graphics.OpenGL.IbmVertexArrayLists type, Int32 stride, IntPtr pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.SecondaryColorPointerList(size, type, stride, pointer, ptrstride); }
        internal override void tkglTexCoordPointerList(Int32 size, OpenTK.Graphics.OpenGL.TexCoordPointerType type, Int32 stride, IntPtr pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.TexCoordPointerList(size, type, stride, pointer, ptrstride); }
        internal override void tkglVertexPointerList(Int32 size, OpenTK.Graphics.OpenGL.VertexPointerType type, Int32 stride, IntPtr pointer, Int32 ptrstride) { OpenTK.Graphics.OpenGL.GL.Ibm.VertexPointerList(size, type, stride, pointer, ptrstride); }
        internal override void tkgl5BlendFuncSeparate(OpenTK.Graphics.OpenGL.All sfactorRGB, OpenTK.Graphics.OpenGL.All dfactorRGB, OpenTK.Graphics.OpenGL.All sfactorAlpha, OpenTK.Graphics.OpenGL.All dfactorAlpha) { OpenTK.Graphics.OpenGL.GL.Ingr.BlendFuncSeparate(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha); }
        internal override void tkgl3ColorPointer(Int32 size, OpenTK.Graphics.OpenGL.VertexPointerType type, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Intel.ColorPointer(size, type, pointer); }
        internal override void tkgl3NormalPointer(OpenTK.Graphics.OpenGL.NormalPointerType type, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Intel.NormalPointer(type, pointer); }
        internal override void tkgl3TexCoordPointer(Int32 size, OpenTK.Graphics.OpenGL.VertexPointerType type, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Intel.TexCoordPointer(size, type, pointer); }
        internal override void tkgl3VertexPointer(Int32 size, OpenTK.Graphics.OpenGL.VertexPointerType type, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Intel.VertexPointer(size, type, pointer); }
        internal override void tkglResizeBuffers() { OpenTK.Graphics.OpenGL.GL.Mesa.ResizeBuffers(); }
        internal override void tkgl33WindowPos2(Double x, Double y) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(x, y); }
        internal override void tkgl34WindowPos2(Double[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(v); }
        internal override void tkgl35WindowPos2(ref Double v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(ref v); }
        internal override unsafe void tkgl36WindowPos2(Double* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(v); }
        internal override void tkgl37WindowPos2(Single x, Single y) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(x, y); }
        internal override void tkgl38WindowPos2(Single[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(v); }
        internal override void tkgl39WindowPos2(ref Single v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(ref v); }
        internal override unsafe void tkgl40WindowPos2(Single* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(v); }
        internal override void tkgl41WindowPos2(Int32 x, Int32 y) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(x, y); }
        internal override void tkgl42WindowPos2(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(v); }
        internal override void tkgl43WindowPos2(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(ref v); }
        internal override unsafe void tkgl44WindowPos2(Int32* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(v); }
        internal override void tkgl45WindowPos2(Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(x, y); }
        internal override void tkgl46WindowPos2(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(v); }
        internal override void tkgl47WindowPos2(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(ref v); }
        internal override unsafe void tkgl48WindowPos2(Int16* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos2(v); }
        internal override void tkgl33WindowPos3(Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(x, y, z); }
        internal override void tkgl34WindowPos3(Double[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(v); }
        internal override void tkgl35WindowPos3(ref Double v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(ref v); }
        internal override unsafe void tkgl36WindowPos3(Double* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(v); }
        internal override void tkgl37WindowPos3(Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(x, y, z); }
        internal override void tkgl38WindowPos3(Single[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(v); }
        internal override void tkgl39WindowPos3(ref Single v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(ref v); }
        internal override unsafe void tkgl40WindowPos3(Single* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(v); }
        internal override void tkgl41WindowPos3(Int32 x, Int32 y, Int32 z) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(x, y, z); }
        internal override void tkgl42WindowPos3(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(v); }
        internal override void tkgl43WindowPos3(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(ref v); }
        internal override unsafe void tkgl44WindowPos3(Int32* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(v); }
        internal override void tkgl45WindowPos3(Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(x, y, z); }
        internal override void tkgl46WindowPos3(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(v); }
        internal override void tkgl47WindowPos3(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(ref v); }
        internal override unsafe void tkgl48WindowPos3(Int16* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos3(v); }
        internal override void tkglWindowPos4(Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(x, y, z, w); }
        internal override void tkgl2WindowPos4(Double[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(v); }
        internal override void tkgl3WindowPos4(ref Double v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(ref v); }
        internal override unsafe void tkgl4WindowPos4(Double* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(v); }
        internal override void tkgl5WindowPos4(Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(x, y, z, w); }
        internal override void tkgl6WindowPos4(Single[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(v); }
        internal override void tkgl7WindowPos4(ref Single v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(ref v); }
        internal override unsafe void tkgl8WindowPos4(Single* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(v); }
        internal override void tkgl9WindowPos4(Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(x, y, z, w); }
        internal override void tkgl10WindowPos4(Int32[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(v); }
        internal override void tkgl11WindowPos4(ref Int32 v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(ref v); }
        internal override unsafe void tkgl12WindowPos4(Int32* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(v); }
        internal override void tkgl13WindowPos4(Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(x, y, z, w); }
        internal override void tkgl14WindowPos4(Int16[] v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(v); }
        internal override void tkgl15WindowPos4(ref Int16 v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(ref v); }
        internal override unsafe void tkgl16WindowPos4(Int16* v) { OpenTK.Graphics.OpenGL.GL.Mesa.WindowPos4(v); }
        internal override void tkglActiveVarying(Int32 program, String name) { OpenTK.Graphics.OpenGL.GL.NV.ActiveVarying(program, name); }
        internal override void tkgl2ActiveVarying(UInt32 program, String name) { OpenTK.Graphics.OpenGL.GL.NV.ActiveVarying(program, name); }
        internal override bool tkglAreProgramsResident(Int32 n, Int32[] programs, bool[] residences) { return OpenTK.Graphics.OpenGL.GL.NV.AreProgramsResident(n, programs, residences); }
        internal override bool tkgl2AreProgramsResident(Int32 n, ref Int32 programs, out bool residences) { return OpenTK.Graphics.OpenGL.GL.NV.AreProgramsResident(n, ref programs, out residences); }
        internal override unsafe bool tkgl3AreProgramsResident(Int32 n, Int32* programs, bool* residences) { return OpenTK.Graphics.OpenGL.GL.NV.AreProgramsResident(n, programs, residences); }
        internal override bool tkgl4AreProgramsResident(Int32 n, UInt32[] programs, bool[] residences) { return OpenTK.Graphics.OpenGL.GL.NV.AreProgramsResident(n, programs, residences); }
        internal override bool tkgl5AreProgramsResident(Int32 n, ref UInt32 programs, out bool residences) { return OpenTK.Graphics.OpenGL.GL.NV.AreProgramsResident(n, ref programs, out residences); }
        internal override unsafe bool tkgl6AreProgramsResident(Int32 n, UInt32* programs, bool* residences) { return OpenTK.Graphics.OpenGL.GL.NV.AreProgramsResident(n, programs, residences); }
        internal override void tkgl3BeginConditionalRender(Int32 id, OpenTK.Graphics.OpenGL.NvConditionalRender mode) { OpenTK.Graphics.OpenGL.GL.NV.BeginConditionalRender(id, mode); }
        internal override void tkgl4BeginConditionalRender(UInt32 id, OpenTK.Graphics.OpenGL.NvConditionalRender mode) { OpenTK.Graphics.OpenGL.GL.NV.BeginConditionalRender(id, mode); }
        internal override void tkglBeginOcclusionQuery(Int32 id) { OpenTK.Graphics.OpenGL.GL.NV.BeginOcclusionQuery(id); }
        internal override void tkgl2BeginOcclusionQuery(UInt32 id) { OpenTK.Graphics.OpenGL.GL.NV.BeginOcclusionQuery(id); }
        internal override void tkgl3BeginTransformFeedback(OpenTK.Graphics.OpenGL.NvTransformFeedback primitiveMode) { OpenTK.Graphics.OpenGL.GL.NV.BeginTransformFeedback(primitiveMode); }
        internal override void tkgl5BindBufferBase(OpenTK.Graphics.OpenGL.NvTransformFeedback target, Int32 index, Int32 buffer) { OpenTK.Graphics.OpenGL.GL.NV.BindBufferBase(target, index, buffer); }
        internal override void tkgl6BindBufferBase(OpenTK.Graphics.OpenGL.NvTransformFeedback target, UInt32 index, UInt32 buffer) { OpenTK.Graphics.OpenGL.GL.NV.BindBufferBase(target, index, buffer); }
        internal override void tkgl3BindBufferOffset(OpenTK.Graphics.OpenGL.NvTransformFeedback target, Int32 index, Int32 buffer, IntPtr offset) { OpenTK.Graphics.OpenGL.GL.NV.BindBufferOffset(target, index, buffer, offset); }
        internal override void tkgl4BindBufferOffset(OpenTK.Graphics.OpenGL.NvTransformFeedback target, UInt32 index, UInt32 buffer, IntPtr offset) { OpenTK.Graphics.OpenGL.GL.NV.BindBufferOffset(target, index, buffer, offset); }
        internal override void tkgl5BindBufferRange(OpenTK.Graphics.OpenGL.NvTransformFeedback target, Int32 index, Int32 buffer, IntPtr offset, IntPtr size) { OpenTK.Graphics.OpenGL.GL.NV.BindBufferRange(target, index, buffer, offset, size); }
        internal override void tkgl6BindBufferRange(OpenTK.Graphics.OpenGL.NvTransformFeedback target, UInt32 index, UInt32 buffer, IntPtr offset, IntPtr size) { OpenTK.Graphics.OpenGL.GL.NV.BindBufferRange(target, index, buffer, offset, size); }
        internal override void tkgl3BindProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 id) { OpenTK.Graphics.OpenGL.GL.NV.BindProgram(target, id); }
        internal override void tkgl4BindProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 id) { OpenTK.Graphics.OpenGL.GL.NV.BindProgram(target, id); }
        internal override void tkglBindTransformFeedback(OpenTK.Graphics.OpenGL.NvTransformFeedback2 target, Int32 id) { OpenTK.Graphics.OpenGL.GL.NV.BindTransformFeedback(target, id); }
        internal override void tkgl2BindTransformFeedback(OpenTK.Graphics.OpenGL.NvTransformFeedback2 target, UInt32 id) { OpenTK.Graphics.OpenGL.GL.NV.BindTransformFeedback(target, id); }
        internal override void tkgl2ClearDepth(Double depth) { OpenTK.Graphics.OpenGL.GL.NV.ClearDepth(depth); }
        internal override void tkglColor3h(OpenTK.Half red, OpenTK.Half green, OpenTK.Half blue) { OpenTK.Graphics.OpenGL.GL.NV.Color3h(red, green, blue); }
        internal override void tkgl2Color3h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.Color3h(v); }
        internal override void tkgl3Color3h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.Color3h(ref v); }
        internal override unsafe void tkgl4Color3h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.Color3h(v); }
        internal override void tkglColor4h(OpenTK.Half red, OpenTK.Half green, OpenTK.Half blue, OpenTK.Half alpha) { OpenTK.Graphics.OpenGL.GL.NV.Color4h(red, green, blue, alpha); }
        internal override void tkgl2Color4h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.Color4h(v); }
        internal override void tkgl3Color4h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.Color4h(ref v); }
        internal override unsafe void tkgl4Color4h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.Color4h(v); }
        internal override void tkglCombinerInput(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners input, OpenTK.Graphics.OpenGL.NvRegisterCombiners mapping, OpenTK.Graphics.OpenGL.NvRegisterCombiners componentUsage) { OpenTK.Graphics.OpenGL.GL.NV.CombinerInput(stage, portion, variable, input, mapping, componentUsage); }
        internal override void tkglCombinerOutput(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners abOutput, OpenTK.Graphics.OpenGL.NvRegisterCombiners cdOutput, OpenTK.Graphics.OpenGL.NvRegisterCombiners sumOutput, OpenTK.Graphics.OpenGL.NvRegisterCombiners scale, OpenTK.Graphics.OpenGL.NvRegisterCombiners bias, bool abDotProduct, bool cdDotProduct, bool muxSum) { OpenTK.Graphics.OpenGL.GL.NV.CombinerOutput(stage, portion, abOutput, cdOutput, sumOutput, scale, bias, abDotProduct, cdDotProduct, muxSum); }
        internal override void tkglCombinerParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single param) { OpenTK.Graphics.OpenGL.GL.NV.CombinerParameter(pname, param); }
        internal override void tkgl2CombinerParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.CombinerParameter(pname, @params); }
        internal override unsafe void tkgl3CombinerParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.CombinerParameter(pname, @params); }
        internal override void tkgl4CombinerParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.NV.CombinerParameter(pname, param); }
        internal override void tkgl5CombinerParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.CombinerParameter(pname, @params); }
        internal override unsafe void tkgl6CombinerParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.CombinerParameter(pname, @params); }
        internal override void tkglCombinerStageParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners2 stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners2 pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.CombinerStageParameter(stage, pname, @params); }
        internal override void tkgl2CombinerStageParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners2 stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners2 pname, ref Single @params) { OpenTK.Graphics.OpenGL.GL.NV.CombinerStageParameter(stage, pname, ref @params); }
        internal override unsafe void tkgl3CombinerStageParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners2 stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners2 pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.CombinerStageParameter(stage, pname, @params); }
        internal override void tkgl7DeleteFences(Int32 n, Int32[] fences) { OpenTK.Graphics.OpenGL.GL.NV.DeleteFences(n, fences); }
        internal override void tkgl8DeleteFences(Int32 n, ref Int32 fences) { OpenTK.Graphics.OpenGL.GL.NV.DeleteFences(n, ref fences); }
        internal override unsafe void tkgl9DeleteFences(Int32 n, Int32* fences) { OpenTK.Graphics.OpenGL.GL.NV.DeleteFences(n, fences); }
        internal override void tkgl10DeleteFences(Int32 n, UInt32[] fences) { OpenTK.Graphics.OpenGL.GL.NV.DeleteFences(n, fences); }
        internal override void tkgl11DeleteFences(Int32 n, ref UInt32 fences) { OpenTK.Graphics.OpenGL.GL.NV.DeleteFences(n, ref fences); }
        internal override unsafe void tkgl12DeleteFences(Int32 n, UInt32* fences) { OpenTK.Graphics.OpenGL.GL.NV.DeleteFences(n, fences); }
        internal override void tkglDeleteOcclusionQueries(Int32 n, Int32[] ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteOcclusionQueries(n, ids); }
        internal override void tkgl2DeleteOcclusionQueries(Int32 n, ref Int32 ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteOcclusionQueries(n, ref ids); }
        internal override unsafe void tkgl3DeleteOcclusionQueries(Int32 n, Int32* ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteOcclusionQueries(n, ids); }
        internal override void tkgl4DeleteOcclusionQueries(Int32 n, UInt32[] ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteOcclusionQueries(n, ids); }
        internal override void tkgl5DeleteOcclusionQueries(Int32 n, ref UInt32 ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteOcclusionQueries(n, ref ids); }
        internal override unsafe void tkgl6DeleteOcclusionQueries(Int32 n, UInt32* ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteOcclusionQueries(n, ids); }
        internal override void tkgl9DeleteProgram(Int32 n, Int32[] programs) { OpenTK.Graphics.OpenGL.GL.NV.DeleteProgram(n, programs); }
        internal override void tkgl10DeleteProgram(Int32 n, ref Int32 programs) { OpenTK.Graphics.OpenGL.GL.NV.DeleteProgram(n, ref programs); }
        internal override unsafe void tkgl11DeleteProgram(Int32 n, Int32* programs) { OpenTK.Graphics.OpenGL.GL.NV.DeleteProgram(n, programs); }
        internal override void tkgl12DeleteProgram(Int32 n, UInt32[] programs) { OpenTK.Graphics.OpenGL.GL.NV.DeleteProgram(n, programs); }
        internal override void tkgl13DeleteProgram(Int32 n, ref UInt32 programs) { OpenTK.Graphics.OpenGL.GL.NV.DeleteProgram(n, ref programs); }
        internal override unsafe void tkgl14DeleteProgram(Int32 n, UInt32* programs) { OpenTK.Graphics.OpenGL.GL.NV.DeleteProgram(n, programs); }
        internal override void tkglDeleteTransformFeedback(Int32 n, Int32[] ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteTransformFeedback(n, ids); }
        internal override void tkgl2DeleteTransformFeedback(Int32 n, ref Int32 ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteTransformFeedback(n, ref ids); }
        internal override unsafe void tkgl3DeleteTransformFeedback(Int32 n, Int32* ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteTransformFeedback(n, ids); }
        internal override void tkgl4DeleteTransformFeedback(Int32 n, UInt32[] ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteTransformFeedback(n, ids); }
        internal override void tkgl5DeleteTransformFeedback(Int32 n, ref UInt32 ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteTransformFeedback(n, ref ids); }
        internal override unsafe void tkgl6DeleteTransformFeedback(Int32 n, UInt32* ids) { OpenTK.Graphics.OpenGL.GL.NV.DeleteTransformFeedback(n, ids); }
        internal override void tkgl2DepthBounds(Double zmin, Double zmax) { OpenTK.Graphics.OpenGL.GL.NV.DepthBounds(zmin, zmax); }
        internal override void tkgl2DepthRange(Double zNear, Double zFar) { OpenTK.Graphics.OpenGL.GL.NV.DepthRange(zNear, zFar); }
        internal override void tkglDrawTransformFeedback(OpenTK.Graphics.OpenGL.NvTransformFeedback2 mode, Int32 id) { OpenTK.Graphics.OpenGL.GL.NV.DrawTransformFeedback(mode, id); }
        internal override void tkgl2DrawTransformFeedback(OpenTK.Graphics.OpenGL.NvTransformFeedback2 mode, UInt32 id) { OpenTK.Graphics.OpenGL.GL.NV.DrawTransformFeedback(mode, id); }
        internal override void tkgl2EndConditionalRender() { OpenTK.Graphics.OpenGL.GL.NV.EndConditionalRender(); }
        internal override void tkglEndOcclusionQuery() { OpenTK.Graphics.OpenGL.GL.NV.EndOcclusionQuery(); }
        internal override void tkgl3EndTransformFeedback() { OpenTK.Graphics.OpenGL.GL.NV.EndTransformFeedback(); }
        internal override void tkglEvalMap(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators mode) { OpenTK.Graphics.OpenGL.GL.NV.EvalMap(target, mode); }
        internal override void tkglExecuteProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 id, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ExecuteProgram(target, id, @params); }
        internal override void tkgl2ExecuteProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 id, ref Single @params) { OpenTK.Graphics.OpenGL.GL.NV.ExecuteProgram(target, id, ref @params); }
        internal override unsafe void tkgl3ExecuteProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 id, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.ExecuteProgram(target, id, @params); }
        internal override void tkgl4ExecuteProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 id, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ExecuteProgram(target, id, @params); }
        internal override void tkgl5ExecuteProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 id, ref Single @params) { OpenTK.Graphics.OpenGL.GL.NV.ExecuteProgram(target, id, ref @params); }
        internal override unsafe void tkgl6ExecuteProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 id, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.ExecuteProgram(target, id, @params); }
        internal override void tkglFinalCombinerInput(OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners input, OpenTK.Graphics.OpenGL.NvRegisterCombiners mapping, OpenTK.Graphics.OpenGL.NvRegisterCombiners componentUsage) { OpenTK.Graphics.OpenGL.GL.NV.FinalCombinerInput(variable, input, mapping, componentUsage); }
        internal override void tkgl3FinishFence(Int32 fence) { OpenTK.Graphics.OpenGL.GL.NV.FinishFence(fence); }
        internal override void tkgl4FinishFence(UInt32 fence) { OpenTK.Graphics.OpenGL.GL.NV.FinishFence(fence); }
        internal override void tkglFlushPixelDataRange(OpenTK.Graphics.OpenGL.NvPixelDataRange target) { OpenTK.Graphics.OpenGL.GL.NV.FlushPixelDataRange(target); }
        internal override void tkgl2FlushVertexArrayRange() { OpenTK.Graphics.OpenGL.GL.NV.FlushVertexArrayRange(); }
        internal override void tkglFogCoordh(OpenTK.Half fog) { OpenTK.Graphics.OpenGL.GL.NV.FogCoordh(fog); }
        internal override unsafe void tkgl2FogCoordh(OpenTK.Half* fog) { OpenTK.Graphics.OpenGL.GL.NV.FogCoordh(fog); }
        internal override void tkgl7GenFences(Int32 n, Int32[] fences) { OpenTK.Graphics.OpenGL.GL.NV.GenFences(n, fences); }
        internal override void tkgl8GenFences(Int32 n, out Int32 fences) { OpenTK.Graphics.OpenGL.GL.NV.GenFences(n, out fences); }
        internal override unsafe void tkgl9GenFences(Int32 n, Int32* fences) { OpenTK.Graphics.OpenGL.GL.NV.GenFences(n, fences); }
        internal override void tkgl10GenFences(Int32 n, UInt32[] fences) { OpenTK.Graphics.OpenGL.GL.NV.GenFences(n, fences); }
        internal override void tkgl11GenFences(Int32 n, out UInt32 fences) { OpenTK.Graphics.OpenGL.GL.NV.GenFences(n, out fences); }
        internal override unsafe void tkgl12GenFences(Int32 n, UInt32* fences) { OpenTK.Graphics.OpenGL.GL.NV.GenFences(n, fences); }
        internal override void tkglGenOcclusionQueries(Int32 n, Int32[] ids) { OpenTK.Graphics.OpenGL.GL.NV.GenOcclusionQueries(n, ids); }
        internal override void tkgl2GenOcclusionQueries(Int32 n, out Int32 ids) { OpenTK.Graphics.OpenGL.GL.NV.GenOcclusionQueries(n, out ids); }
        internal override unsafe void tkgl3GenOcclusionQueries(Int32 n, Int32* ids) { OpenTK.Graphics.OpenGL.GL.NV.GenOcclusionQueries(n, ids); }
        internal override void tkgl4GenOcclusionQueries(Int32 n, UInt32[] ids) { OpenTK.Graphics.OpenGL.GL.NV.GenOcclusionQueries(n, ids); }
        internal override void tkgl5GenOcclusionQueries(Int32 n, out UInt32 ids) { OpenTK.Graphics.OpenGL.GL.NV.GenOcclusionQueries(n, out ids); }
        internal override unsafe void tkgl6GenOcclusionQueries(Int32 n, UInt32* ids) { OpenTK.Graphics.OpenGL.GL.NV.GenOcclusionQueries(n, ids); }
        internal override void tkgl7GenProgram(Int32 n, Int32[] programs) { OpenTK.Graphics.OpenGL.GL.NV.GenProgram(n, programs); }
        internal override void tkgl8GenProgram(Int32 n, out Int32 programs) { OpenTK.Graphics.OpenGL.GL.NV.GenProgram(n, out programs); }
        internal override unsafe void tkgl9GenProgram(Int32 n, Int32* programs) { OpenTK.Graphics.OpenGL.GL.NV.GenProgram(n, programs); }
        internal override void tkgl10GenProgram(Int32 n, UInt32[] programs) { OpenTK.Graphics.OpenGL.GL.NV.GenProgram(n, programs); }
        internal override void tkgl11GenProgram(Int32 n, out UInt32 programs) { OpenTK.Graphics.OpenGL.GL.NV.GenProgram(n, out programs); }
        internal override unsafe void tkgl12GenProgram(Int32 n, UInt32* programs) { OpenTK.Graphics.OpenGL.GL.NV.GenProgram(n, programs); }
        internal override void tkglGenTransformFeedback(Int32 n, Int32[] ids) { OpenTK.Graphics.OpenGL.GL.NV.GenTransformFeedback(n, ids); }
        internal override void tkgl2GenTransformFeedback(Int32 n, out Int32 ids) { OpenTK.Graphics.OpenGL.GL.NV.GenTransformFeedback(n, out ids); }
        internal override unsafe void tkgl3GenTransformFeedback(Int32 n, Int32* ids) { OpenTK.Graphics.OpenGL.GL.NV.GenTransformFeedback(n, ids); }
        internal override void tkgl4GenTransformFeedback(Int32 n, UInt32[] ids) { OpenTK.Graphics.OpenGL.GL.NV.GenTransformFeedback(n, ids); }
        internal override void tkgl5GenTransformFeedback(Int32 n, out UInt32 ids) { OpenTK.Graphics.OpenGL.GL.NV.GenTransformFeedback(n, out ids); }
        internal override unsafe void tkgl6GenTransformFeedback(Int32 n, UInt32* ids) { OpenTK.Graphics.OpenGL.GL.NV.GenTransformFeedback(n, ids); }
        internal override void tkglGetActiveVarying(Int32 program, Int32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.NvTransformFeedback type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.NV.GetActiveVarying(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl2GetActiveVarying(Int32 program, Int32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.NvTransformFeedback* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.NV.GetActiveVarying(program, index, bufSize, length, size, type, name); }
        internal override void tkgl3GetActiveVarying(UInt32 program, UInt32 index, Int32 bufSize, out Int32 length, out Int32 size, out OpenTK.Graphics.OpenGL.NvTransformFeedback type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.NV.GetActiveVarying(program, index, bufSize, out length, out size, out type, name); }
        internal override unsafe void tkgl4GetActiveVarying(UInt32 program, UInt32 index, Int32 bufSize, Int32* length, Int32* size, OpenTK.Graphics.OpenGL.NvTransformFeedback* type, StringBuilder name) { OpenTK.Graphics.OpenGL.GL.NV.GetActiveVarying(program, index, bufSize, length, size, type, name); }
        internal override void tkglGetCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerInputParameter(stage, portion, variable, pname, @params); }
        internal override void tkgl2GetCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerInputParameter(stage, portion, variable, pname, out @params); }
        internal override unsafe void tkgl3GetCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerInputParameter(stage, portion, variable, pname, @params); }
        internal override void tkgl4GetCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerInputParameter(stage, portion, variable, pname, @params); }
        internal override void tkgl5GetCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerInputParameter(stage, portion, variable, pname, out @params); }
        internal override unsafe void tkgl6GetCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerInputParameter(stage, portion, variable, pname, @params); }
        internal override void tkglGetCombinerOutputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerOutputParameter(stage, portion, pname, @params); }
        internal override void tkgl2GetCombinerOutputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerOutputParameter(stage, portion, pname, out @params); }
        internal override unsafe void tkgl3GetCombinerOutputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerOutputParameter(stage, portion, pname, @params); }
        internal override void tkgl4GetCombinerOutputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerOutputParameter(stage, portion, pname, @params); }
        internal override void tkgl5GetCombinerOutputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerOutputParameter(stage, portion, pname, out @params); }
        internal override unsafe void tkgl6GetCombinerOutputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners portion, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerOutputParameter(stage, portion, pname, @params); }
        internal override void tkglGetCombinerStageParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners2 stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners2 pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerStageParameter(stage, pname, @params); }
        internal override void tkgl2GetCombinerStageParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners2 stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners2 pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerStageParameter(stage, pname, out @params); }
        internal override unsafe void tkgl3GetCombinerStageParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners2 stage, OpenTK.Graphics.OpenGL.NvRegisterCombiners2 pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetCombinerStageParameter(stage, pname, @params); }
        internal override void tkglGetFence(Int32 fence, OpenTK.Graphics.OpenGL.NvFence pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFence(fence, pname, @params); }
        internal override void tkgl2GetFence(Int32 fence, OpenTK.Graphics.OpenGL.NvFence pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFence(fence, pname, out @params); }
        internal override unsafe void tkgl3GetFence(Int32 fence, OpenTK.Graphics.OpenGL.NvFence pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFence(fence, pname, @params); }
        internal override void tkgl4GetFence(UInt32 fence, OpenTK.Graphics.OpenGL.NvFence pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFence(fence, pname, @params); }
        internal override void tkgl5GetFence(UInt32 fence, OpenTK.Graphics.OpenGL.NvFence pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFence(fence, pname, out @params); }
        internal override unsafe void tkgl6GetFence(UInt32 fence, OpenTK.Graphics.OpenGL.NvFence pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFence(fence, pname, @params); }
        internal override void tkglGetFinalCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFinalCombinerInputParameter(variable, pname, @params); }
        internal override void tkgl2GetFinalCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFinalCombinerInputParameter(variable, pname, out @params); }
        internal override unsafe void tkgl3GetFinalCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFinalCombinerInputParameter(variable, pname, @params); }
        internal override void tkgl4GetFinalCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFinalCombinerInputParameter(variable, pname, @params); }
        internal override void tkgl5GetFinalCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFinalCombinerInputParameter(variable, pname, out @params); }
        internal override unsafe void tkgl6GetFinalCombinerInputParameter(OpenTK.Graphics.OpenGL.NvRegisterCombiners variable, OpenTK.Graphics.OpenGL.NvRegisterCombiners pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetFinalCombinerInputParameter(variable, pname, @params); }
        internal override void tkglGetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, Int32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, @params); }
        internal override void tkgl2GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, Int32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, out @params); }
        internal override unsafe void tkgl3GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, Int32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, @params); }
        internal override void tkgl4GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, UInt32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, @params); }
        internal override void tkgl5GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, UInt32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, out @params); }
        internal override unsafe void tkgl6GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, UInt32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, @params); }
        internal override void tkgl7GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, Int32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, @params); }
        internal override void tkgl8GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, Int32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, out @params); }
        internal override unsafe void tkgl9GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, Int32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, @params); }
        internal override void tkgl10GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, UInt32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, @params); }
        internal override void tkgl11GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, UInt32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, out @params); }
        internal override unsafe void tkgl12GetMapAttribParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, UInt32 index, OpenTK.Graphics.OpenGL.NvEvaluators pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapAttribParameter(target, index, pname, @params); }
        internal override void tkglGetMapControlPoints(OpenTK.Graphics.OpenGL.NvEvaluators target, Int32 index, OpenTK.Graphics.OpenGL.NvEvaluators type, Int32 ustride, Int32 vstride, bool packed, IntPtr points) { OpenTK.Graphics.OpenGL.GL.NV.GetMapControlPoints(target, index, type, ustride, vstride, packed, points); }
        internal override void tkgl2GetMapControlPoints(OpenTK.Graphics.OpenGL.NvEvaluators target, UInt32 index, OpenTK.Graphics.OpenGL.NvEvaluators type, Int32 ustride, Int32 vstride, bool packed, IntPtr points) { OpenTK.Graphics.OpenGL.GL.NV.GetMapControlPoints(target, index, type, ustride, vstride, packed, points); }
        internal override void tkglGetMapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapParameter(target, pname, @params); }
        internal override void tkgl2GetMapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapParameter(target, pname, out @params); }
        internal override unsafe void tkgl3GetMapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapParameter(target, pname, @params); }
        internal override void tkgl4GetMapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapParameter(target, pname, @params); }
        internal override void tkgl5GetMapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapParameter(target, pname, out @params); }
        internal override unsafe void tkgl6GetMapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetMapParameter(target, pname, @params); }
        internal override void tkgl7GetMultisample(OpenTK.Graphics.OpenGL.NvExplicitMultisample pname, Int32 index, Single[] val) { OpenTK.Graphics.OpenGL.GL.NV.GetMultisample(pname, index, val); }
        internal override void tkgl8GetMultisample(OpenTK.Graphics.OpenGL.NvExplicitMultisample pname, Int32 index, out Single val) { OpenTK.Graphics.OpenGL.GL.NV.GetMultisample(pname, index, out val); }
        internal override unsafe void tkgl9GetMultisample(OpenTK.Graphics.OpenGL.NvExplicitMultisample pname, Int32 index, Single* val) { OpenTK.Graphics.OpenGL.GL.NV.GetMultisample(pname, index, val); }
        internal override void tkgl10GetMultisample(OpenTK.Graphics.OpenGL.NvExplicitMultisample pname, UInt32 index, Single[] val) { OpenTK.Graphics.OpenGL.GL.NV.GetMultisample(pname, index, val); }
        internal override void tkgl11GetMultisample(OpenTK.Graphics.OpenGL.NvExplicitMultisample pname, UInt32 index, out Single val) { OpenTK.Graphics.OpenGL.GL.NV.GetMultisample(pname, index, out val); }
        internal override unsafe void tkgl12GetMultisample(OpenTK.Graphics.OpenGL.NvExplicitMultisample pname, UInt32 index, Single* val) { OpenTK.Graphics.OpenGL.GL.NV.GetMultisample(pname, index, val); }
        internal override void tkglGetOcclusionQuery(Int32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, @params); }
        internal override void tkgl2GetOcclusionQuery(Int32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, out @params); }
        internal override unsafe void tkgl3GetOcclusionQuery(Int32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, @params); }
        internal override void tkgl4GetOcclusionQuery(UInt32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, @params); }
        internal override void tkgl5GetOcclusionQuery(UInt32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, out @params); }
        internal override unsafe void tkgl6GetOcclusionQuery(UInt32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, @params); }
        internal override void tkgl7GetOcclusionQuery(UInt32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, @params); }
        internal override void tkgl8GetOcclusionQuery(UInt32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, out @params); }
        internal override unsafe void tkgl9GetOcclusionQuery(UInt32 id, OpenTK.Graphics.OpenGL.NvOcclusionQuery pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetOcclusionQuery(id, pname, @params); }
        internal override void tkglGetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, @params); }
        internal override void tkgl2GetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, out @params); }
        internal override unsafe void tkgl3GetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, @params); }
        internal override void tkgl4GetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, @params); }
        internal override void tkgl5GetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, out @params); }
        internal override unsafe void tkgl6GetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, @params); }
        internal override void tkgl7GetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, @params); }
        internal override void tkgl8GetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, out @params); }
        internal override unsafe void tkgl9GetProgramEnvParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramEnvParameterI(target, index, @params); }
        internal override void tkgl9GetProgram(Int32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgram(id, pname, @params); }
        internal override void tkgl10GetProgram(Int32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgram(id, pname, out @params); }
        internal override unsafe void tkgl11GetProgram(Int32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgram(id, pname, @params); }
        internal override void tkgl12GetProgram(UInt32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgram(id, pname, @params); }
        internal override void tkgl13GetProgram(UInt32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgram(id, pname, out @params); }
        internal override unsafe void tkgl14GetProgram(UInt32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgram(id, pname, @params); }
        internal override void tkglGetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, @params); }
        internal override void tkgl2GetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, out @params); }
        internal override unsafe void tkgl3GetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, @params); }
        internal override void tkgl4GetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, @params); }
        internal override void tkgl5GetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, out @params); }
        internal override unsafe void tkgl6GetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, @params); }
        internal override void tkgl7GetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, @params); }
        internal override void tkgl8GetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, out @params); }
        internal override unsafe void tkgl9GetProgramLocalParameterI(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramLocalParameterI(target, index, @params); }
        internal override void tkglGetProgramNamedParameter(Int32 id, Int32 len, ref Byte name, out Double @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, ref name, out @params); }
        internal override unsafe void tkgl2GetProgramNamedParameter(Int32 id, Int32 len, Byte* name, Double[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, name, @params); }
        internal override unsafe void tkgl3GetProgramNamedParameter(Int32 id, Int32 len, Byte* name, Double* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, name, @params); }
        internal override void tkgl4GetProgramNamedParameter(UInt32 id, Int32 len, ref Byte name, out Double @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, ref name, out @params); }
        internal override unsafe void tkgl5GetProgramNamedParameter(UInt32 id, Int32 len, Byte* name, Double[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, name, @params); }
        internal override unsafe void tkgl6GetProgramNamedParameter(UInt32 id, Int32 len, Byte* name, Double* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, name, @params); }
        internal override void tkgl7GetProgramNamedParameter(Int32 id, Int32 len, ref Byte name, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, ref name, out @params); }
        internal override unsafe void tkgl8GetProgramNamedParameter(Int32 id, Int32 len, Byte* name, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, name, @params); }
        internal override unsafe void tkgl9GetProgramNamedParameter(Int32 id, Int32 len, Byte* name, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, name, @params); }
        internal override void tkgl10GetProgramNamedParameter(UInt32 id, Int32 len, ref Byte name, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, ref name, out @params); }
        internal override unsafe void tkgl11GetProgramNamedParameter(UInt32 id, Int32 len, Byte* name, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, name, @params); }
        internal override unsafe void tkgl12GetProgramNamedParameter(UInt32 id, Int32 len, Byte* name, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramNamedParameter(id, len, name, @params); }
        internal override void tkglGetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, @params); }
        internal override void tkgl2GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, out @params); }
        internal override unsafe void tkgl3GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, @params); }
        internal override void tkgl4GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Double[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, @params); }
        internal override void tkgl5GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, out @params); }
        internal override unsafe void tkgl6GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, @params); }
        internal override void tkgl7GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, @params); }
        internal override void tkgl8GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, out @params); }
        internal override unsafe void tkgl9GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, @params); }
        internal override void tkgl10GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, @params); }
        internal override void tkgl11GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, out @params); }
        internal override unsafe void tkgl12GetProgramParameter(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramParameter(target, index, pname, @params); }
        internal override void tkgl2GetProgramString(Int32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Byte[] program) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramString(id, pname, program); }
        internal override void tkgl3GetProgramString(Int32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Byte program) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramString(id, pname, out program); }
        internal override unsafe void tkgl4GetProgramString(Int32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Byte* program) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramString(id, pname, program); }
        internal override void tkgl5GetProgramString(UInt32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Byte[] program) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramString(id, pname, program); }
        internal override void tkgl6GetProgramString(UInt32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Byte program) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramString(id, pname, out program); }
        internal override unsafe void tkgl7GetProgramString(UInt32 id, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Byte* program) { OpenTK.Graphics.OpenGL.GL.NV.GetProgramString(id, pname, program); }
        internal override void tkglGetTrackMatrix(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 address, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetTrackMatrix(target, address, pname, out @params); }
        internal override unsafe void tkgl2GetTrackMatrix(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 address, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetTrackMatrix(target, address, pname, @params); }
        internal override void tkgl3GetTrackMatrix(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 address, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetTrackMatrix(target, address, pname, out @params); }
        internal override unsafe void tkgl4GetTrackMatrix(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 address, OpenTK.Graphics.OpenGL.AssemblyProgramParameterArb pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetTrackMatrix(target, address, pname, @params); }
        internal override void tkgl9GetTransformFeedbackVarying(Int32 program, Int32 index, out Int32 location) { OpenTK.Graphics.OpenGL.GL.NV.GetTransformFeedbackVarying(program, index, out location); }
        internal override unsafe void tkgl10GetTransformFeedbackVarying(Int32 program, Int32 index, Int32* location) { OpenTK.Graphics.OpenGL.GL.NV.GetTransformFeedbackVarying(program, index, location); }
        internal override void tkgl11GetTransformFeedbackVarying(UInt32 program, UInt32 index, out Int32 location) { OpenTK.Graphics.OpenGL.GL.NV.GetTransformFeedbackVarying(program, index, out location); }
        internal override unsafe void tkgl12GetTransformFeedbackVarying(UInt32 program, UInt32 index, Int32* location) { OpenTK.Graphics.OpenGL.GL.NV.GetTransformFeedbackVarying(program, index, location); }
        internal override Int32 tkglGetVaryingLocation(Int32 program, String name) { return OpenTK.Graphics.OpenGL.GL.NV.GetVaryingLocation(program, name); }
        internal override Int32 tkgl2GetVaryingLocation(UInt32 program, String name) { return OpenTK.Graphics.OpenGL.GL.NV.GetVaryingLocation(program, name); }
        internal override void tkgl37GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl38GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl39GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Double @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl40GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Double* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl41GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl42GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl43GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl44GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl45GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl46GetVertexAttrib(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl47GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, out @params); }
        internal override unsafe void tkgl48GetVertexAttrib(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttrib(index, pname, @params); }
        internal override void tkgl5GetVertexAttribPointer(Int32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttribPointer(index, pname, pointer); }
        internal override void tkgl6GetVertexAttribPointer(UInt32 index, OpenTK.Graphics.OpenGL.NvVertexProgram pname, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.NV.GetVertexAttribPointer(index, pname, pointer); }
        internal override void tkglGetVideoi64(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int64[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoi64(video_slot, pname, @params); }
        internal override void tkgl2GetVideoi64(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, out Int64 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoi64(video_slot, pname, out @params); }
        internal override unsafe void tkgl3GetVideoi64(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int64* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoi64(video_slot, pname, @params); }
        internal override void tkgl4GetVideoi64(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int64[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoi64(video_slot, pname, @params); }
        internal override void tkgl5GetVideoi64(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, out Int64 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoi64(video_slot, pname, out @params); }
        internal override unsafe void tkgl6GetVideoi64(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int64* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoi64(video_slot, pname, @params); }
        internal override void tkglGetVideo(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, @params); }
        internal override void tkgl2GetVideo(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, out @params); }
        internal override unsafe void tkgl3GetVideo(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, @params); }
        internal override void tkgl4GetVideo(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, @params); }
        internal override void tkgl5GetVideo(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, out @params); }
        internal override unsafe void tkgl6GetVideo(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, @params); }
        internal override void tkglGetVideoui64(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int64[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoui64(video_slot, pname, @params); }
        internal override void tkgl2GetVideoui64(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, out Int64 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoui64(video_slot, pname, out @params); }
        internal override unsafe void tkgl3GetVideoui64(Int32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, Int64* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoui64(video_slot, pname, @params); }
        internal override void tkgl4GetVideoui64(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, UInt64[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoui64(video_slot, pname, @params); }
        internal override void tkgl5GetVideoui64(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, out UInt64 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoui64(video_slot, pname, out @params); }
        internal override unsafe void tkgl6GetVideoui64(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, UInt64* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideoui64(video_slot, pname, @params); }
        internal override void tkgl7GetVideo(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, @params); }
        internal override void tkgl8GetVideo(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, out UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, out @params); }
        internal override unsafe void tkgl9GetVideo(UInt32 video_slot, OpenTK.Graphics.OpenGL.NvPresentVideo pname, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.GetVideo(video_slot, pname, @params); }
        internal override bool tkgl3IsFence(Int32 fence) { return OpenTK.Graphics.OpenGL.GL.NV.IsFence(fence); }
        internal override bool tkgl4IsFence(UInt32 fence) { return OpenTK.Graphics.OpenGL.GL.NV.IsFence(fence); }
        internal override bool tkglIsOcclusionQuery(Int32 id) { return OpenTK.Graphics.OpenGL.GL.NV.IsOcclusionQuery(id); }
        internal override bool tkgl2IsOcclusionQuery(UInt32 id) { return OpenTK.Graphics.OpenGL.GL.NV.IsOcclusionQuery(id); }
        internal override bool tkgl5IsProgram(Int32 id) { return OpenTK.Graphics.OpenGL.GL.NV.IsProgram(id); }
        internal override bool tkgl6IsProgram(UInt32 id) { return OpenTK.Graphics.OpenGL.GL.NV.IsProgram(id); }
        internal override bool tkglIsTransformFeedback(Int32 id) { return OpenTK.Graphics.OpenGL.GL.NV.IsTransformFeedback(id); }
        internal override bool tkgl2IsTransformFeedback(UInt32 id) { return OpenTK.Graphics.OpenGL.GL.NV.IsTransformFeedback(id); }
        internal override void tkglLoadProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 id, Int32 len, Byte[] program) { OpenTK.Graphics.OpenGL.GL.NV.LoadProgram(target, id, len, program); }
        internal override void tkgl2LoadProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 id, Int32 len, ref Byte program) { OpenTK.Graphics.OpenGL.GL.NV.LoadProgram(target, id, len, ref program); }
        internal override unsafe void tkgl3LoadProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 id, Int32 len, Byte* program) { OpenTK.Graphics.OpenGL.GL.NV.LoadProgram(target, id, len, program); }
        internal override void tkgl4LoadProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 id, Int32 len, Byte[] program) { OpenTK.Graphics.OpenGL.GL.NV.LoadProgram(target, id, len, program); }
        internal override void tkgl5LoadProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 id, Int32 len, ref Byte program) { OpenTK.Graphics.OpenGL.GL.NV.LoadProgram(target, id, len, ref program); }
        internal override unsafe void tkgl6LoadProgram(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 id, Int32 len, Byte* program) { OpenTK.Graphics.OpenGL.GL.NV.LoadProgram(target, id, len, program); }
        internal override void tkglMapControlPoints(OpenTK.Graphics.OpenGL.NvEvaluators target, Int32 index, OpenTK.Graphics.OpenGL.NvEvaluators type, Int32 ustride, Int32 vstride, Int32 uorder, Int32 vorder, bool packed, IntPtr points) { OpenTK.Graphics.OpenGL.GL.NV.MapControlPoints(target, index, type, ustride, vstride, uorder, vorder, packed, points); }
        internal override void tkgl2MapControlPoints(OpenTK.Graphics.OpenGL.NvEvaluators target, UInt32 index, OpenTK.Graphics.OpenGL.NvEvaluators type, Int32 ustride, Int32 vstride, Int32 uorder, Int32 vorder, bool packed, IntPtr points) { OpenTK.Graphics.OpenGL.GL.NV.MapControlPoints(target, index, type, ustride, vstride, uorder, vorder, packed, points); }
        internal override void tkglMapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.MapParameter(target, pname, @params); }
        internal override void tkgl2MapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, ref Single @params) { OpenTK.Graphics.OpenGL.GL.NV.MapParameter(target, pname, ref @params); }
        internal override unsafe void tkgl3MapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.MapParameter(target, pname, @params); }
        internal override void tkgl4MapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.MapParameter(target, pname, @params); }
        internal override void tkgl5MapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.MapParameter(target, pname, ref @params); }
        internal override unsafe void tkgl6MapParameter(OpenTK.Graphics.OpenGL.NvEvaluators target, OpenTK.Graphics.OpenGL.NvEvaluators pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.MapParameter(target, pname, @params); }
        internal override void tkglMultiTexCoord1h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half s) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord1h(target, s); }
        internal override unsafe void tkgl2MultiTexCoord1h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord1h(target, v); }
        internal override void tkglMultiTexCoord2h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half s, OpenTK.Half t) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord2h(target, s, t); }
        internal override void tkgl2MultiTexCoord2h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord2h(target, v); }
        internal override void tkgl3MultiTexCoord2h(OpenTK.Graphics.OpenGL.TextureUnit target, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord2h(target, ref v); }
        internal override unsafe void tkgl4MultiTexCoord2h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord2h(target, v); }
        internal override void tkglMultiTexCoord3h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half s, OpenTK.Half t, OpenTK.Half r) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord3h(target, s, t, r); }
        internal override void tkgl2MultiTexCoord3h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord3h(target, v); }
        internal override void tkgl3MultiTexCoord3h(OpenTK.Graphics.OpenGL.TextureUnit target, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord3h(target, ref v); }
        internal override unsafe void tkgl4MultiTexCoord3h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord3h(target, v); }
        internal override void tkglMultiTexCoord4h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half s, OpenTK.Half t, OpenTK.Half r, OpenTK.Half q) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord4h(target, s, t, r, q); }
        internal override void tkgl2MultiTexCoord4h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord4h(target, v); }
        internal override void tkgl3MultiTexCoord4h(OpenTK.Graphics.OpenGL.TextureUnit target, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord4h(target, ref v); }
        internal override unsafe void tkgl4MultiTexCoord4h(OpenTK.Graphics.OpenGL.TextureUnit target, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.MultiTexCoord4h(target, v); }
        internal override void tkglNormal3h(OpenTK.Half nx, OpenTK.Half ny, OpenTK.Half nz) { OpenTK.Graphics.OpenGL.GL.NV.Normal3h(nx, ny, nz); }
        internal override void tkgl2Normal3h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.Normal3h(v); }
        internal override void tkgl3Normal3h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.Normal3h(ref v); }
        internal override unsafe void tkgl4Normal3h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.Normal3h(v); }
        internal override void tkglPauseTransformFeedback() { OpenTK.Graphics.OpenGL.GL.NV.PauseTransformFeedback(); }
        internal override void tkglPixelDataRange(OpenTK.Graphics.OpenGL.NvPixelDataRange target, Int32 length, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.NV.PixelDataRange(target, length, pointer); }
        internal override void tkgl13PointParameter(OpenTK.Graphics.OpenGL.NvPointSprite pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.NV.PointParameter(pname, param); }
        internal override void tkgl14PointParameter(OpenTK.Graphics.OpenGL.NvPointSprite pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.PointParameter(pname, @params); }
        internal override unsafe void tkgl15PointParameter(OpenTK.Graphics.OpenGL.NvPointSprite pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.PointParameter(pname, @params); }
        internal override void tkglPresentFrameDualFill(Int32 video_slot, Int64 minPresentTime, Int32 beginPresentTimeId, Int32 presentDurationId, OpenTK.Graphics.OpenGL.NvPresentVideo type, OpenTK.Graphics.OpenGL.NvPresentVideo target0, Int32 fill0, OpenTK.Graphics.OpenGL.NvPresentVideo target1, Int32 fill1, OpenTK.Graphics.OpenGL.NvPresentVideo target2, Int32 fill2, OpenTK.Graphics.OpenGL.NvPresentVideo target3, Int32 fill3) { OpenTK.Graphics.OpenGL.GL.NV.PresentFrameDualFill(video_slot, minPresentTime, beginPresentTimeId, presentDurationId, type, target0, fill0, target1, fill1, target2, fill2, target3, fill3); }
        internal override void tkgl2PresentFrameDualFill(UInt32 video_slot, UInt64 minPresentTime, UInt32 beginPresentTimeId, UInt32 presentDurationId, OpenTK.Graphics.OpenGL.NvPresentVideo type, OpenTK.Graphics.OpenGL.NvPresentVideo target0, UInt32 fill0, OpenTK.Graphics.OpenGL.NvPresentVideo target1, UInt32 fill1, OpenTK.Graphics.OpenGL.NvPresentVideo target2, UInt32 fill2, OpenTK.Graphics.OpenGL.NvPresentVideo target3, UInt32 fill3) { OpenTK.Graphics.OpenGL.GL.NV.PresentFrameDualFill(video_slot, minPresentTime, beginPresentTimeId, presentDurationId, type, target0, fill0, target1, fill1, target2, fill2, target3, fill3); }
        internal override void tkglPresentFrameKeye(Int32 video_slot, Int64 minPresentTime, Int32 beginPresentTimeId, Int32 presentDurationId, OpenTK.Graphics.OpenGL.NvPresentVideo type, OpenTK.Graphics.OpenGL.NvPresentVideo target0, Int32 fill0, Int32 key0, OpenTK.Graphics.OpenGL.NvPresentVideo target1, Int32 fill1, Int32 key1) { OpenTK.Graphics.OpenGL.GL.NV.PresentFrameKeye(video_slot, minPresentTime, beginPresentTimeId, presentDurationId, type, target0, fill0, key0, target1, fill1, key1); }
        internal override void tkgl2PresentFrameKeye(UInt32 video_slot, UInt64 minPresentTime, UInt32 beginPresentTimeId, UInt32 presentDurationId, OpenTK.Graphics.OpenGL.NvPresentVideo type, OpenTK.Graphics.OpenGL.NvPresentVideo target0, UInt32 fill0, UInt32 key0, OpenTK.Graphics.OpenGL.NvPresentVideo target1, UInt32 fill1, UInt32 key1) { OpenTK.Graphics.OpenGL.GL.NV.PresentFrameKeye(video_slot, minPresentTime, beginPresentTimeId, presentDurationId, type, target0, fill0, key0, target1, fill1, key1); }
        internal override void tkgl3PrimitiveRestartIndex(Int32 index) { OpenTK.Graphics.OpenGL.GL.NV.PrimitiveRestartIndex(index); }
        internal override void tkgl4PrimitiveRestartIndex(UInt32 index) { OpenTK.Graphics.OpenGL.GL.NV.PrimitiveRestartIndex(index); }
        internal override void tkglPrimitiveRestart() { OpenTK.Graphics.OpenGL.GL.NV.PrimitiveRestart(); }
        internal override void tkglProgramBufferParameters(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, Int32 buffer, Int32 index, Int32 count, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParameters(target, buffer, index, count, @params); }
        internal override void tkgl2ProgramBufferParameters(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, Int32 buffer, Int32 index, Int32 count, ref Single @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParameters(target, buffer, index, count, ref @params); }
        internal override unsafe void tkgl3ProgramBufferParameters(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, Int32 buffer, Int32 index, Int32 count, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParameters(target, buffer, index, count, @params); }
        internal override void tkgl4ProgramBufferParameters(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, Single[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParameters(target, buffer, index, count, @params); }
        internal override void tkgl5ProgramBufferParameters(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, ref Single @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParameters(target, buffer, index, count, ref @params); }
        internal override unsafe void tkgl6ProgramBufferParameters(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, Single* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParameters(target, buffer, index, count, @params); }
        internal override void tkglProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, Int32 buffer, Int32 index, Int32 count, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, @params); }
        internal override void tkgl2ProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, Int32 buffer, Int32 index, Int32 count, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, ref @params); }
        internal override unsafe void tkgl3ProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, Int32 buffer, Int32 index, Int32 count, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, @params); }
        internal override void tkgl4ProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, @params); }
        internal override void tkgl5ProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, ref @params); }
        internal override unsafe void tkgl6ProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, @params); }
        internal override void tkgl7ProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, @params); }
        internal override void tkgl8ProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, ref @params); }
        internal override unsafe void tkgl9ProgramBufferParametersI(OpenTK.Graphics.OpenGL.NvParameterBufferObject target, UInt32 buffer, UInt32 index, Int32 count, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramBufferParametersI(target, buffer, index, count, @params); }
        internal override void tkglProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, x, y, z, w); }
        internal override void tkgl2ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, x, y, z, w); }
        internal override void tkgl3ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, @params); }
        internal override void tkgl4ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, ref @params); }
        internal override unsafe void tkgl5ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, @params); }
        internal override void tkgl6ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, @params); }
        internal override void tkgl7ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, ref @params); }
        internal override unsafe void tkgl8ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, @params); }
        internal override void tkgl9ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32 x, UInt32 y, UInt32 z, UInt32 w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, x, y, z, w); }
        internal override void tkgl10ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, @params); }
        internal override void tkgl11ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, ref @params); }
        internal override unsafe void tkgl12ProgramEnvParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParameterI4(target, index, @params); }
        internal override void tkglProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32 count, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, @params); }
        internal override void tkgl2ProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32 count, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, ref @params); }
        internal override unsafe void tkgl3ProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32 count, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, @params); }
        internal override void tkgl4ProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, @params); }
        internal override void tkgl5ProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, ref @params); }
        internal override unsafe void tkgl6ProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, @params); }
        internal override void tkgl7ProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, @params); }
        internal override void tkgl8ProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, ref @params); }
        internal override unsafe void tkgl9ProgramEnvParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramEnvParametersI4(target, index, count, @params); }
        internal override void tkglProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, x, y, z, w); }
        internal override void tkgl2ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 x, Int32 y, Int32 z, Int32 w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, x, y, z, w); }
        internal override void tkgl3ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, @params); }
        internal override void tkgl4ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, ref @params); }
        internal override unsafe void tkgl5ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, @params); }
        internal override void tkgl6ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, @params); }
        internal override void tkgl7ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, ref @params); }
        internal override unsafe void tkgl8ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, @params); }
        internal override void tkgl9ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32 x, UInt32 y, UInt32 z, UInt32 w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, x, y, z, w); }
        internal override void tkgl10ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, @params); }
        internal override void tkgl11ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, ref @params); }
        internal override unsafe void tkgl12ProgramLocalParameterI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParameterI4(target, index, @params); }
        internal override void tkglProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32 count, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, @params); }
        internal override void tkgl2ProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32 count, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, ref @params); }
        internal override unsafe void tkgl3ProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, Int32 index, Int32 count, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, @params); }
        internal override void tkgl4ProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, @params); }
        internal override void tkgl5ProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, ref @params); }
        internal override unsafe void tkgl6ProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, Int32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, @params); }
        internal override void tkgl7ProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, UInt32[] @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, @params); }
        internal override void tkgl8ProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, ref UInt32 @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, ref @params); }
        internal override unsafe void tkgl9ProgramLocalParametersI4(OpenTK.Graphics.OpenGL.NvGpuProgram4 target, UInt32 index, Int32 count, UInt32* @params) { OpenTK.Graphics.OpenGL.GL.NV.ProgramLocalParametersI4(target, index, count, @params); }
        internal override void tkglProgramNamedParameter4(Int32 id, Int32 len, ref Byte name, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, ref name, x, y, z, w); }
        internal override unsafe void tkgl2ProgramNamedParameter4(Int32 id, Int32 len, Byte* name, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, x, y, z, w); }
        internal override void tkgl3ProgramNamedParameter4(UInt32 id, Int32 len, ref Byte name, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, ref name, x, y, z, w); }
        internal override unsafe void tkgl4ProgramNamedParameter4(UInt32 id, Int32 len, Byte* name, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, x, y, z, w); }
        internal override void tkgl5ProgramNamedParameter4(Int32 id, Int32 len, ref Byte name, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, ref name, ref v); }
        internal override unsafe void tkgl6ProgramNamedParameter4(Int32 id, Int32 len, Byte* name, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, v); }
        internal override unsafe void tkgl7ProgramNamedParameter4(Int32 id, Int32 len, Byte* name, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, v); }
        internal override void tkgl8ProgramNamedParameter4(UInt32 id, Int32 len, ref Byte name, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, ref name, ref v); }
        internal override unsafe void tkgl9ProgramNamedParameter4(UInt32 id, Int32 len, Byte* name, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, v); }
        internal override unsafe void tkgl10ProgramNamedParameter4(UInt32 id, Int32 len, Byte* name, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, v); }
        internal override void tkgl11ProgramNamedParameter4(Int32 id, Int32 len, ref Byte name, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, ref name, x, y, z, w); }
        internal override unsafe void tkgl12ProgramNamedParameter4(Int32 id, Int32 len, Byte* name, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, x, y, z, w); }
        internal override void tkgl13ProgramNamedParameter4(UInt32 id, Int32 len, ref Byte name, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, ref name, x, y, z, w); }
        internal override unsafe void tkgl14ProgramNamedParameter4(UInt32 id, Int32 len, Byte* name, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, x, y, z, w); }
        internal override void tkgl15ProgramNamedParameter4(Int32 id, Int32 len, ref Byte name, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, ref name, ref v); }
        internal override unsafe void tkgl16ProgramNamedParameter4(Int32 id, Int32 len, Byte* name, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, v); }
        internal override unsafe void tkgl17ProgramNamedParameter4(Int32 id, Int32 len, Byte* name, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, v); }
        internal override void tkgl18ProgramNamedParameter4(UInt32 id, Int32 len, ref Byte name, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, ref name, ref v); }
        internal override unsafe void tkgl19ProgramNamedParameter4(UInt32 id, Int32 len, Byte* name, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, v); }
        internal override unsafe void tkgl20ProgramNamedParameter4(UInt32 id, Int32 len, Byte* name, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramNamedParameter4(id, len, name, v); }
        internal override void tkglProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, x, y, z, w); }
        internal override void tkgl2ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, x, y, z, w); }
        internal override void tkgl3ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, v); }
        internal override void tkgl4ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, ref v); }
        internal override unsafe void tkgl5ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, v); }
        internal override void tkgl6ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, v); }
        internal override void tkgl7ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, ref v); }
        internal override unsafe void tkgl8ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, v); }
        internal override void tkgl9ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, x, y, z, w); }
        internal override void tkgl10ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, x, y, z, w); }
        internal override void tkgl11ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, v); }
        internal override void tkgl12ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, ref v); }
        internal override unsafe void tkgl13ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, v); }
        internal override void tkgl14ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, v); }
        internal override void tkgl15ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, ref v); }
        internal override unsafe void tkgl16ProgramParameter4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameter4(target, index, v); }
        internal override void tkglProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, v); }
        internal override void tkgl2ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, ref v); }
        internal override unsafe void tkgl3ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, v); }
        internal override void tkgl4ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, UInt32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, v); }
        internal override void tkgl5ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, UInt32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, ref v); }
        internal override unsafe void tkgl6ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, UInt32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, v); }
        internal override void tkgl7ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, v); }
        internal override void tkgl8ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, ref v); }
        internal override unsafe void tkgl9ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, v); }
        internal override void tkgl10ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, UInt32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, v); }
        internal override void tkgl11ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, UInt32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, ref v); }
        internal override unsafe void tkgl12ProgramParameters4(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 index, UInt32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.ProgramParameters4(target, index, count, v); }
        internal override void tkglProgramVertexLimit(OpenTK.Graphics.OpenGL.NvGeometryProgram4 target, Int32 limit) { OpenTK.Graphics.OpenGL.GL.NV.ProgramVertexLimit(target, limit); }
        internal override void tkglRenderbufferStorageMultisampleCoverage(OpenTK.Graphics.OpenGL.RenderbufferTarget target, Int32 coverageSamples, Int32 colorSamples, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height) { OpenTK.Graphics.OpenGL.GL.NV.RenderbufferStorageMultisampleCoverage(target, coverageSamples, colorSamples, internalformat, width, height); }
        internal override void tkglRequestResidentProgram(Int32 n, Int32[] programs) { OpenTK.Graphics.OpenGL.GL.NV.RequestResidentProgram(n, programs); }
        internal override void tkgl2RequestResidentProgram(Int32 n, ref Int32 programs) { OpenTK.Graphics.OpenGL.GL.NV.RequestResidentProgram(n, ref programs); }
        internal override unsafe void tkgl3RequestResidentProgram(Int32 n, Int32* programs) { OpenTK.Graphics.OpenGL.GL.NV.RequestResidentProgram(n, programs); }
        internal override void tkgl4RequestResidentProgram(Int32 n, UInt32[] programs) { OpenTK.Graphics.OpenGL.GL.NV.RequestResidentProgram(n, programs); }
        internal override void tkgl5RequestResidentProgram(Int32 n, ref UInt32 programs) { OpenTK.Graphics.OpenGL.GL.NV.RequestResidentProgram(n, ref programs); }
        internal override unsafe void tkgl6RequestResidentProgram(Int32 n, UInt32* programs) { OpenTK.Graphics.OpenGL.GL.NV.RequestResidentProgram(n, programs); }
        internal override void tkglResumeTransformFeedback() { OpenTK.Graphics.OpenGL.GL.NV.ResumeTransformFeedback(); }
        internal override void tkglSampleMaskIndexed(Int32 index, Int32 mask) { OpenTK.Graphics.OpenGL.GL.NV.SampleMaskIndexed(index, mask); }
        internal override void tkgl2SampleMaskIndexed(UInt32 index, UInt32 mask) { OpenTK.Graphics.OpenGL.GL.NV.SampleMaskIndexed(index, mask); }
        internal override void tkglSecondaryColor3h(OpenTK.Half red, OpenTK.Half green, OpenTK.Half blue) { OpenTK.Graphics.OpenGL.GL.NV.SecondaryColor3h(red, green, blue); }
        internal override void tkgl2SecondaryColor3h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.SecondaryColor3h(v); }
        internal override void tkgl3SecondaryColor3h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.SecondaryColor3h(ref v); }
        internal override unsafe void tkgl4SecondaryColor3h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.SecondaryColor3h(v); }
        internal override void tkgl3SetFence(Int32 fence, OpenTK.Graphics.OpenGL.NvFence condition) { OpenTK.Graphics.OpenGL.GL.NV.SetFence(fence, condition); }
        internal override void tkgl4SetFence(UInt32 fence, OpenTK.Graphics.OpenGL.NvFence condition) { OpenTK.Graphics.OpenGL.GL.NV.SetFence(fence, condition); }
        internal override bool tkgl3TestFence(Int32 fence) { return OpenTK.Graphics.OpenGL.GL.NV.TestFence(fence); }
        internal override bool tkgl4TestFence(UInt32 fence) { return OpenTK.Graphics.OpenGL.GL.NV.TestFence(fence); }
        internal override void tkglTexCoord1h(OpenTK.Half s) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord1h(s); }
        internal override unsafe void tkgl2TexCoord1h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord1h(v); }
        internal override void tkglTexCoord2h(OpenTK.Half s, OpenTK.Half t) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord2h(s, t); }
        internal override void tkgl2TexCoord2h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord2h(v); }
        internal override void tkgl3TexCoord2h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord2h(ref v); }
        internal override unsafe void tkgl4TexCoord2h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord2h(v); }
        internal override void tkglTexCoord3h(OpenTK.Half s, OpenTK.Half t, OpenTK.Half r) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord3h(s, t, r); }
        internal override void tkgl2TexCoord3h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord3h(v); }
        internal override void tkgl3TexCoord3h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord3h(ref v); }
        internal override unsafe void tkgl4TexCoord3h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord3h(v); }
        internal override void tkglTexCoord4h(OpenTK.Half s, OpenTK.Half t, OpenTK.Half r, OpenTK.Half q) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord4h(s, t, r, q); }
        internal override void tkgl2TexCoord4h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord4h(v); }
        internal override void tkgl3TexCoord4h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord4h(ref v); }
        internal override unsafe void tkgl4TexCoord4h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.TexCoord4h(v); }
        internal override void tkglTexRenderbuffer(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.NV.TexRenderbuffer(target, renderbuffer); }
        internal override void tkgl2TexRenderbuffer(OpenTK.Graphics.OpenGL.TextureTarget target, UInt32 renderbuffer) { OpenTK.Graphics.OpenGL.GL.NV.TexRenderbuffer(target, renderbuffer); }
        internal override void tkglTrackMatrix(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, Int32 address, OpenTK.Graphics.OpenGL.NvVertexProgram matrix, OpenTK.Graphics.OpenGL.NvVertexProgram transform) { OpenTK.Graphics.OpenGL.GL.NV.TrackMatrix(target, address, matrix, transform); }
        internal override void tkgl2TrackMatrix(OpenTK.Graphics.OpenGL.AssemblyProgramTargetArb target, UInt32 address, OpenTK.Graphics.OpenGL.NvVertexProgram matrix, OpenTK.Graphics.OpenGL.NvVertexProgram transform) { OpenTK.Graphics.OpenGL.GL.NV.TrackMatrix(target, address, matrix, transform); }
        internal override void tkglTransformFeedbackAttrib(Int32 count, Int32[] attribs, OpenTK.Graphics.OpenGL.NvTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.NV.TransformFeedbackAttrib(count, attribs, bufferMode); }
        internal override void tkgl2TransformFeedbackAttrib(Int32 count, ref Int32 attribs, OpenTK.Graphics.OpenGL.NvTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.NV.TransformFeedbackAttrib(count, ref attribs, bufferMode); }
        internal override unsafe void tkgl3TransformFeedbackAttrib(Int32 count, Int32* attribs, OpenTK.Graphics.OpenGL.NvTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.NV.TransformFeedbackAttrib(count, attribs, bufferMode); }
        internal override void tkgl4TransformFeedbackAttrib(UInt32 count, Int32[] attribs, OpenTK.Graphics.OpenGL.NvTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.NV.TransformFeedbackAttrib(count, attribs, bufferMode); }
        internal override void tkgl5TransformFeedbackAttrib(UInt32 count, ref Int32 attribs, OpenTK.Graphics.OpenGL.NvTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.NV.TransformFeedbackAttrib(count, ref attribs, bufferMode); }
        internal override unsafe void tkgl6TransformFeedbackAttrib(UInt32 count, Int32* attribs, OpenTK.Graphics.OpenGL.NvTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.NV.TransformFeedbackAttrib(count, attribs, bufferMode); }
        internal override void tkgl5TransformFeedbackVaryings(Int32 program, Int32 count, String[] varyings, OpenTK.Graphics.OpenGL.NvTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.NV.TransformFeedbackVaryings(program, count, varyings, bufferMode); }
        internal override void tkgl6TransformFeedbackVaryings(UInt32 program, Int32 count, String[] varyings, OpenTK.Graphics.OpenGL.NvTransformFeedback bufferMode) { OpenTK.Graphics.OpenGL.GL.NV.TransformFeedbackVaryings(program, count, varyings, bufferMode); }
        internal override void tkglVertex2h(OpenTK.Half x, OpenTK.Half y) { OpenTK.Graphics.OpenGL.GL.NV.Vertex2h(x, y); }
        internal override void tkgl2Vertex2h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex2h(v); }
        internal override void tkgl3Vertex2h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex2h(ref v); }
        internal override unsafe void tkgl4Vertex2h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex2h(v); }
        internal override void tkglVertex3h(OpenTK.Half x, OpenTK.Half y, OpenTK.Half z) { OpenTK.Graphics.OpenGL.GL.NV.Vertex3h(x, y, z); }
        internal override void tkgl2Vertex3h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex3h(v); }
        internal override void tkgl3Vertex3h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex3h(ref v); }
        internal override unsafe void tkgl4Vertex3h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex3h(v); }
        internal override void tkglVertex4h(OpenTK.Half x, OpenTK.Half y, OpenTK.Half z, OpenTK.Half w) { OpenTK.Graphics.OpenGL.GL.NV.Vertex4h(x, y, z, w); }
        internal override void tkgl2Vertex4h(OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex4h(v); }
        internal override void tkgl3Vertex4h(ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex4h(ref v); }
        internal override unsafe void tkgl4Vertex4h(OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.Vertex4h(v); }
        internal override void tkgl2VertexArrayRange(Int32 length, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.NV.VertexArrayRange(length, pointer); }
        internal override void tkgl25VertexAttrib1(Int32 index, Double x) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, x); }
        internal override void tkgl26VertexAttrib1(UInt32 index, Double x) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, x); }
        internal override unsafe void tkgl27VertexAttrib1(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, v); }
        internal override unsafe void tkgl28VertexAttrib1(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, v); }
        internal override void tkgl29VertexAttrib1(Int32 index, Single x) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, x); }
        internal override void tkgl30VertexAttrib1(UInt32 index, Single x) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, x); }
        internal override unsafe void tkgl31VertexAttrib1(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, v); }
        internal override unsafe void tkgl32VertexAttrib1(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, v); }
        internal override void tkglVertexAttrib1h(Int32 index, OpenTK.Half x) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1h(index, x); }
        internal override void tkgl2VertexAttrib1h(UInt32 index, OpenTK.Half x) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1h(index, x); }
        internal override unsafe void tkgl3VertexAttrib1h(Int32 index, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1h(index, v); }
        internal override unsafe void tkgl4VertexAttrib1h(UInt32 index, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1h(index, v); }
        internal override void tkgl33VertexAttrib1(Int32 index, Int16 x) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, x); }
        internal override void tkgl34VertexAttrib1(UInt32 index, Int16 x) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, x); }
        internal override unsafe void tkgl35VertexAttrib1(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, v); }
        internal override unsafe void tkgl36VertexAttrib1(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib1(index, v); }
        internal override void tkgl49VertexAttrib2(Int32 index, Double x, Double y) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, x, y); }
        internal override void tkgl50VertexAttrib2(UInt32 index, Double x, Double y) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, x, y); }
        internal override void tkgl51VertexAttrib2(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl52VertexAttrib2(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl53VertexAttrib2(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl54VertexAttrib2(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl55VertexAttrib2(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl56VertexAttrib2(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl57VertexAttrib2(Int32 index, Single x, Single y) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, x, y); }
        internal override void tkgl58VertexAttrib2(UInt32 index, Single x, Single y) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, x, y); }
        internal override void tkgl59VertexAttrib2(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl60VertexAttrib2(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl61VertexAttrib2(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl62VertexAttrib2(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl63VertexAttrib2(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl64VertexAttrib2(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkglVertexAttrib2h(Int32 index, OpenTK.Half x, OpenTK.Half y) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2h(index, x, y); }
        internal override void tkgl2VertexAttrib2h(UInt32 index, OpenTK.Half x, OpenTK.Half y) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2h(index, x, y); }
        internal override void tkgl3VertexAttrib2h(Int32 index, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2h(index, v); }
        internal override void tkgl4VertexAttrib2h(Int32 index, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2h(index, ref v); }
        internal override unsafe void tkgl5VertexAttrib2h(Int32 index, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2h(index, v); }
        internal override void tkgl6VertexAttrib2h(UInt32 index, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2h(index, v); }
        internal override void tkgl7VertexAttrib2h(UInt32 index, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2h(index, ref v); }
        internal override unsafe void tkgl8VertexAttrib2h(UInt32 index, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2h(index, v); }
        internal override void tkgl65VertexAttrib2(Int32 index, Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, x, y); }
        internal override void tkgl66VertexAttrib2(UInt32 index, Int16 x, Int16 y) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, x, y); }
        internal override void tkgl67VertexAttrib2(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl68VertexAttrib2(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl69VertexAttrib2(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl70VertexAttrib2(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl71VertexAttrib2(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, ref v); }
        internal override unsafe void tkgl72VertexAttrib2(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib2(index, v); }
        internal override void tkgl49VertexAttrib3(Int32 index, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, x, y, z); }
        internal override void tkgl50VertexAttrib3(UInt32 index, Double x, Double y, Double z) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, x, y, z); }
        internal override void tkgl51VertexAttrib3(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl52VertexAttrib3(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl53VertexAttrib3(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl54VertexAttrib3(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl55VertexAttrib3(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl56VertexAttrib3(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl57VertexAttrib3(Int32 index, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, x, y, z); }
        internal override void tkgl58VertexAttrib3(UInt32 index, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, x, y, z); }
        internal override void tkgl59VertexAttrib3(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl60VertexAttrib3(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl61VertexAttrib3(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl62VertexAttrib3(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl63VertexAttrib3(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl64VertexAttrib3(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkglVertexAttrib3h(Int32 index, OpenTK.Half x, OpenTK.Half y, OpenTK.Half z) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3h(index, x, y, z); }
        internal override void tkgl2VertexAttrib3h(UInt32 index, OpenTK.Half x, OpenTK.Half y, OpenTK.Half z) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3h(index, x, y, z); }
        internal override void tkgl3VertexAttrib3h(Int32 index, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3h(index, v); }
        internal override void tkgl4VertexAttrib3h(Int32 index, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3h(index, ref v); }
        internal override unsafe void tkgl5VertexAttrib3h(Int32 index, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3h(index, v); }
        internal override void tkgl6VertexAttrib3h(UInt32 index, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3h(index, v); }
        internal override void tkgl7VertexAttrib3h(UInt32 index, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3h(index, ref v); }
        internal override unsafe void tkgl8VertexAttrib3h(UInt32 index, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3h(index, v); }
        internal override void tkgl65VertexAttrib3(Int32 index, Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, x, y, z); }
        internal override void tkgl66VertexAttrib3(UInt32 index, Int16 x, Int16 y, Int16 z) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, x, y, z); }
        internal override void tkgl67VertexAttrib3(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl68VertexAttrib3(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl69VertexAttrib3(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl70VertexAttrib3(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl71VertexAttrib3(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, ref v); }
        internal override unsafe void tkgl72VertexAttrib3(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib3(index, v); }
        internal override void tkgl91VertexAttrib4(Int32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl92VertexAttrib4(UInt32 index, Double x, Double y, Double z, Double w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl93VertexAttrib4(Int32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl94VertexAttrib4(Int32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl95VertexAttrib4(Int32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl96VertexAttrib4(UInt32 index, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl97VertexAttrib4(UInt32 index, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl98VertexAttrib4(UInt32 index, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl99VertexAttrib4(Int32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl100VertexAttrib4(UInt32 index, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl101VertexAttrib4(Int32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl102VertexAttrib4(Int32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl103VertexAttrib4(Int32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl104VertexAttrib4(UInt32 index, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl105VertexAttrib4(UInt32 index, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl106VertexAttrib4(UInt32 index, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkglVertexAttrib4h(Int32 index, OpenTK.Half x, OpenTK.Half y, OpenTK.Half z, OpenTK.Half w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4h(index, x, y, z, w); }
        internal override void tkgl2VertexAttrib4h(UInt32 index, OpenTK.Half x, OpenTK.Half y, OpenTK.Half z, OpenTK.Half w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4h(index, x, y, z, w); }
        internal override void tkgl3VertexAttrib4h(Int32 index, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4h(index, v); }
        internal override void tkgl4VertexAttrib4h(Int32 index, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4h(index, ref v); }
        internal override unsafe void tkgl5VertexAttrib4h(Int32 index, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4h(index, v); }
        internal override void tkgl6VertexAttrib4h(UInt32 index, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4h(index, v); }
        internal override void tkgl7VertexAttrib4h(UInt32 index, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4h(index, ref v); }
        internal override unsafe void tkgl8VertexAttrib4h(UInt32 index, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4h(index, v); }
        internal override void tkgl107VertexAttrib4(Int32 index, Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl108VertexAttrib4(UInt32 index, Int16 x, Int16 y, Int16 z, Int16 w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl109VertexAttrib4(Int32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl110VertexAttrib4(Int32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl111VertexAttrib4(Int32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl112VertexAttrib4(UInt32 index, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl113VertexAttrib4(UInt32 index, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl114VertexAttrib4(UInt32 index, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl115VertexAttrib4(Int32 index, Byte x, Byte y, Byte z, Byte w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl116VertexAttrib4(UInt32 index, Byte x, Byte y, Byte z, Byte w) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, x, y, z, w); }
        internal override void tkgl117VertexAttrib4(Int32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl118VertexAttrib4(Int32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl119VertexAttrib4(Int32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl120VertexAttrib4(UInt32 index, Byte[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl121VertexAttrib4(UInt32 index, ref Byte v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, ref v); }
        internal override unsafe void tkgl122VertexAttrib4(UInt32 index, Byte* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttrib4(index, v); }
        internal override void tkgl5VertexAttribPointer(Int32 index, Int32 fsize, OpenTK.Graphics.OpenGL.VertexAttribParameterArb type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribPointer(index, fsize, type, stride, pointer); }
        internal override void tkgl6VertexAttribPointer(UInt32 index, Int32 fsize, OpenTK.Graphics.OpenGL.VertexAttribParameterArb type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribPointer(index, fsize, type, stride, pointer); }
        internal override void tkglVertexAttribs1(Int32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl2VertexAttribs1(Int32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, ref v); }
        internal override unsafe void tkgl3VertexAttribs1(Int32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl4VertexAttribs1(UInt32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl5VertexAttribs1(UInt32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, ref v); }
        internal override unsafe void tkgl6VertexAttribs1(UInt32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl7VertexAttribs1(Int32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl8VertexAttribs1(Int32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, ref v); }
        internal override unsafe void tkgl9VertexAttribs1(Int32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl10VertexAttribs1(UInt32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl11VertexAttribs1(UInt32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, ref v); }
        internal override unsafe void tkgl12VertexAttribs1(UInt32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkglVertexAttribs1h(Int32 index, Int32 n, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1h(index, n, v); }
        internal override void tkgl2VertexAttribs1h(Int32 index, Int32 n, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1h(index, n, ref v); }
        internal override unsafe void tkgl3VertexAttribs1h(Int32 index, Int32 n, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1h(index, n, v); }
        internal override void tkgl4VertexAttribs1h(UInt32 index, Int32 n, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1h(index, n, v); }
        internal override void tkgl5VertexAttribs1h(UInt32 index, Int32 n, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1h(index, n, ref v); }
        internal override unsafe void tkgl6VertexAttribs1h(UInt32 index, Int32 n, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1h(index, n, v); }
        internal override void tkgl13VertexAttribs1(Int32 index, Int32 count, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl14VertexAttribs1(Int32 index, Int32 count, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, ref v); }
        internal override unsafe void tkgl15VertexAttribs1(Int32 index, Int32 count, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl16VertexAttribs1(UInt32 index, Int32 count, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkgl17VertexAttribs1(UInt32 index, Int32 count, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, ref v); }
        internal override unsafe void tkgl18VertexAttribs1(UInt32 index, Int32 count, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs1(index, count, v); }
        internal override void tkglVertexAttribs2(Int32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl2VertexAttribs2(Int32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, ref v); }
        internal override unsafe void tkgl3VertexAttribs2(Int32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl4VertexAttribs2(UInt32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl5VertexAttribs2(UInt32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, ref v); }
        internal override unsafe void tkgl6VertexAttribs2(UInt32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl7VertexAttribs2(Int32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl8VertexAttribs2(Int32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, ref v); }
        internal override unsafe void tkgl9VertexAttribs2(Int32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl10VertexAttribs2(UInt32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl11VertexAttribs2(UInt32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, ref v); }
        internal override unsafe void tkgl12VertexAttribs2(UInt32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkglVertexAttribs2h(Int32 index, Int32 n, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2h(index, n, v); }
        internal override void tkgl2VertexAttribs2h(Int32 index, Int32 n, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2h(index, n, ref v); }
        internal override unsafe void tkgl3VertexAttribs2h(Int32 index, Int32 n, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2h(index, n, v); }
        internal override void tkgl4VertexAttribs2h(UInt32 index, Int32 n, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2h(index, n, v); }
        internal override void tkgl5VertexAttribs2h(UInt32 index, Int32 n, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2h(index, n, ref v); }
        internal override unsafe void tkgl6VertexAttribs2h(UInt32 index, Int32 n, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2h(index, n, v); }
        internal override void tkgl13VertexAttribs2(Int32 index, Int32 count, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl14VertexAttribs2(Int32 index, Int32 count, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, ref v); }
        internal override unsafe void tkgl15VertexAttribs2(Int32 index, Int32 count, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl16VertexAttribs2(UInt32 index, Int32 count, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkgl17VertexAttribs2(UInt32 index, Int32 count, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, ref v); }
        internal override unsafe void tkgl18VertexAttribs2(UInt32 index, Int32 count, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs2(index, count, v); }
        internal override void tkglVertexAttribs3(Int32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl2VertexAttribs3(Int32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, ref v); }
        internal override unsafe void tkgl3VertexAttribs3(Int32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl4VertexAttribs3(UInt32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl5VertexAttribs3(UInt32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, ref v); }
        internal override unsafe void tkgl6VertexAttribs3(UInt32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl7VertexAttribs3(Int32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl8VertexAttribs3(Int32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, ref v); }
        internal override unsafe void tkgl9VertexAttribs3(Int32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl10VertexAttribs3(UInt32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl11VertexAttribs3(UInt32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, ref v); }
        internal override unsafe void tkgl12VertexAttribs3(UInt32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkglVertexAttribs3h(Int32 index, Int32 n, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3h(index, n, v); }
        internal override void tkgl2VertexAttribs3h(Int32 index, Int32 n, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3h(index, n, ref v); }
        internal override unsafe void tkgl3VertexAttribs3h(Int32 index, Int32 n, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3h(index, n, v); }
        internal override void tkgl4VertexAttribs3h(UInt32 index, Int32 n, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3h(index, n, v); }
        internal override void tkgl5VertexAttribs3h(UInt32 index, Int32 n, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3h(index, n, ref v); }
        internal override unsafe void tkgl6VertexAttribs3h(UInt32 index, Int32 n, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3h(index, n, v); }
        internal override void tkgl13VertexAttribs3(Int32 index, Int32 count, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl14VertexAttribs3(Int32 index, Int32 count, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, ref v); }
        internal override unsafe void tkgl15VertexAttribs3(Int32 index, Int32 count, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl16VertexAttribs3(UInt32 index, Int32 count, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkgl17VertexAttribs3(UInt32 index, Int32 count, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, ref v); }
        internal override unsafe void tkgl18VertexAttribs3(UInt32 index, Int32 count, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs3(index, count, v); }
        internal override void tkglVertexAttribs4(Int32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl2VertexAttribs4(Int32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, ref v); }
        internal override unsafe void tkgl3VertexAttribs4(Int32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl4VertexAttribs4(UInt32 index, Int32 count, Double[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl5VertexAttribs4(UInt32 index, Int32 count, ref Double v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, ref v); }
        internal override unsafe void tkgl6VertexAttribs4(UInt32 index, Int32 count, Double* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl7VertexAttribs4(Int32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl8VertexAttribs4(Int32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, ref v); }
        internal override unsafe void tkgl9VertexAttribs4(Int32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl10VertexAttribs4(UInt32 index, Int32 count, Single[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl11VertexAttribs4(UInt32 index, Int32 count, ref Single v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, ref v); }
        internal override unsafe void tkgl12VertexAttribs4(UInt32 index, Int32 count, Single* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkglVertexAttribs4h(Int32 index, Int32 n, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4h(index, n, v); }
        internal override void tkgl2VertexAttribs4h(Int32 index, Int32 n, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4h(index, n, ref v); }
        internal override unsafe void tkgl3VertexAttribs4h(Int32 index, Int32 n, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4h(index, n, v); }
        internal override void tkgl4VertexAttribs4h(UInt32 index, Int32 n, OpenTK.Half[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4h(index, n, v); }
        internal override void tkgl5VertexAttribs4h(UInt32 index, Int32 n, ref OpenTK.Half v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4h(index, n, ref v); }
        internal override unsafe void tkgl6VertexAttribs4h(UInt32 index, Int32 n, OpenTK.Half* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4h(index, n, v); }
        internal override void tkgl13VertexAttribs4(Int32 index, Int32 count, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl14VertexAttribs4(Int32 index, Int32 count, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, ref v); }
        internal override unsafe void tkgl15VertexAttribs4(Int32 index, Int32 count, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl16VertexAttribs4(UInt32 index, Int32 count, Int16[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl17VertexAttribs4(UInt32 index, Int32 count, ref Int16 v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, ref v); }
        internal override unsafe void tkgl18VertexAttribs4(UInt32 index, Int32 count, Int16* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl19VertexAttribs4(Int32 index, Int32 count, Byte[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl20VertexAttribs4(Int32 index, Int32 count, ref Byte v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, ref v); }
        internal override unsafe void tkgl21VertexAttribs4(Int32 index, Int32 count, Byte* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl22VertexAttribs4(UInt32 index, Int32 count, Byte[] v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkgl23VertexAttribs4(UInt32 index, Int32 count, ref Byte v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, ref v); }
        internal override unsafe void tkgl24VertexAttribs4(UInt32 index, Int32 count, Byte* v) { OpenTK.Graphics.OpenGL.GL.NV.VertexAttribs4(index, count, v); }
        internal override void tkglVertexWeighth(OpenTK.Half weight) { OpenTK.Graphics.OpenGL.GL.NV.VertexWeighth(weight); }
        internal override unsafe void tkgl2VertexWeighth(OpenTK.Half* weight) { OpenTK.Graphics.OpenGL.GL.NV.VertexWeighth(weight); }
        internal override void tkgl2Hint(OpenTK.Graphics.OpenGL.PgiMiscHints target, Int32 mode) { OpenTK.Graphics.OpenGL.GL.Pgi.Hint(target, mode); }
        internal override void tkgl7ColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgi.ColorTableParameter(target, pname, @params); }
        internal override void tkgl8ColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, ref Single @params) { OpenTK.Graphics.OpenGL.GL.Sgi.ColorTableParameter(target, pname, ref @params); }
        internal override unsafe void tkgl9ColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgi.ColorTableParameter(target, pname, @params); }
        internal override void tkgl10ColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgi.ColorTableParameter(target, pname, @params); }
        internal override void tkgl11ColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, ref Int32 @params) { OpenTK.Graphics.OpenGL.GL.Sgi.ColorTableParameter(target, pname, ref @params); }
        internal override unsafe void tkgl12ColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgi.ColorTableParameter(target, pname, @params); }
        internal override void tkgl3ColorTable(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr table) { OpenTK.Graphics.OpenGL.GL.Sgi.ColorTable(target, internalformat, width, format, type, table); }
        internal override void tkgl2CopyColorTable(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 x, Int32 y, Int32 width) { OpenTK.Graphics.OpenGL.GL.Sgi.CopyColorTable(target, internalformat, x, y, width); }
        internal override void tkgl13GetColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgi.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl14GetColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Sgi.GetColorTableParameter(target, pname, out @params); }
        internal override unsafe void tkgl15GetColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgi.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl16GetColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgi.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl17GetColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Sgi.GetColorTableParameter(target, pname, out @params); }
        internal override unsafe void tkgl18GetColorTableParameter(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.SgiColorTable pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgi.GetColorTableParameter(target, pname, @params); }
        internal override void tkgl3GetColorTable(OpenTK.Graphics.OpenGL.SgiColorTable target, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr table) { OpenTK.Graphics.OpenGL.GL.Sgi.GetColorTable(target, format, type, table); }
        internal override void tkglDetailTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 n, Single[] points) { OpenTK.Graphics.OpenGL.GL.Sgis.DetailTexFunc(target, n, points); }
        internal override void tkgl2DetailTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 n, ref Single points) { OpenTK.Graphics.OpenGL.GL.Sgis.DetailTexFunc(target, n, ref points); }
        internal override unsafe void tkgl3DetailTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 n, Single* points) { OpenTK.Graphics.OpenGL.GL.Sgis.DetailTexFunc(target, n, points); }
        internal override void tkglFogFunc(Int32 n, Single[] points) { OpenTK.Graphics.OpenGL.GL.Sgis.FogFunc(n, points); }
        internal override void tkgl2FogFunc(Int32 n, ref Single points) { OpenTK.Graphics.OpenGL.GL.Sgis.FogFunc(n, ref points); }
        internal override unsafe void tkgl3FogFunc(Int32 n, Single* points) { OpenTK.Graphics.OpenGL.GL.Sgis.FogFunc(n, points); }
        internal override void tkglGetDetailTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Single[] points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetDetailTexFunc(target, points); }
        internal override void tkgl2GetDetailTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, out Single points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetDetailTexFunc(target, out points); }
        internal override unsafe void tkgl3GetDetailTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Single* points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetDetailTexFunc(target, points); }
        internal override void tkglGetFogFunc(Single[] points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetFogFunc(points); }
        internal override void tkgl2GetFogFunc(out Single points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetFogFunc(out points); }
        internal override unsafe void tkgl3GetFogFunc(Single* points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetFogFunc(points); }
        internal override void tkglGetPixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgis.GetPixelTexGenParameter(pname, @params); }
        internal override void tkgl2GetPixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Sgis.GetPixelTexGenParameter(pname, out @params); }
        internal override unsafe void tkgl3GetPixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgis.GetPixelTexGenParameter(pname, @params); }
        internal override void tkgl4GetPixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgis.GetPixelTexGenParameter(pname, @params); }
        internal override void tkgl5GetPixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Sgis.GetPixelTexGenParameter(pname, out @params); }
        internal override unsafe void tkgl6GetPixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgis.GetPixelTexGenParameter(pname, @params); }
        internal override void tkglGetSharpenTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Single[] points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetSharpenTexFunc(target, points); }
        internal override void tkgl2GetSharpenTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, out Single points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetSharpenTexFunc(target, out points); }
        internal override unsafe void tkgl3GetSharpenTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Single* points) { OpenTK.Graphics.OpenGL.GL.Sgis.GetSharpenTexFunc(target, points); }
        internal override void tkglGetTexFilterFunc(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.SgisTextureFilter4 filter, Single[] weights) { OpenTK.Graphics.OpenGL.GL.Sgis.GetTexFilterFunc(target, filter, weights); }
        internal override void tkgl2GetTexFilterFunc(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.SgisTextureFilter4 filter, out Single weights) { OpenTK.Graphics.OpenGL.GL.Sgis.GetTexFilterFunc(target, filter, out weights); }
        internal override unsafe void tkgl3GetTexFilterFunc(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.SgisTextureFilter4 filter, Single* weights) { OpenTK.Graphics.OpenGL.GL.Sgis.GetTexFilterFunc(target, filter, weights); }
        internal override void tkglPixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Single param) { OpenTK.Graphics.OpenGL.GL.Sgis.PixelTexGenParameter(pname, param); }
        internal override void tkgl2PixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgis.PixelTexGenParameter(pname, @params); }
        internal override unsafe void tkgl3PixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgis.PixelTexGenParameter(pname, @params); }
        internal override void tkgl4PixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Sgis.PixelTexGenParameter(pname, param); }
        internal override void tkgl5PixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgis.PixelTexGenParameter(pname, @params); }
        internal override unsafe void tkgl6PixelTexGenParameter(OpenTK.Graphics.OpenGL.SgisPixelTexture pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgis.PixelTexGenParameter(pname, @params); }
        internal override void tkgl16PointParameter(OpenTK.Graphics.OpenGL.SgisPointParameters pname, Single param) { OpenTK.Graphics.OpenGL.GL.Sgis.PointParameter(pname, param); }
        internal override void tkgl17PointParameter(OpenTK.Graphics.OpenGL.SgisPointParameters pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgis.PointParameter(pname, @params); }
        internal override unsafe void tkgl18PointParameter(OpenTK.Graphics.OpenGL.SgisPointParameters pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgis.PointParameter(pname, @params); }
        internal override void tkgl4SampleMask(Single value, bool invert) { OpenTK.Graphics.OpenGL.GL.Sgis.SampleMask(value, invert); }
        internal override void tkgl2SamplePattern(OpenTK.Graphics.OpenGL.SgisMultisample pattern) { OpenTK.Graphics.OpenGL.GL.Sgis.SamplePattern(pattern); }
        internal override void tkglSharpenTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 n, Single[] points) { OpenTK.Graphics.OpenGL.GL.Sgis.SharpenTexFunc(target, n, points); }
        internal override void tkgl2SharpenTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 n, ref Single points) { OpenTK.Graphics.OpenGL.GL.Sgis.SharpenTexFunc(target, n, ref points); }
        internal override unsafe void tkgl3SharpenTexFunc(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 n, Single* points) { OpenTK.Graphics.OpenGL.GL.Sgis.SharpenTexFunc(target, n, points); }
        internal override void tkglTexFilterFunc(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.SgisTextureFilter4 filter, Int32 n, Single[] weights) { OpenTK.Graphics.OpenGL.GL.Sgis.TexFilterFunc(target, filter, n, weights); }
        internal override void tkgl2TexFilterFunc(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.SgisTextureFilter4 filter, Int32 n, ref Single weights) { OpenTK.Graphics.OpenGL.GL.Sgis.TexFilterFunc(target, filter, n, ref weights); }
        internal override unsafe void tkgl3TexFilterFunc(OpenTK.Graphics.OpenGL.TextureTarget target, OpenTK.Graphics.OpenGL.SgisTextureFilter4 filter, Int32 n, Single* weights) { OpenTK.Graphics.OpenGL.GL.Sgis.TexFilterFunc(target, filter, n, weights); }
        internal override void tkglTexImage4D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, OpenTK.Graphics.OpenGL.PixelInternalFormat internalformat, Int32 width, Int32 height, Int32 depth, Int32 size4d, Int32 border, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Sgis.TexImage4D(target, level, internalformat, width, height, depth, size4d, border, format, type, pixels); }
        internal override void tkglTexSubImage4D(OpenTK.Graphics.OpenGL.TextureTarget target, Int32 level, Int32 xoffset, Int32 yoffset, Int32 zoffset, Int32 woffset, Int32 width, Int32 height, Int32 depth, Int32 size4d, OpenTK.Graphics.OpenGL.PixelFormat format, OpenTK.Graphics.OpenGL.PixelType type, IntPtr pixels) { OpenTK.Graphics.OpenGL.GL.Sgis.TexSubImage4D(target, level, xoffset, yoffset, zoffset, woffset, width, height, depth, size4d, format, type, pixels); }
        internal override void tkglTextureColorMask(bool red, bool green, bool blue, bool alpha) { OpenTK.Graphics.OpenGL.GL.Sgis.TextureColorMask(red, green, blue, alpha); }
        internal override void tkglAsyncMarker(Int32 marker) { OpenTK.Graphics.OpenGL.GL.Sgix.AsyncMarker(marker); }
        internal override void tkgl2AsyncMarker(UInt32 marker) { OpenTK.Graphics.OpenGL.GL.Sgix.AsyncMarker(marker); }
        internal override void tkglDeformationMap3(OpenTK.Graphics.OpenGL.SgixPolynomialFfd target, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double w1, Double w2, Int32 wstride, Int32 worder, Double[] points) { OpenTK.Graphics.OpenGL.GL.Sgix.DeformationMap3(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, w1, w2, wstride, worder, points); }
        internal override void tkgl2DeformationMap3(OpenTK.Graphics.OpenGL.SgixPolynomialFfd target, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double w1, Double w2, Int32 wstride, Int32 worder, ref Double points) { OpenTK.Graphics.OpenGL.GL.Sgix.DeformationMap3(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, w1, w2, wstride, worder, ref points); }
        internal override unsafe void tkgl3DeformationMap3(OpenTK.Graphics.OpenGL.SgixPolynomialFfd target, Double u1, Double u2, Int32 ustride, Int32 uorder, Double v1, Double v2, Int32 vstride, Int32 vorder, Double w1, Double w2, Int32 wstride, Int32 worder, Double* points) { OpenTK.Graphics.OpenGL.GL.Sgix.DeformationMap3(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, w1, w2, wstride, worder, points); }
        internal override void tkgl4DeformationMap3(OpenTK.Graphics.OpenGL.SgixPolynomialFfd target, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single w1, Single w2, Int32 wstride, Int32 worder, Single[] points) { OpenTK.Graphics.OpenGL.GL.Sgix.DeformationMap3(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, w1, w2, wstride, worder, points); }
        internal override void tkgl5DeformationMap3(OpenTK.Graphics.OpenGL.SgixPolynomialFfd target, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single w1, Single w2, Int32 wstride, Int32 worder, ref Single points) { OpenTK.Graphics.OpenGL.GL.Sgix.DeformationMap3(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, w1, w2, wstride, worder, ref points); }
        internal override unsafe void tkgl6DeformationMap3(OpenTK.Graphics.OpenGL.SgixPolynomialFfd target, Single u1, Single u2, Int32 ustride, Int32 uorder, Single v1, Single v2, Int32 vstride, Int32 vorder, Single w1, Single w2, Int32 wstride, Int32 worder, Single* points) { OpenTK.Graphics.OpenGL.GL.Sgix.DeformationMap3(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, w1, w2, wstride, worder, points); }
        internal override void tkglDeform(Int32 mask) { OpenTK.Graphics.OpenGL.GL.Sgix.Deform(mask); }
        internal override void tkgl2Deform(UInt32 mask) { OpenTK.Graphics.OpenGL.GL.Sgix.Deform(mask); }
        internal override void tkglDeleteAsyncMarkers(Int32 marker, Int32 range) { OpenTK.Graphics.OpenGL.GL.Sgix.DeleteAsyncMarkers(marker, range); }
        internal override void tkgl2DeleteAsyncMarkers(UInt32 marker, Int32 range) { OpenTK.Graphics.OpenGL.GL.Sgix.DeleteAsyncMarkers(marker, range); }
        internal override Int32 tkglFinishAsync(out Int32 markerp) { return OpenTK.Graphics.OpenGL.GL.Sgix.FinishAsync(out markerp); }
        internal override unsafe Int32 tkgl2FinishAsync(Int32* markerp) { return OpenTK.Graphics.OpenGL.GL.Sgix.FinishAsync(markerp); }
        internal override Int32 tkgl3FinishAsync(out UInt32 markerp) { return OpenTK.Graphics.OpenGL.GL.Sgix.FinishAsync(out markerp); }
        internal override unsafe Int32 tkgl4FinishAsync(UInt32* markerp) { return OpenTK.Graphics.OpenGL.GL.Sgix.FinishAsync(markerp); }
        internal override void tkglFlushRaster() { OpenTK.Graphics.OpenGL.GL.Sgix.FlushRaster(); }
        internal override void tkglFragmentColorMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter mode) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentColorMaterial(face, mode); }
        internal override void tkglFragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Single param) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLight(light, pname, param); }
        internal override void tkgl2FragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLight(light, pname, @params); }
        internal override unsafe void tkgl3FragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLight(light, pname, @params); }
        internal override void tkgl4FragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLight(light, pname, param); }
        internal override void tkgl5FragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLight(light, pname, @params); }
        internal override unsafe void tkgl6FragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLight(light, pname, @params); }
        internal override void tkglFragmentLightModel(OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Single param) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLightModel(pname, param); }
        internal override void tkgl2FragmentLightModel(OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLightModel(pname, @params); }
        internal override unsafe void tkgl3FragmentLightModel(OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLightModel(pname, @params); }
        internal override void tkgl4FragmentLightModel(OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLightModel(pname, param); }
        internal override void tkgl5FragmentLightModel(OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLightModel(pname, @params); }
        internal override unsafe void tkgl6FragmentLightModel(OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentLightModel(pname, @params); }
        internal override void tkglFragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single param) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentMaterial(face, pname, param); }
        internal override void tkgl2FragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentMaterial(face, pname, @params); }
        internal override unsafe void tkgl3FragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentMaterial(face, pname, @params); }
        internal override void tkgl4FragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentMaterial(face, pname, param); }
        internal override void tkgl5FragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentMaterial(face, pname, @params); }
        internal override unsafe void tkgl6FragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.FragmentMaterial(face, pname, @params); }
        internal override void tkglFrameZoom(Int32 factor) { OpenTK.Graphics.OpenGL.GL.Sgix.FrameZoom(factor); }
        internal override Int32 tkglGenAsyncMarkers(Int32 range) { return OpenTK.Graphics.OpenGL.GL.Sgix.GenAsyncMarkers(range); }
        internal override void tkglGetFragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentLight(light, pname, @params); }
        internal override void tkgl2GetFragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentLight(light, pname, out @params); }
        internal override unsafe void tkgl3GetFragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentLight(light, pname, @params); }
        internal override void tkgl4GetFragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentLight(light, pname, @params); }
        internal override void tkgl5GetFragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentLight(light, pname, out @params); }
        internal override unsafe void tkgl6GetFragmentLight(OpenTK.Graphics.OpenGL.SgixFragmentLighting light, OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentLight(light, pname, @params); }
        internal override void tkglGetFragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentMaterial(face, pname, @params); }
        internal override void tkgl2GetFragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentMaterial(face, pname, out @params); }
        internal override unsafe void tkgl3GetFragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentMaterial(face, pname, @params); }
        internal override void tkgl4GetFragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentMaterial(face, pname, @params); }
        internal override void tkgl5GetFragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentMaterial(face, pname, out @params); }
        internal override unsafe void tkgl6GetFragmentMaterial(OpenTK.Graphics.OpenGL.MaterialFace face, OpenTK.Graphics.OpenGL.MaterialParameter pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetFragmentMaterial(face, pname, @params); }
        internal override Int32 tkglGetInstruments() { return OpenTK.Graphics.OpenGL.GL.Sgix.GetInstruments(); }
        internal override void tkglGetListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, @params); }
        internal override void tkgl2GetListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, out @params); }
        internal override unsafe void tkgl3GetListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, @params); }
        internal override void tkgl4GetListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, @params); }
        internal override void tkgl5GetListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, out Single @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, out @params); }
        internal override unsafe void tkgl6GetListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, @params); }
        internal override void tkgl7GetListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, @params); }
        internal override void tkgl8GetListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, out @params); }
        internal override unsafe void tkgl9GetListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, @params); }
        internal override void tkgl10GetListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, @params); }
        internal override void tkgl11GetListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, out Int32 @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, out @params); }
        internal override unsafe void tkgl12GetListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.GetListParameter(list, pname, @params); }
        internal override void tkglIglooInterface(OpenTK.Graphics.OpenGL.All pname, IntPtr @params) { OpenTK.Graphics.OpenGL.GL.Sgix.IglooInterface(pname, @params); }
        internal override void tkglInstrumentsBuffer(Int32 size, Int32[] buffer) { OpenTK.Graphics.OpenGL.GL.Sgix.InstrumentsBuffer(size, buffer); }
        internal override void tkgl2InstrumentsBuffer(Int32 size, out Int32 buffer) { OpenTK.Graphics.OpenGL.GL.Sgix.InstrumentsBuffer(size, out buffer); }
        internal override unsafe void tkgl3InstrumentsBuffer(Int32 size, Int32* buffer) { OpenTK.Graphics.OpenGL.GL.Sgix.InstrumentsBuffer(size, buffer); }
        internal override bool tkglIsAsyncMarker(Int32 marker) { return OpenTK.Graphics.OpenGL.GL.Sgix.IsAsyncMarker(marker); }
        internal override bool tkgl2IsAsyncMarker(UInt32 marker) { return OpenTK.Graphics.OpenGL.GL.Sgix.IsAsyncMarker(marker); }
        internal override void tkglLightEnv(OpenTK.Graphics.OpenGL.SgixFragmentLighting pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Sgix.LightEnv(pname, param); }
        internal override void tkglListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single param) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, param); }
        internal override void tkgl2ListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single param) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, param); }
        internal override void tkgl3ListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, @params); }
        internal override unsafe void tkgl4ListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, @params); }
        internal override void tkgl5ListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, @params); }
        internal override unsafe void tkgl6ListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, @params); }
        internal override void tkgl7ListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, param); }
        internal override void tkgl8ListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, param); }
        internal override void tkgl9ListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, @params); }
        internal override unsafe void tkgl10ListParameter(Int32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, @params); }
        internal override void tkgl11ListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, @params); }
        internal override unsafe void tkgl12ListParameter(UInt32 list, OpenTK.Graphics.OpenGL.ListParameterName pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.ListParameter(list, pname, @params); }
        internal override void tkglLoadIdentityDeformationMap(Int32 mask) { OpenTK.Graphics.OpenGL.GL.Sgix.LoadIdentityDeformationMap(mask); }
        internal override void tkgl2LoadIdentityDeformationMap(UInt32 mask) { OpenTK.Graphics.OpenGL.GL.Sgix.LoadIdentityDeformationMap(mask); }
        internal override void tkglPixelTexGen(OpenTK.Graphics.OpenGL.SgixPixelTexture mode) { OpenTK.Graphics.OpenGL.GL.Sgix.PixelTexGen(mode); }
        internal override Int32 tkglPollAsync(out Int32 markerp) { return OpenTK.Graphics.OpenGL.GL.Sgix.PollAsync(out markerp); }
        internal override unsafe Int32 tkgl2PollAsync(Int32* markerp) { return OpenTK.Graphics.OpenGL.GL.Sgix.PollAsync(markerp); }
        internal override Int32 tkgl3PollAsync(out UInt32 markerp) { return OpenTK.Graphics.OpenGL.GL.Sgix.PollAsync(out markerp); }
        internal override unsafe Int32 tkgl4PollAsync(UInt32* markerp) { return OpenTK.Graphics.OpenGL.GL.Sgix.PollAsync(markerp); }
        internal override Int32 tkglPollInstruments(out Int32 marker_p) { return OpenTK.Graphics.OpenGL.GL.Sgix.PollInstruments(out marker_p); }
        internal override unsafe Int32 tkgl2PollInstruments(Int32* marker_p) { return OpenTK.Graphics.OpenGL.GL.Sgix.PollInstruments(marker_p); }
        internal override void tkglReadInstruments(Int32 marker) { OpenTK.Graphics.OpenGL.GL.Sgix.ReadInstruments(marker); }
        internal override void tkglReferencePlane(Double[] equation) { OpenTK.Graphics.OpenGL.GL.Sgix.ReferencePlane(equation); }
        internal override void tkgl2ReferencePlane(ref Double equation) { OpenTK.Graphics.OpenGL.GL.Sgix.ReferencePlane(ref equation); }
        internal override unsafe void tkgl3ReferencePlane(Double* equation) { OpenTK.Graphics.OpenGL.GL.Sgix.ReferencePlane(equation); }
        internal override void tkglSpriteParameter(OpenTK.Graphics.OpenGL.SgixSprite pname, Single param) { OpenTK.Graphics.OpenGL.GL.Sgix.SpriteParameter(pname, param); }
        internal override void tkgl2SpriteParameter(OpenTK.Graphics.OpenGL.SgixSprite pname, Single[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.SpriteParameter(pname, @params); }
        internal override unsafe void tkgl3SpriteParameter(OpenTK.Graphics.OpenGL.SgixSprite pname, Single* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.SpriteParameter(pname, @params); }
        internal override void tkgl4SpriteParameter(OpenTK.Graphics.OpenGL.SgixSprite pname, Int32 param) { OpenTK.Graphics.OpenGL.GL.Sgix.SpriteParameter(pname, param); }
        internal override void tkgl5SpriteParameter(OpenTK.Graphics.OpenGL.SgixSprite pname, Int32[] @params) { OpenTK.Graphics.OpenGL.GL.Sgix.SpriteParameter(pname, @params); }
        internal override unsafe void tkgl6SpriteParameter(OpenTK.Graphics.OpenGL.SgixSprite pname, Int32* @params) { OpenTK.Graphics.OpenGL.GL.Sgix.SpriteParameter(pname, @params); }
        internal override void tkglStartInstruments() { OpenTK.Graphics.OpenGL.GL.Sgix.StartInstruments(); }
        internal override void tkglStopInstruments(Int32 marker) { OpenTK.Graphics.OpenGL.GL.Sgix.StopInstruments(marker); }
        internal override void tkglTagSampleBuffer() { OpenTK.Graphics.OpenGL.GL.Sgix.TagSampleBuffer(); }
        internal override void tkglColor3fVertex3(Single r, Single g, Single b, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.Color3fVertex3(r, g, b, x, y, z); }
        internal override void tkgl2Color3fVertex3(Single[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.Color3fVertex3(c, v); }
        internal override void tkgl3Color3fVertex3(ref Single c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.Color3fVertex3(ref c, ref v); }
        internal override unsafe void tkgl4Color3fVertex3(Single* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.Color3fVertex3(c, v); }
        internal override void tkglColor4fNormal3fVertex3(Single r, Single g, Single b, Single a, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.Color4fNormal3fVertex3(r, g, b, a, nx, ny, nz, x, y, z); }
        internal override void tkgl2Color4fNormal3fVertex3(Single[] c, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4fNormal3fVertex3(c, n, v); }
        internal override void tkgl3Color4fNormal3fVertex3(ref Single c, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4fNormal3fVertex3(ref c, ref n, ref v); }
        internal override unsafe void tkgl4Color4fNormal3fVertex3(Single* c, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4fNormal3fVertex3(c, n, v); }
        internal override void tkglColor4ubVertex2(Byte r, Byte g, Byte b, Byte a, Single x, Single y) { OpenTK.Graphics.OpenGL.GL.Sun.Color4ubVertex2(r, g, b, a, x, y); }
        internal override void tkgl2Color4ubVertex2(Byte[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4ubVertex2(c, v); }
        internal override void tkgl3Color4ubVertex2(ref Byte c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4ubVertex2(ref c, ref v); }
        internal override unsafe void tkgl4Color4ubVertex2(Byte* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4ubVertex2(c, v); }
        internal override void tkglColor4ubVertex3(Byte r, Byte g, Byte b, Byte a, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.Color4ubVertex3(r, g, b, a, x, y, z); }
        internal override void tkgl2Color4ubVertex3(Byte[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4ubVertex3(c, v); }
        internal override void tkgl3Color4ubVertex3(ref Byte c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4ubVertex3(ref c, ref v); }
        internal override unsafe void tkgl4Color4ubVertex3(Byte* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.Color4ubVertex3(c, v); }
        internal override void tkglDrawMeshArrays(OpenTK.Graphics.OpenGL.BeginMode mode, Int32 first, Int32 count, Int32 width) { OpenTK.Graphics.OpenGL.GL.Sun.DrawMeshArrays(mode, first, count, width); }
        internal override void tkglGlobalAlphaFactor(SByte factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactor(factor); }
        internal override void tkgl2GlobalAlphaFactor(Double factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactor(factor); }
        internal override void tkgl3GlobalAlphaFactor(Single factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactor(factor); }
        internal override void tkgl4GlobalAlphaFactor(Int32 factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactor(factor); }
        internal override void tkglGlobalAlphaFactors(Int16 factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactors(factor); }
        internal override void tkgl5GlobalAlphaFactor(Byte factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactor(factor); }
        internal override void tkgl6GlobalAlphaFactor(UInt32 factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactor(factor); }
        internal override void tkgl7GlobalAlphaFactor(Int16 factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactor(factor); }
        internal override void tkgl8GlobalAlphaFactor(UInt16 factor) { OpenTK.Graphics.OpenGL.GL.Sun.GlobalAlphaFactor(factor); }
        internal override void tkglNormal3fVertex3(Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.Normal3fVertex3(nx, ny, nz, x, y, z); }
        internal override void tkgl2Normal3fVertex3(Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.Normal3fVertex3(n, v); }
        internal override void tkgl3Normal3fVertex3(ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.Normal3fVertex3(ref n, ref v); }
        internal override unsafe void tkgl4Normal3fVertex3(Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.Normal3fVertex3(n, v); }
        internal override void tkglReplacementCodePointer(OpenTK.Graphics.OpenGL.SunTriangleList type, Int32 stride, IntPtr pointer) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodePointer(type, stride, pointer); }
        internal override void tkglReplacementCode(Byte code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkgl2ReplacementCode(Byte[] code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override unsafe void tkgl3ReplacementCode(Byte* code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkglReplacementCodeuiColor3fVertex3(Int32 rc, Single r, Single g, Single b, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor3fVertex3(rc, r, g, b, x, y, z); }
        internal override void tkgl2ReplacementCodeuiColor3fVertex3(UInt32 rc, Single r, Single g, Single b, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor3fVertex3(rc, r, g, b, x, y, z); }
        internal override void tkgl3ReplacementCodeuiColor3fVertex3(ref Int32 rc, ref Single c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor3fVertex3(ref rc, ref c, ref v); }
        internal override unsafe void tkgl4ReplacementCodeuiColor3fVertex3(Int32* rc, Single[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor3fVertex3(rc, c, v); }
        internal override unsafe void tkgl5ReplacementCodeuiColor3fVertex3(Int32* rc, Single* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor3fVertex3(rc, c, v); }
        internal override void tkgl6ReplacementCodeuiColor3fVertex3(ref UInt32 rc, ref Single c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor3fVertex3(ref rc, ref c, ref v); }
        internal override unsafe void tkgl7ReplacementCodeuiColor3fVertex3(UInt32* rc, Single[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor3fVertex3(rc, c, v); }
        internal override unsafe void tkgl8ReplacementCodeuiColor3fVertex3(UInt32* rc, Single* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor3fVertex3(rc, c, v); }
        internal override void tkglReplacementCodeuiColor4fNormal3fVertex3(Int32 rc, Single r, Single g, Single b, Single a, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4fNormal3fVertex3(rc, r, g, b, a, nx, ny, nz, x, y, z); }
        internal override void tkgl2ReplacementCodeuiColor4fNormal3fVertex3(UInt32 rc, Single r, Single g, Single b, Single a, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4fNormal3fVertex3(rc, r, g, b, a, nx, ny, nz, x, y, z); }
        internal override void tkgl3ReplacementCodeuiColor4fNormal3fVertex3(ref Int32 rc, ref Single c, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4fNormal3fVertex3(ref rc, ref c, ref n, ref v); }
        internal override unsafe void tkgl4ReplacementCodeuiColor4fNormal3fVertex3(Int32* rc, Single[] c, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4fNormal3fVertex3(rc, c, n, v); }
        internal override unsafe void tkgl5ReplacementCodeuiColor4fNormal3fVertex3(Int32* rc, Single* c, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4fNormal3fVertex3(rc, c, n, v); }
        internal override void tkgl6ReplacementCodeuiColor4fNormal3fVertex3(ref UInt32 rc, ref Single c, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4fNormal3fVertex3(ref rc, ref c, ref n, ref v); }
        internal override unsafe void tkgl7ReplacementCodeuiColor4fNormal3fVertex3(UInt32* rc, Single[] c, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4fNormal3fVertex3(rc, c, n, v); }
        internal override unsafe void tkgl8ReplacementCodeuiColor4fNormal3fVertex3(UInt32* rc, Single* c, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4fNormal3fVertex3(rc, c, n, v); }
        internal override void tkglReplacementCodeuiColor4ubVertex3(Int32 rc, Byte r, Byte g, Byte b, Byte a, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4ubVertex3(rc, r, g, b, a, x, y, z); }
        internal override void tkgl2ReplacementCodeuiColor4ubVertex3(UInt32 rc, Byte r, Byte g, Byte b, Byte a, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4ubVertex3(rc, r, g, b, a, x, y, z); }
        internal override void tkgl3ReplacementCodeuiColor4ubVertex3(ref Int32 rc, ref Byte c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4ubVertex3(ref rc, ref c, ref v); }
        internal override unsafe void tkgl4ReplacementCodeuiColor4ubVertex3(Int32* rc, Byte[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4ubVertex3(rc, c, v); }
        internal override unsafe void tkgl5ReplacementCodeuiColor4ubVertex3(Int32* rc, Byte* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4ubVertex3(rc, c, v); }
        internal override void tkgl6ReplacementCodeuiColor4ubVertex3(ref UInt32 rc, ref Byte c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4ubVertex3(ref rc, ref c, ref v); }
        internal override unsafe void tkgl7ReplacementCodeuiColor4ubVertex3(UInt32* rc, Byte[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4ubVertex3(rc, c, v); }
        internal override unsafe void tkgl8ReplacementCodeuiColor4ubVertex3(UInt32* rc, Byte* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiColor4ubVertex3(rc, c, v); }
        internal override void tkglReplacementCodeuiNormal3fVertex3(Int32 rc, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiNormal3fVertex3(rc, nx, ny, nz, x, y, z); }
        internal override void tkgl2ReplacementCodeuiNormal3fVertex3(UInt32 rc, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiNormal3fVertex3(rc, nx, ny, nz, x, y, z); }
        internal override void tkgl3ReplacementCodeuiNormal3fVertex3(ref Int32 rc, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiNormal3fVertex3(ref rc, ref n, ref v); }
        internal override unsafe void tkgl4ReplacementCodeuiNormal3fVertex3(Int32* rc, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiNormal3fVertex3(rc, n, v); }
        internal override unsafe void tkgl5ReplacementCodeuiNormal3fVertex3(Int32* rc, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiNormal3fVertex3(rc, n, v); }
        internal override void tkgl6ReplacementCodeuiNormal3fVertex3(ref UInt32 rc, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiNormal3fVertex3(ref rc, ref n, ref v); }
        internal override unsafe void tkgl7ReplacementCodeuiNormal3fVertex3(UInt32* rc, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiNormal3fVertex3(rc, n, v); }
        internal override unsafe void tkgl8ReplacementCodeuiNormal3fVertex3(UInt32* rc, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiNormal3fVertex3(rc, n, v); }
        internal override void tkgl4ReplacementCode(Int32 code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkgl5ReplacementCode(UInt32 code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkglReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(Int32 rc, Single s, Single t, Single r, Single g, Single b, Single a, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(rc, s, t, r, g, b, a, nx, ny, nz, x, y, z); }
        internal override void tkgl2ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(UInt32 rc, Single s, Single t, Single r, Single g, Single b, Single a, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(rc, s, t, r, g, b, a, nx, ny, nz, x, y, z); }
        internal override void tkgl3ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(ref Int32 rc, ref Single tc, ref Single c, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(ref rc, ref tc, ref c, ref n, ref v); }
        internal override unsafe void tkgl4ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(Int32* rc, Single[] tc, Single[] c, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(rc, tc, c, n, v); }
        internal override unsafe void tkgl5ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(Int32* rc, Single* tc, Single* c, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(rc, tc, c, n, v); }
        internal override void tkgl6ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(ref UInt32 rc, ref Single tc, ref Single c, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(ref rc, ref tc, ref c, ref n, ref v); }
        internal override unsafe void tkgl7ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(UInt32* rc, Single[] tc, Single[] c, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(rc, tc, c, n, v); }
        internal override unsafe void tkgl8ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(UInt32* rc, Single* tc, Single* c, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3(rc, tc, c, n, v); }
        internal override void tkglReplacementCodeuiTexCoord2fNormal3fVertex3(Int32 rc, Single s, Single t, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fNormal3fVertex3(rc, s, t, nx, ny, nz, x, y, z); }
        internal override void tkgl2ReplacementCodeuiTexCoord2fNormal3fVertex3(UInt32 rc, Single s, Single t, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fNormal3fVertex3(rc, s, t, nx, ny, nz, x, y, z); }
        internal override void tkgl3ReplacementCodeuiTexCoord2fNormal3fVertex3(ref Int32 rc, ref Single tc, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fNormal3fVertex3(ref rc, ref tc, ref n, ref v); }
        internal override unsafe void tkgl4ReplacementCodeuiTexCoord2fNormal3fVertex3(Int32* rc, Single[] tc, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fNormal3fVertex3(rc, tc, n, v); }
        internal override unsafe void tkgl5ReplacementCodeuiTexCoord2fNormal3fVertex3(Int32* rc, Single* tc, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fNormal3fVertex3(rc, tc, n, v); }
        internal override void tkgl6ReplacementCodeuiTexCoord2fNormal3fVertex3(ref UInt32 rc, ref Single tc, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fNormal3fVertex3(ref rc, ref tc, ref n, ref v); }
        internal override unsafe void tkgl7ReplacementCodeuiTexCoord2fNormal3fVertex3(UInt32* rc, Single[] tc, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fNormal3fVertex3(rc, tc, n, v); }
        internal override unsafe void tkgl8ReplacementCodeuiTexCoord2fNormal3fVertex3(UInt32* rc, Single* tc, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fNormal3fVertex3(rc, tc, n, v); }
        internal override void tkglReplacementCodeuiTexCoord2fVertex3(Int32 rc, Single s, Single t, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fVertex3(rc, s, t, x, y, z); }
        internal override void tkgl2ReplacementCodeuiTexCoord2fVertex3(UInt32 rc, Single s, Single t, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fVertex3(rc, s, t, x, y, z); }
        internal override void tkgl3ReplacementCodeuiTexCoord2fVertex3(ref Int32 rc, ref Single tc, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fVertex3(ref rc, ref tc, ref v); }
        internal override unsafe void tkgl4ReplacementCodeuiTexCoord2fVertex3(Int32* rc, Single[] tc, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fVertex3(rc, tc, v); }
        internal override unsafe void tkgl5ReplacementCodeuiTexCoord2fVertex3(Int32* rc, Single* tc, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fVertex3(rc, tc, v); }
        internal override void tkgl6ReplacementCodeuiTexCoord2fVertex3(ref UInt32 rc, ref Single tc, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fVertex3(ref rc, ref tc, ref v); }
        internal override unsafe void tkgl7ReplacementCodeuiTexCoord2fVertex3(UInt32* rc, Single[] tc, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fVertex3(rc, tc, v); }
        internal override unsafe void tkgl8ReplacementCodeuiTexCoord2fVertex3(UInt32* rc, Single* tc, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiTexCoord2fVertex3(rc, tc, v); }
        internal override void tkglReplacementCodeuiVertex3(Int32 rc, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiVertex3(rc, x, y, z); }
        internal override void tkgl2ReplacementCodeuiVertex3(UInt32 rc, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiVertex3(rc, x, y, z); }
        internal override void tkgl3ReplacementCodeuiVertex3(ref Int32 rc, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiVertex3(ref rc, ref v); }
        internal override unsafe void tkgl4ReplacementCodeuiVertex3(Int32* rc, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiVertex3(rc, v); }
        internal override unsafe void tkgl5ReplacementCodeuiVertex3(Int32* rc, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiVertex3(rc, v); }
        internal override void tkgl6ReplacementCodeuiVertex3(ref UInt32 rc, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiVertex3(ref rc, ref v); }
        internal override unsafe void tkgl7ReplacementCodeuiVertex3(UInt32* rc, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiVertex3(rc, v); }
        internal override unsafe void tkgl8ReplacementCodeuiVertex3(UInt32* rc, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCodeuiVertex3(rc, v); }
        internal override void tkgl6ReplacementCode(Int32[] code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override unsafe void tkgl7ReplacementCode(Int32* code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkgl8ReplacementCode(UInt32[] code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override unsafe void tkgl9ReplacementCode(UInt32* code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkgl10ReplacementCode(Int16 code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkgl11ReplacementCode(UInt16 code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkgl12ReplacementCode(Int16[] code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override unsafe void tkgl13ReplacementCode(Int16* code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkgl14ReplacementCode(UInt16[] code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override unsafe void tkgl15ReplacementCode(UInt16* code) { OpenTK.Graphics.OpenGL.GL.Sun.ReplacementCode(code); }
        internal override void tkglTexCoord2fColor3fVertex3(Single s, Single t, Single r, Single g, Single b, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor3fVertex3(s, t, r, g, b, x, y, z); }
        internal override void tkgl2TexCoord2fColor3fVertex3(Single[] tc, Single[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor3fVertex3(tc, c, v); }
        internal override void tkgl3TexCoord2fColor3fVertex3(ref Single tc, ref Single c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor3fVertex3(ref tc, ref c, ref v); }
        internal override unsafe void tkgl4TexCoord2fColor3fVertex3(Single* tc, Single* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor3fVertex3(tc, c, v); }
        internal override void tkglTexCoord2fColor4fNormal3fVertex3(Single s, Single t, Single r, Single g, Single b, Single a, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor4fNormal3fVertex3(s, t, r, g, b, a, nx, ny, nz, x, y, z); }
        internal override void tkgl2TexCoord2fColor4fNormal3fVertex3(Single[] tc, Single[] c, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor4fNormal3fVertex3(tc, c, n, v); }
        internal override void tkgl3TexCoord2fColor4fNormal3fVertex3(ref Single tc, ref Single c, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor4fNormal3fVertex3(ref tc, ref c, ref n, ref v); }
        internal override unsafe void tkgl4TexCoord2fColor4fNormal3fVertex3(Single* tc, Single* c, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor4fNormal3fVertex3(tc, c, n, v); }
        internal override void tkglTexCoord2fColor4ubVertex3(Single s, Single t, Byte r, Byte g, Byte b, Byte a, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor4ubVertex3(s, t, r, g, b, a, x, y, z); }
        internal override void tkgl2TexCoord2fColor4ubVertex3(Single[] tc, Byte[] c, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor4ubVertex3(tc, c, v); }
        internal override void tkgl3TexCoord2fColor4ubVertex3(ref Single tc, ref Byte c, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor4ubVertex3(ref tc, ref c, ref v); }
        internal override unsafe void tkgl4TexCoord2fColor4ubVertex3(Single* tc, Byte* c, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fColor4ubVertex3(tc, c, v); }
        internal override void tkglTexCoord2fNormal3fVertex3(Single s, Single t, Single nx, Single ny, Single nz, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fNormal3fVertex3(s, t, nx, ny, nz, x, y, z); }
        internal override void tkgl2TexCoord2fNormal3fVertex3(Single[] tc, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fNormal3fVertex3(tc, n, v); }
        internal override void tkgl3TexCoord2fNormal3fVertex3(ref Single tc, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fNormal3fVertex3(ref tc, ref n, ref v); }
        internal override unsafe void tkgl4TexCoord2fNormal3fVertex3(Single* tc, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fNormal3fVertex3(tc, n, v); }
        internal override void tkglTexCoord2fVertex3(Single s, Single t, Single x, Single y, Single z) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fVertex3(s, t, x, y, z); }
        internal override void tkgl2TexCoord2fVertex3(Single[] tc, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fVertex3(tc, v); }
        internal override void tkgl3TexCoord2fVertex3(ref Single tc, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fVertex3(ref tc, ref v); }
        internal override unsafe void tkgl4TexCoord2fVertex3(Single* tc, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord2fVertex3(tc, v); }
        internal override void tkglTexCoord4fColor4fNormal3fVertex4(Single s, Single t, Single p, Single q, Single r, Single g, Single b, Single a, Single nx, Single ny, Single nz, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord4fColor4fNormal3fVertex4(s, t, p, q, r, g, b, a, nx, ny, nz, x, y, z, w); }
        internal override void tkgl2TexCoord4fColor4fNormal3fVertex4(Single[] tc, Single[] c, Single[] n, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord4fColor4fNormal3fVertex4(tc, c, n, v); }
        internal override void tkgl3TexCoord4fColor4fNormal3fVertex4(ref Single tc, ref Single c, ref Single n, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord4fColor4fNormal3fVertex4(ref tc, ref c, ref n, ref v); }
        internal override unsafe void tkgl4TexCoord4fColor4fNormal3fVertex4(Single* tc, Single* c, Single* n, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord4fColor4fNormal3fVertex4(tc, c, n, v); }
        internal override void tkglTexCoord4fVertex4(Single s, Single t, Single p, Single q, Single x, Single y, Single z, Single w) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord4fVertex4(s, t, p, q, x, y, z, w); }
        internal override void tkgl2TexCoord4fVertex4(Single[] tc, Single[] v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord4fVertex4(tc, v); }
        internal override void tkgl3TexCoord4fVertex4(ref Single tc, ref Single v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord4fVertex4(ref tc, ref v); }
        internal override unsafe void tkgl4TexCoord4fVertex4(Single* tc, Single* v) { OpenTK.Graphics.OpenGL.GL.Sun.TexCoord4fVertex4(tc, v); }
        internal override void tkglFinishTexture() { OpenTK.Graphics.OpenGL.GL.Sunx.FinishTexture(); }

    }
}