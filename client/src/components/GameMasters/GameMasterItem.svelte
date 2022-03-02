<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import Card from "../Card.svelte";
  import type IGameMaster from "../../models/GameMaster";
  import GameMaster from "../../models/GameMaster";

  const dispatch = createEventDispatcher();
  export let gameMaster: IGameMaster;
  let editedGameMaster: IGameMaster;
  let name: string;
  let editing = false;

  function handleDelete() {
    dispatch("delete-gamemaster", gameMaster.id);
  }

  function handleEdit() {
    editing = true;
    editedGameMaster = gameMaster
    name = gameMaster.name;
  }

  async function saveChanges() {
    editedGameMaster.name = name;
    dispatch("edit-gamemaster", editedGameMaster);
    editing = !editing;
  }
</script>

<Card>
  {#if !editing}
    <div class="name-display">
      {gameMaster.name}
      <br>
      ID: {gameMaster.id}
    </div>
  {:else}
    <div>
      <input type="text" placeholder="Game Master name" bind:value={name} />
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
