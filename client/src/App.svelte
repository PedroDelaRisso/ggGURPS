<script lang="ts">
  import { onMount } from "svelte";
  import GameMasterForm from "./components/GameMasterForm.svelte";
  import GameMasterItem from "./components/GameMasterItem.svelte";
  import GameMasterList from "./components/GameMasterList.svelte";
  import GameMaster from "./models/GameMaster";
  import GameMasterService from "./services/GameMasterService";

  $: gameMasters = GetGameMasters() ?? [];

  const gameMasterService = new GameMasterService();

  async function onMount() {
    await gameMasterService.GetAll();
  }

  async function GetGameMasters() {
    return await gameMasterService.GetAll()
      .then((response) => response.json())
      .then((data) => (gameMasters = data));
  }

  async function deleteGameMaster(e) {
    const itemId = e.detail;
    await gameMasterService.Remove(itemId)
      .then(
        () => (gameMasters = gameMasters.filter((item) => item.id !== itemId))
      );
  }

  async function createGameMaster(e) {
    const gm = new GameMaster();
    gm.name = e.detail;
    await gameMasterService
      .Create(gm)
      .then((response) => response.json())
      .then(() => GetGameMasters());
  }
</script>

<main>
  <GameMasterForm on:create-gamemaster={createGameMaster} />
  <GameMasterList {gameMasters} on:delete-gamemaster={deleteGameMaster} />
</main>
