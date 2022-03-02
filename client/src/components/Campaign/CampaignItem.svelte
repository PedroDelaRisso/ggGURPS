<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import Card from "../Card.svelte";
  import type ICampaign from "../../models/Campaign";
  import Campaign from "../../models/Campaign";

  const dispatch = createEventDispatcher();
  export let campaign: ICampaign;
  let editedCampaign: ICampaign;
  let name: string;
  let gameMasterId: number;
  let editing = false;

  function handleDelete() {
    dispatch("delete-Campaign", campaign.id);
  }

  function handleEdit() {
    editing = true;
    editedCampaign = campaign;
    name = campaign.name;
    gameMasterId = campaign.gameMasterId;
  }

  async function saveChanges() {
    editedCampaign.name = name;
    editedCampaign.gameMasterId = gameMasterId;
    dispatch("edit-Campaign", editedCampaign);
    name = '';
    gameMasterId = 0;
    editing = !editing;
  }
</script>

<Card>
  {#if !editing}
    <div class="name-display">
      {campaign.name}
      <br>
      ID: {campaign.id}
      <br>
      GameMasterID: {campaign.gameMasterId}
    </div>
  {:else}
    <div>
      <input type="text" placeholder="Campaign name" bind:value={name} />
      <input type="number" placeholder="Game Master ID" bind:value={gameMasterId}>
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
