#!/bin/bash

FILENAME=workflows/deploy.yaml
TMP_FILE_NAME=tags_tmp
ACR_NAME=kemaldev
ACR_REPOSITORY_NAME=dotnet-test

# Get current tags that exist in the deploy file
cat $FILENAME | yq .on.workflow_dispatch.inputs.version.options > $TMP_FILE_NAME

# Get the amount of tags that exist
AMOUNT_OF_TAGS=$(wc -l $TMP_FILE_NAME | awk '{print $1}')

# Remove all tags from yaml file and replace with '#TAG_REPLACEMENT' value
INDEX=0
while read tag; do
  if (( $INDEX == $AMOUNT_OF_TAGS - 1 )) ; then
    sed -i "s%${tag}%#TAG_REPLACEMENT%g" $FILENAME
  else
    sed -i "\%${tag}%d" $FILENAME
  fi
  INDEX=$((INDEX + 1))
done < $TMP_FILE_NAME

# Remove temp file
rm -rf $TMP_FILE_NAME

# Get all tags from azure
az acr repository show-tags --name $ACR_NAME --repository $ACR_REPOSITORY_NAME | jq '.[]' > $TMP_FILE_NAME

# change each line to have a '-' at the beginning of the line to represent an array
sed -i -e 's/^/- /' $TMP_FILE_NAME

# remove quotes around tags
sed -i 's/\"//g' $TMP_FILE_NAME

# get indentation of 'otions:' object in workflows/deploy.yaml file and indent the tags according to it
INDENT=$(awk '/options:/' $FILENAME | sed 's/options://g' | awk '{print length}')
WHITESPACE_CHARS=$(($INDENT-1))

i=0
TEXT=''
PREFIX=' '
until [ $i -eq $WHITESPACE_CHARS ]; do 
  TEXT="${TEXT}${PREFIX}";
  ((i++))
done

while read tag; do
  sed -i "s/${tag}/${TEXT}${tag}/g" $TMP_FILE_NAME
done < $TMP_FILE_NAME

# inserting tags under options array in deploy file
touch "$FILENAME".tmp
awk "/#TAG_REPLACEMENT/{system(\"cat $TMP_FILE_NAME\");next}1" $FILENAME > "$FILENAME".tmp
mv "$FILENAME".tmp $FILENAME

rm -rf $TMP_FILE_NAME