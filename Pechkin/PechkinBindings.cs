﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using Pechkin.Util;
using Pechkin.Properties;

namespace Pechkin
{
    [Serializable]
    internal static class PechkinBindings
    {
        static PechkinBindings()
        {
            var exePath = Path.GetFullPath(Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                AppDomain.CurrentDomain.RelativeSearchPath));

            var assemblyName = Path.Combine(exePath, "libeay32.dll");

            if (!File.Exists(assemblyName))
            {
                File.WriteAllBytes(assemblyName, Resources.libeay32);
            }

            assemblyName = Path.Combine(exePath, "libgcc_s_dw2-1.dll");

            if (!File.Exists(assemblyName))
            {
                File.WriteAllBytes(assemblyName, Resources.libgcc_s_dw2_1);
            }

            assemblyName = Path.Combine(exePath, "mingwm10.dll");

            if (!File.Exists(assemblyName))
            {
                File.WriteAllBytes(assemblyName, Resources.mingwm10);
            }

            assemblyName = Path.Combine(exePath, "ssleay32.dll");

            if (!File.Exists(assemblyName))
            {
                File.WriteAllBytes(assemblyName, Resources.ssleay32);
            }

            assemblyName = Path.Combine(exePath, "wkhtmltox0.dll");

            if (!File.Exists(assemblyName))
            {
                File.WriteAllBytes(assemblyName, Resources.wkhtmltox0);
            }
        }

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
                                                String filename);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_init(int useGraphics);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_deinit();

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_extended_qt();

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern String wkhtmltopdf_version();

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr wkhtmltopdf_create_global_settings();

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr wkhtmltopdf_create_object_settings();

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_set_global_setting(IntPtr settings,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
            String name,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
            String value);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_get_global_setting(IntPtr settings,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
            String name,
            [In]
            [Out]
            ref byte[] value, int valueSize);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_set_object_setting(IntPtr settings,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
            String name,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
            String value);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_get_object_setting(IntPtr settings,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
            String name,
            [In]
            [Out]
            ref byte[] value, int vs);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr wkhtmltopdf_create_converter(IntPtr globalSettings);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void wkhtmltopdf_destroy_converter(IntPtr converter);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void wkhtmltopdf_set_warning_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)]
                                                                   StringCallback callback);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void wkhtmltopdf_set_error_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)]
                                                                 StringCallback callback);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void wkhtmltopdf_set_phase_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)]
                                                                         VoidCallback callback);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void wkhtmltopdf_set_progress_changed_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)]
                                                                            IntCallback callback);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void wkhtmltopdf_set_finished_callback(IntPtr converter, [MarshalAs(UnmanagedType.FunctionPtr)]
                                                                    IntCallback callback);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_convert(IntPtr converter);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void wkhtmltopdf_add_object(IntPtr converter, IntPtr objectSettings,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Utf8Marshaler))]
            String data);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void wkhtmltopdf_add_object(IntPtr converter, IntPtr objectSettings, byte[] data);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_current_phase(IntPtr converter);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_phase_count(IntPtr converter);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr wkhtmltopdf_phase_description(IntPtr converter, int phase);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr wkhtmltopdf_progress_string(IntPtr converter);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_http_error_code(IntPtr converter);

        [DllImport("wkhtmltox0.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int wkhtmltopdf_get_output(IntPtr converter, out IntPtr data);
    }
}