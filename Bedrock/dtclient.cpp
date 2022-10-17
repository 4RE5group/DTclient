#include <Windows.h>
#include<stdlib.h>
#include <iostream>
#include <string>
#include <vector>

DWORD WINAPI start(LPVOID lpParam) {
	MessageBox( 0, "Blah blah...", "My Windows app!", MB_SETFOREGROUND );
	// logF("Starting up...");
	// logF("MSC v%i at %s", _MSC_VER, __TIMESTAMP__);

	// DWORD conThread;
	// CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)injectorConnectionThread, lpParam, NULL, &conThread);
	// logF("InjCon: %i", conThread);
	// init();

	// DWORD procId = GetCurrentProcessId();
	// if (!mem.Open(procId, SlimUtils::ProcessAccess::Full)) {
		// logF("Failed to open process, error-code: %i", GetLastError());
		// return 1;
	// }
	// gameModule = mem.GetModule(L"Minecraft.Windows.exe");  // Get Module for Base Address

	// MH_Initialize();
	// GameData::initGameData(gameModule, &mem, (HMODULE)lpParam);
	// Target::init(g_Data.getPtrLocalPlayer());

	// Hooks::Init();

	// DWORD keyThreadId;
	// CreateThread(nullptr, NULL, (LPTHREAD_START_ROUTINE)keyThread, lpParam, NULL, &keyThreadId);  // Checking Keypresses
	// logF("KeyT: %i", keyThreadId);


	// cmdMgr->initCommands();
	// logF("Initialized command manager (1/3)");
	// moduleMgr->initModules();
	// logF("Initialized module manager (2/3)");
	// configMgr->init();
	// logF("Initialized config manager (3/3)");

	// Hooks::Enable();
	// TabGui::init();
	// ClickGui::init();

	// logF("Hooks enabled");

	// std::thread countThread([] {
		// while (isRunning) {
			// Sleep(1000);
			// g_Data.fps = g_Data.frameCount;
			// g_Data.frameCount = 0;
			// g_Data.cpsLeft = g_Data.leftclickCount;
			// g_Data.leftclickCount = 0;
			// g_Data.cpsRight = g_Data.rightclickCount;
			// g_Data.rightclickCount = 0;
		// }
	// });
	// countThread.detach();

	// logF("Count thread started");

	ExitThread(0);
}



VOID WINAPI DllMain(HMODULE hModule,
					   DWORD ul_reason_for_call,
					   LPVOID) {
	switch (ul_reason_for_call) {
	case DLL_PROCESS_ATTACH: {
		CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)start, hModule, NULL, NULL);
		DisableThreadLibraryCalls(hModule);
	} break;
	case DLL_PROCESS_DETACH:
		// isRunning = false;

		// scriptMgr.unloadAllScripts();
		// configMgr->saveConfig();
		// moduleMgr->disable();
		// cmdMgr->disable();
		// Hooks::Restore();
		//GameWnd.OnDeactivated();

		// logF("Removing logger");
		// Logger::Disable();

		// MH_Uninitialize();
		// delete moduleMgr;
		// delete cmdMgr;
		// delete configMgr;
		// if (g_Data.getLocalPlayer() != nullptr) {
			// C_GuiData* guiData = g_Data.getClientInstance()->getGuiData();
			// if (guiData != nullptr && !GameData::shouldHide())
				// guiData->displayClientMessageF("%sEjected!", RED);
		// }
		break;
	}
	return TRUE;
}