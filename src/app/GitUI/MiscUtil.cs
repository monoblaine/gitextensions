using System.Runtime.InteropServices;

namespace GitUI;

internal static unsafe class MiscUtil
{
#pragma warning disable SA1305 // Field names should not use Hungarian notation
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern bool FreeLibrary(void* hModule);

    [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
    public static extern void* GetProcAddress(void* hModule, string lpProcName);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern void* LoadLibrary(string libname);
#pragma warning restore SA1305 // Field names should not use Hungarian notation

    private static bool? _isRunningUnderWine;

    public static bool IsRunningUnderWine
    {
        get
        {
            if (_isRunningUnderWine is null)
            {
                void* module = LoadLibrary("ntdll.dll");

                if (module is null)
                {
                    throw new DllNotFoundException("The given library is not loaded into the current process.");
                }

                bool exists = GetProcAddress(module, "wine_get_version") is not null;
                FreeLibrary(module);
                _isRunningUnderWine = exists;
            }

            return _isRunningUnderWine.Value;
        }
    }
}
