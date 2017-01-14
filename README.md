# Furion Game Framework (based on Entita)

請另外下載 Entitas 共用之
https://github.com/sschmid/Entitas-CSharp
版本為3.6.1


Bootstrapper
 - 請務必放置於所有場景之中Game Object
 
Context
 - 用於操作Entity
 例如創造Entity, 刪除Entity
 
Entity
 - 一樣"東西", 作用是讓Component依附上它!
 
System
 - 監察需要的Component變化, 並可以得知有關Entity是誰
			特殊 System:
			Scene Management System
			- 根據 SceneConfig 中的 SceneType會載入不同的Subsystem
      
Component
 - 主要Component, 遊戲資料的載體 沒有邏輯在內 可以分拆得十分仔細
			特殊 Component:
			Scene Config
			- 儲存現時場景的 SceneType

			Listener Component
			- 亦是一種Component, 用於接收對應事件再進行下一步的動作

			Entity Behaviour
			- 用於一早已放置在Unity Scene的物件作初始化用途

			View
			
