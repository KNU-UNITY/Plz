using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;//적 생성을 위한 스테이지 크기 정보
    [SerializeField]
    private GameObject enemyPrefab;//복제해ㅐ서 생성할 적 캐릭터 프리랩
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private BGMController bgmController;
    [SerializeField]
    private GameObject textBossWarning;
    [SerializeField]
    private GameObject panelBossHP;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private float spawnTime;//생성 주기
    [SerializeField]
    private int maxEnemyCount = 100;

    private void Awake()
    {
        textBossWarning.SetActive(false);
        panelBossHP.SetActive(false);
        boss.SetActive(false);
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int currentEnemyCount = 0;
        while (true)
        {
            //x위치는 스테이지의 크기 범위 내에서 임의의 값을 선택
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            //적 생성 위치
            Vector3 position = new Vector3(positionX, stageData.LimitMax.y + 1.0f, 0.0f);
            //적 캐릭터 생성            
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            //적 체력을 나타내는 slider UI생성 및 설정
            SpawnEnemyHPSlider(enemyClone);

            currentEnemyCount++;
            if (currentEnemyCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss");

                break;
            }

            //spawnTime만큼 대기
            yield return new WaitForSeconds(spawnTime);
        }
    }
    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }

    private IEnumerator SpawnBoss()
    {
        bgmController.ChangeBGM(BGMType.Boss);
        textBossWarning.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        textBossWarning.SetActive(false);
        boss.SetActive(true);
        panelBossHP.SetActive(true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }
}

