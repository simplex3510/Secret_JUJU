using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static Unity.Collections.AllocatorManager;

namespace Manager
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("Properties")]
        [SerializeField] private float STOCK_WIDTH;
        [SerializeField] private float CONTENT_HEIGHT = 520.7f;
        [SerializeField] private RectTransform content;
        [SerializeField] private Scrollbar scrollbarHorizontal;

        [Header("Don't Touch - Observed Value")]
        [SerializeField] private bool  isRefresh = true;
        [SerializeField] private int   stockCount = -1;
        [SerializeField] private float preStockPosY = 0f;

        public Vector2 AlignStockPosition(bool isPreProfit, bool isCurProfit, float stockHeight)
        {
            Vector2 position;
            float posY = 0f;

            stockCount++;

            #region Old Code
            /*
            if (isPreProfit == true)
            {
                if (isCurProfit == true)
                {
                    posY = preStockPosY + stockHeight;
                    position = new Vector2(STOCK_WIDTH * stockCount, preStockPosY);
                }
                else
                {
                    posY = preStockPosY - stockHeight;
                    position = new Vector2(STOCK_WIDTH * stockCount, posY);
                }
            }
            else
            {
                if (isCurProfit == true)
                {
                    posY = preStockPosY + stockHeight;
                    position = new Vector2(STOCK_WIDTH * stockCount, preStockPosY);
                }
                else
                {
                    posY = preStockPosY - stockHeight;
                    position = new Vector2(STOCK_WIDTH * stockCount, posY);
                }
            }
            */
            #endregion

            if (isCurProfit == true)
            {
                posY = preStockPosY + stockHeight;
                position = new Vector2(STOCK_WIDTH * stockCount, preStockPosY);
            }
            else
            {
                posY = preStockPosY - stockHeight;
                position = new Vector2(STOCK_WIDTH * stockCount, posY);
            }

            SetContentSize();
            preStockPosY = posY;
            return position;
        }

        public Vector2 AlignStockPosition(float stockHeight)
        {
            stockCount++;
            preStockPosY = stockHeight;
            SetContentSize();
            return new Vector2(STOCK_WIDTH * stockCount, 0f);
        }

        public void SetContentSize()
        {
            //content.sizeDelta = new Vector2(STOCK_WIDTH * stockCount, CONTENT_HEIGHT);
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }

        public void SetScrollbarValue(float value)
        {
            scrollbarHorizontal.value = 1;
        }

        public void ChangeIsRefresh()
        {
            if(isRefresh == true)
            {
                isRefresh = false;
            }
            else
            {
                isRefresh = true;
            }
        }
    }
}
