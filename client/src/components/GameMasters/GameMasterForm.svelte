<script lang="ts">
import { createEventDispatcher } from "svelte";

let name: string;

const dispatch = createEventDispatcher();

function createGameMaster() {
    dispatch('create-gamemaster', name);
    name = '';
}
</script>

<input type="text" placeholder="Insert the Game Master's name" bind:value={name} />

<button on:click={() => createGameMaster()}>Create GameMaster</button>

<style>
input {
    width: 100%;
}
</style>