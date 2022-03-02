<script lang="ts">
import { createEventDispatcher } from "svelte";

let name: string;

const dispatch = createEventDispatcher();

function createPlayer() {
    dispatch('create-player', name);
    name = '';
}
</script>

<input type="text" placeholder="Insert the Player's name" bind:value={name} />

<button on:click={() => createPlayer()}>Create Player</button>

<style>
input {
    width: 100%;
}
</style>