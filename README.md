<h1>Furion Game Framework V2</h1>
<p>A entitas framework mixed with Zenject dependency injection framework.</p>
<p>Entitas: https://github.com/sschmid/Entitas-CSharp/wiki/Overview</p>
<p>Zenject: https://github.com/modesttree/Zenject</p>

<ul>
<li>
	<h2>Bootstrapper</h2>
	<br />請務必在所有場景之中放置一個擁有Bootstrapper的Game Object
</li>
<li>
	<h2>Entity</h2>
	<br />一樣"東西", 作用是讓Component依附上它!，沒有Component的Entity沒有任何意義
</li>
<li>
	<h2>Component</h2>
	<br />遊戲資料的載體 沒有邏輯在內 可以分拆得十分仔細<br />所有Component定義放於 /Components 中<br />
</li>
<li>
	<h2>System</h2>
	<br />能夠監察Component變化, 並可以得知有關Entity是誰，遊戲的主要邏輯亦在此進行。<br />所有System定義於 /Systems 之內<br />
	<h3>Furion Defined:</h3>
	<ul>
		<li>Scene Management System<br />
			<blockquote style="margin: 0 0 0 40px; border: none; padding: 0px;">主要的場景管理系統，能夠監察 Scene Config 的變化載入不同的子 System，並且會載入對應的 Unity Scene<br />。而SceneType及Subsystem的對應定義在 /Components/SceneConfig.cs之中</blockquote>
		</li>
	</ul>
</li>
<li><h2>Context Installer (Zenject)</h2>
集中處理遊戲中的依賴性的地方，在這裡登記一些常用的組件(e.g. Background Music, Network Manager)然後在各個system中透過Zenject進行Dependency Injection
</li>
<li><h2>{SceneType} Installer (Zenject)</h2>
如果在場景更換時對Binding有所變動(e.g. 一些根據玩家行為的設定,動態的東西...)就在這裡重新Inject一次
</li>
</ul>
