<script lang="ts">
  import { onMount } from "svelte";
  import GameMasterItem from "./GameMasterItem.svelte";
  import GameMasterService from "../../services/GameMasterService";
  import GameMasterForm from "./GameMasterForm.svelte";
  import type IGameMaster from "../../models/GameMaster";
  import GameMaster from "../../models/GameMaster";

  let gameMastersInDb = Array<IGameMaster>();

  async function getAllGameMasters() {
    gameMastersInDb = await GameMasterService.getAll().catch(() => []);
  }

  onMount(async () => {
    await getAllGameMasters();
  });

  function deleteGameMaster(e: CustomEvent) {
    const id = e.detail;
    GameMasterService.remove(id as string)
      .then(() => getAllGameMasters());
  }

  function editGameMaster(e: CustomEvent) {
    const gameMaster = e.detail;
    GameMasterService.update(gameMaster.id as string, gameMaster)
      .then(() => getAllGameMasters());
  }

  function createGameMaster(e: CustomEvent) {
    const gameMaster = new GameMaster();
    gameMaster.name = e.detail;
    GameMasterService.create(gameMaster)
      .then(() => getAllGameMasters());
  }
</script>

<div class="gamemaster-list">
  <GameMasterForm on:create-gamemaster={createGameMaster} />
  <h1>GameMaster List</h1>
  {#if gameMastersInDb?.length}
    {#each gameMastersInDb as gameMaster (gameMaster.id)}
      <GameMasterItem
        {gameMaster}
        on:delete-gamemaster={deleteGameMaster}
        on:edit-gamemaster={editGameMaster}
      />
    {/each}
  {:else}
    <span>There are no Game Masters.</span>
  {/if}
</div>

<style scoped>
.gamemaster-list {
  float: left;
  padding: 10px;
  border: 2px solid #4e4e4e;
  border-radius: 5px;
  width: 300px;
  min-height: 250px;
}
</style>
