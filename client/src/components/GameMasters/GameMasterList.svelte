<script lang="ts">
  import { onMount } from "svelte";
  import GameMasterItem from "./GameMasterItem.svelte";
  import GameMasterService from "../../services/GameMasterService";
  import GameMasterForm from "./GameMasterForm.svelte";
  import type IGameMaster from "../../models/GameMaster";
  import GameMaster from "../../models/GameMaster";

  const gameMasterService = new GameMasterService();

  let gameMastersInDb = Array<IGameMaster>();

  async function getAllGameMasters() {
    gameMastersInDb = await gameMasterService.getAll().catch(() => []);
  }

  onMount(async () => {
    await getAllGameMasters();
  });

  function deleteGameMaster(e: CustomEvent) {
    const id = e.detail;
    gameMasterService.remove(id as string)
      .then(() => getAllGameMasters());
  }

  function editGameMaster(e: CustomEvent) {
    const gameMaster = e.detail;
    gameMasterService.update(gameMaster.id as string, gameMaster)
      .then(() => getAllGameMasters());
  }

  function createGameMaster(e: CustomEvent) {
    const gameMaster = new GameMaster();
    gameMaster.name = e.detail;
    gameMasterService.create(gameMaster)
      .then(() => getAllGameMasters());
  }
</script>

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
