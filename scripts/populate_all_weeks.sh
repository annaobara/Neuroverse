#!/bin/bash

source .env

REPO="Ziforge/Neuroverse"

STATUS_FIELD="PVTSSF_lAHOCt5hsc4A1EqczgqmhT8"
STATUS_TODO="f75ad846"

WEEK_FIELD="PVTSSF_lAHOCt5hsc4A1Eqczgqmy9Q"
declare -A WEEK_IDS=(
  [1]="6860af6e"
  [2]="4d015d4f"
  [3]="35ded6d0"
  [4]="e2f13e12"
  [5]="fd1031c1"
  [6]="c2ebc958"
  [7]="a9cbe8bd"
  [8]="51c2e8b2"
)

GROUP_FIELD="PVTSSF_lAHOCt5hsc4A1EqczgqmzJs"
declare -A GROUP_IDS=(
  [A]="3f82e051"
  [B]="83fa5c6f"
  [C]="8607f2c4"
)

<<<<<<< HEAD
# Global weekly task creation
for WEEK in {1..8}; do
  echo "📌 Creating global task for Week $WEEK..."
  gh issue create \
    --title "🌍 Global Sprint Focus – Week $WEEK" \
    --body "This is the global focus and coordination task for all groups during Week $WEEK of the sprint." \
    --label "Week $WEEK" \
    --repo "$REPO"
  sleep 1
  echo "✅ Created global Week $WEEK task."
done

# Assign issues to weeks and groups
=======
>>>>>>> msvieira
ISSUE_NUM=1
for WEEK in {1..8}; do
  for GROUP in A B C; do
    echo "🔗 Linking and assigning Issue #$ISSUE_NUM (Group $GROUP, Week $WEEK)..."

    ISSUE_NODE_ID=$(gh api graphql -f query='query($owner:String!, $name:String!, $number:Int!) {
      repository(owner:$owner, name:$name) {
        issue(number: $number) { id }
      }
    }' -F owner="Ziforge" -F name="Neuroverse" -F number=$ISSUE_NUM --jq '.data.repository.issue.id')

    ITEM_ID=$(curl -s -X POST \
      -H "Authorization: bearer $GH_TOKEN" \
      -H "Content-Type: application/json" \
      -d '{"query": "mutation { addProjectV2ItemById(input: {projectId: \"'"$PROJECT_ID"'\", contentId: \"'"$ISSUE_NODE_ID"'\"}) { item { id } } }"}' \
      https://api.github.com/graphql | jq -r '.data.addProjectV2ItemById.item.id')

    # Set Status
    curl -s -X POST \
      -H "Authorization: bearer $GH_TOKEN" \
      -H "Content-Type: application/json" \
      -d '{"query": "mutation { updateProjectV2ItemFieldValue(input: { projectId: \"'"$PROJECT_ID"'\", itemId: \"'"$ITEM_ID"'\", fieldId: \"'"$STATUS_FIELD"'\", value: { singleSelectOptionId: \"'"$STATUS_TODO"'\" } }) { projectV2Item { id } } }"}' \
      https://api.github.com/graphql

    # Set Week
    curl -s -X POST \
      -H "Authorization: bearer $GH_TOKEN" \
      -H "Content-Type: application/json" \
      -d '{"query": "mutation { updateProjectV2ItemFieldValue(input: { projectId: \"'"$PROJECT_ID"'\", itemId: \"'"$ITEM_ID"'\", fieldId: \"'"$WEEK_FIELD"'\", value: { singleSelectOptionId: \"'"${WEEK_IDS[$WEEK]}"'\" } }) { projectV2Item { id } } }"}' \
      https://api.github.com/graphql

    # Set Group
    curl -s -X POST \
      -H "Authorization: bearer $GH_TOKEN" \
      -H "Content-Type: application/json" \
      -d '{"query": "mutation { updateProjectV2ItemFieldValue(input: { projectId: \"'"$PROJECT_ID"'\", itemId: \"'"$ITEM_ID"'\", fieldId: \"'"$GROUP_FIELD"'\", value: { singleSelectOptionId: \"'"${GROUP_IDS[$GROUP]}"'\" } }) { projectV2Item { id } } }"}' \
      https://api.github.com/graphql

    echo "✅ Issue #$ISSUE_NUM updated."
    ((ISSUE_NUM++))
  done
done
<<<<<<< HEAD

=======
>>>>>>> msvieira
