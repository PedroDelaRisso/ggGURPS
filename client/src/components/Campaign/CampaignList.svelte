<script lang="ts">
  import { onMount } from "svelte";
  import CampaignItem from "./CampaignItem.svelte";
  import CampaignService from "../../services/CampaignService";
  import CampaignForm from "./CampaignForm.svelte";
  import type ICampaign from "../../models/Campaign";
  import Campaign from "../../models/Campaign";

  let campaignsInDb = Array<ICampaign>();

  async function getAllCampaigns() {
    campaignsInDb = await CampaignService.getAll().catch(() => []);
  }

  onMount(async () => {
    await getAllCampaigns();
  });

  function deleteCampaign(e: CustomEvent) {
    const id = e.detail;
    CampaignService.remove(id as string)
      .then(() => getAllCampaigns());
  }

  function editCampaign(e: CustomEvent) {
    const campaign = e.detail;
    CampaignService.update(campaign.id as string, campaign)
      .then(() => getAllCampaigns());
  }

  function createCampaign(e: CustomEvent) {
    const campaign = e.detail as ICampaign;
    CampaignService.create(campaign)
      .then(() => getAllCampaigns());
  }
</script>
<div class="campaign-list">
  <CampaignForm on:create-campaign={createCampaign} />
  <h1>Campaign List</h1>
  {#if campaignsInDb?.length}
    {#each campaignsInDb as campaign (campaign.id)}
      <CampaignItem
        {campaign}
        on:delete-Campaign={deleteCampaign}
        on:edit-Campaign={editCampaign}
      />
    {/each}
  {:else}
    <span>There are no Campaigns.</span>
  {/if}
</div>

<style scoped>
.campaign-list {
  float: left;
  padding: 10px;
  border: 2px solid #4e4e4e;
  border-radius: 5px;
  width: 300px;
  min-height: 250px;
  margin-left: 2vw;
}
</style>