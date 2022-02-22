<script lang="ts">
import { createEventDispatcher } from 'svelte';
import Card from './Card.svelte';
import type IGameMaster from '../models/GameMaster';
import GameMaster from '../models/GameMaster';

const dispatch = createEventDispatcher();
export let gameMaster: IGameMaster;
let editedGameMaster: IGameMaster;
let name: string;
let editing = false;

function handleDelete(itemId: number) {
    dispatch('delete-gamemaster', itemId);
}

function handleEdit(itemId: number) {
    editing = true;
    editedGameMaster = new GameMaster();
    editedGameMaster.id = itemId;
}

async function saveChanges(gm: IGameMaster) {
    editedGameMaster.name = name;
    dispatch('edit-gamemaster', editedGameMaster);
    editing = !editing;
}
</script>

<Card>
  <div class="id-display">
    {gameMaster.id}
  </div>
  {#if !editing}
    <div class="name-display">
      {gameMaster.name}
    </div>
  {:else}
    <div>
      <input type="text" bind:value={name} />
      <button on:click={() => saveChanges(editedGameMaster)}
        >Save changes</button
      >
    </div>
  {/if}
  <button class="delete" on:click={() => handleDelete(gameMaster.id)}
    >Delete</button
  >
  <button class="edit" on:click={() => handleEdit(gameMaster.id)}>Edit</button>
</Card>

<style>
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
</style>
