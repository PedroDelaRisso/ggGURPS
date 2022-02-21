<script lang="ts">
    import { createEventDispatcher } from 'svelte';
    import Card from './Card.svelte';
    import type IGameMaster from '../models/GameMaster';
    import GameMasterList from './GameMasterList.svelte'

    const dispatch = createEventDispatcher();
    export let gameMaster: IGameMaster;

    function handleDelete(itemId: number) {
        dispatch('delete-gamemaster', itemId);
    }
</script>

<Card>
    <div class="id-display">
        {gameMaster.id}
    </div>
    <div class="name-display">
        {gameMaster.name}
    </div>
    <button class="delete" on:click={() => handleDelete(gameMaster.id)}>Delete</button>
</Card>

<style>
    .delete {
      position: absolute;
      top: 10px;
      right: 20px;
      cursor: pointer;
      background: none;
      border: none;
      color: red;
      font-weight: bolder;
    }
  </style>
