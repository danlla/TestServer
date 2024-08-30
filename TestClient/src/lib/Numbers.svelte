<script lang="ts">
    import { onMount } from 'svelte';
    import { ApiException, Client, Number } from './client';
    import {
        Button,
        Column,
        Grid,
        InlineNotification,
        NumberInput,
        Row,
        Tile,
    } from 'carbon-components-svelte';
    import 'carbon-components-svelte/css/all.css';
    import { TrashCan } from 'carbon-icons-svelte';

    export let baseUrl: string;

    let numbers: Number[] = [];

    let insertValue: number = 0;

    let error: string | null = null;

    let sum: number | null = null;

    onMount(async () => {
        await getNumbers();
    });

    async function getNumbers() {
        let client = new Client(baseUrl);
        try {
            numbers = await client.numberGet();
        } catch (ex) {
            if (ex instanceof ApiException) {
                error = ex.response;
            } else if (ex instanceof Error) {
                error = ex.message;
            }
        }
    }

    async function remove(id: number | undefined) {
        let client = new Client(baseUrl);
        try {
            await client.numberDelete(id);
        } catch (ex) {
            if (ex instanceof ApiException) {
                error = ex.response;
            } else if (ex instanceof Error) {
                error = ex.message;
            }
        }

        await getNumbers();
    }

    async function insert(num: number | undefined) {
        let client = new Client(baseUrl);
        try {
            await client.numberPost(num);
        } catch (ex) {
            if (ex instanceof ApiException) {
                error = ex.response;
            } else if (ex instanceof Error) {
                error = ex.message;
            }
        }

        await getNumbers();
    }

    async function calculateSum() {
        let client = new Client(baseUrl);
        try {
            sum = await client.calculator();
        } catch (ex) {
            if (ex instanceof ApiException) {
                error = ex.response;
            } else if (ex instanceof Error) {
                error = ex.message;
            }
        }
    }
</script>

<Tile>
    <Grid>
        <Row>
            <Column>
                <NumberInput bind:value={insertValue} />
            </Column>
            <Column>
                <Button on:click={async () => insert(insertValue)}
                    >Insert</Button
                >
            </Column>
        </Row>
    </Grid>
</Tile>
<br /><br />
<Grid>
    {#each numbers as number}
        <Tile style="align-items: center;">
            <Row>
                <Column>
                    <div style="font-size: 20px;">
                        id: {number.id}<br /> value: {number.value}
                    </div>
                </Column>
                <Column>
                    <Button
                        iconDescription="Delete"
                        icon={TrashCan}
                        on:click={async () => await remove(number.id)}
                    />
                </Column>
            </Row>
        </Tile>
        <br />
    {/each}
</Grid>

<Tile>
    {#if sum}
        <div style="font-size: 20px;">Sum: {sum}</div>
    {/if}
    <br />
    <br />
    <Button on:click={calculateSum}>Calculate sum</Button>
</Tile>

{#if error}
    <InlineNotification
        title="Error:"
        subtitle={error}
        on:close={(e) => {
            e.preventDefault();
            error = null;
        }}
    />
{/if}
