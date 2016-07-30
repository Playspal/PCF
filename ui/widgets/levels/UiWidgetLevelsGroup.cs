using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using com.playspal.core.utils.helpers;
using com.playspal.core.storage;

namespace com.playspal.core.ui.widgets.levels
{
    public class UiWidgetLevelsGroup
    {
        public List<UiWidgetLevels> Blocks = new List<UiWidgetLevels>();

        private string _blockPrefabPath;
        private string _blockContainerPath;

        private int _blocksLength;
        private int _itemsPerBlock;
        private int _itemsTotal;

        public Action<int> OnClick;

        public int Count
        {
            get
            {
                return Blocks.Count;
            }
        }

        public UiWidgetLevelsGroup(string blockPrefabPath, string blockContainerPath, int itemsPerBlock, int itemsTotal)
        {
            _itemsPerBlock = itemsPerBlock;
            _itemsTotal = itemsTotal;

            _blockPrefabPath = blockPrefabPath;
            _blockContainerPath = blockContainerPath;
            _blocksLength = Mathf.CeilToInt((float)itemsTotal / (float)itemsPerBlock);

            int i;

            for(i = 0; i < _blocksLength; i++)
            {
                AddBlock();
            }
        }

        public void SetDataFromStorage()
        {
            foreach (UiWidgetLevels block in Blocks)
            {
                block.SetDataFromStorage();
            }
        }

        public void SetData(StorageLevel[] data)
        {
            foreach (UiWidgetLevels block in Blocks)
            {
                block.SetData(data);
            }
        }

        public List<UiObject> GetBlocksAsUiObjects()
        {
            List<UiObject> output = new List<UiObject>();

            foreach(UiWidgetLevels block in Blocks)
            {
                output.Add(block as UiObject);
            }

            return output;
        }

        private void AddBlock()
        {
            UiWidgetLevels block = new UiWidgetLevels
            (
                UnityUiHelper.Instantiate(_blockPrefabPath),
                _blockContainerPath
            );

            int length = Mathf.Min(_itemsPerBlock, _itemsTotal - Blocks.Count * _itemsPerBlock);
            
            block.SetIndex(Blocks.Count);
            block.SetLength(length);
            block.OnClick = OnBlockClickHandler;

            Blocks.Add(block);
        }

        private void OnBlockClickHandler(int index)
        {
            OnClick.InvokeIfNotNull(index);
        }
    }
}
