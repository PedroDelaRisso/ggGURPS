<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import Card from "../Card.svelte";
  import type IPlayer from "../../models/Player";
  import Player from "../../models/Player";

  const dispatch = createEventDispatcher();
  export let player: IPlayer;
  let editedPlayer: IPlayer;
  let name: string;
  let editing = false;

  function handleDelete() {
    dispatch("delete-Player", player.id);
  }

  function handleEdit() {
    editing = true;
    editedPlayer = player;
    name = player.name;
  }

  async function saveChanges() {
    editedPlayer.name = name;
    dispatch("edit-Player", editedPlayer);
    editing = !editing;
  }
</script>

<Card>
  {#if !editing}
    <div class="name-display">
      {player.name}
      <br>
      ID: {player.id}
    </div>
  {:else}
    <div>
      <input type="text" placeholder="Player name" bind:value={name} />
      <button on:click={saveChanges}>
        Save changes
      </button>
    </div>
  {/if}
  <button class="delete" on:click={handleDelete}
    >Delete</button
  >
  <button class="edit" on:click={handleEdit}>Edit</button>
</Card>

<style scoped>
  .delete {
    top: 10px;
    right: 20px;
    cursor: pointer;
    background: none;
    border: none;
    color: red;
    font-weight: bolder;
    float: right;
  }

  .edit {
    top: 10px;
    right: 20px;
    cursor: pointer;
    background: none;
    border: none;
    color: green;
    font-weight: bolder;
    float: right;
  }

  .name-display {
    max-width: 250px;
    overflow: hidden;
    text-overflow: ellipsis;
  }
</style>
