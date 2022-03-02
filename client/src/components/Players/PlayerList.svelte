<script lang="ts">
  import { onMount } from "svelte";
  import PlayerItem from "./PlayerItem.svelte";
  import PlayerService from "../../services/PlayerService";
  import PlayerForm from "./PlayerForm.svelte";
  import type IPlayer from "../../models/Player";
  import Player from "../../models/Player";

  let playersInDb = Array<IPlayer>();

  async function getAllPlayers() {
    playersInDb = await PlayerService.getAll().catch(() => []);
  }

  onMount(async () => {
    await getAllPlayers();
  });

  function deletePlayer(e: CustomEvent) {
    const id = e.detail;
    PlayerService.remove(id as string)
      .then(() => getAllPlayers());
  }

  function editPlayer(e: CustomEvent) {
    const player = e.detail;
    PlayerService.update(player.id as string, player)
      .then(() => getAllPlayers());
  }

  function createPlayer(e: CustomEvent) {
    const player = new Player();
    player.name = e.detail;
    PlayerService.create(player)
      .then(() => getAllPlayers());
  }
</script>
<div class="player-list">
  <PlayerForm on:create-player={createPlayer} />
  <h1>Player List</h1>
  {#if playersInDb?.length}
    {#each playersInDb as player (player.id)}
      <PlayerItem
        {player}
        on:delete-Player={deletePlayer}
        on:edit-Player={editPlayer}
      />
    {/each}
  {:else}
    <span>There are no Players.</span>
  {/if}
</div>

<style scoped>
.player-list {
  float: left;
  padding: 10px;
  border: 2px solid #4e4e4e;
  border-radius: 5px;
  width: 300px;
  min-height: 250px;
  margin-left: 2vw;
}
</style>