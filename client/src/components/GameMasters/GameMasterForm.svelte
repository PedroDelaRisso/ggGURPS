<script lang="ts">
import { createEventDispatcher } from "svelte";

let name: string;

const dispatch = createEventDispatcher();

function createGameMaster() {
    dispatch('create-gamemaster', name);
}
</script>

<input type="text" bind:value={name} />

<button on:click={() => createGameMaster()}>Create GameMaster</button>