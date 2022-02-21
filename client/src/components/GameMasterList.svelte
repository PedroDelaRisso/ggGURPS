<script lang="ts">
    import GameMasterItem from "./GameMasterItem.svelte";

    export let gameMasters = [];
</script>
<h1>GameMaster List</h1>
{#if gameMasters.length}
    {#each gameMasters as gameMaster (gameMaster.id)}
        <GameMasterItem {gameMaster} on:delete-gamemaster />
    {/each}
{/if}