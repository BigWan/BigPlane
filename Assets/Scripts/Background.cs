﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BigPlane {

    public class Background : MonoBehaviour {

        [Header("Config")]
        public float tileHeight = 8.52f;

        /// <summary>
        /// 场景的可视范围,以高为限定,宽随屏幕比例调整
        /// </summary>
        public float bgHeight = 8.5f;

        public GameObject tileA;
        public GameObject tileB;


        [Header("Info Show")]
        [SerializeField]
        private float moveSpeed = 5f;


        private void Update() {
            BGMove();
        }

        private void Awake() {
            moveSpeed = moveSpeed <= 0 ? 5f : moveSpeed;
            InitTilePosition();
        }


        void InitTilePosition() {
            
            tileA.transform.localPosition = Vector3.zero;
            tileB.transform.localPosition = Vector3.up * tileHeight;

        }

        void BGMove() {
            Vector3 offset = Vector3.down * moveSpeed * Time.deltaTime;

            tileA.transform.Translate(offset, Space.World);
            tileB.transform.Translate(offset, Space.World);
            CheckSwitchTile(tileA);
            CheckSwitchTile(tileB);

        }


        void CheckSwitchTile(GameObject tile) {
            if (tile.transform.localPosition.y <= - bgHeight)
                tile.transform.Translate(Vector3.up * tileHeight * 2f);
        }





    }
}