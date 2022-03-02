<script lang="ts">
import { createEventDispatcher } from "svelte";

let name: string;
let gameMasterId: number;

const dispatch = createEventDispatcher();

function createCampaign() {
    dispatch('create-campaign', { name, gameMasterId });
    name = '';
    gameMasterId = 0;
}
</script>

<input type="text" placeholder="Insert the Campaign's name" bind:value={name} />
<input type="number" placeholder="Insert the Game Master's ID" bind:value={gameMasterId} />

<button on:click={() => createCampaign()}>Create Campaign</button>

<style>
input {
    width: 100%;
}
</style>